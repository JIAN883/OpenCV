// imgFunc.cpp : 定義 DLL 應用程式的匯出函式。
//
#include "pch.h"
#include "imgFunc.h"
#include <opencv2/opencv.hpp>
using namespace cv;
#define PI 3.14159
#define global_size 5
Mat global_temp_mat[global_size];//用來當函式呼叫之間的媒介，每次用完記得release

void copyContent(Mat src, Mat dst) {
	int channelNum = src.channels();
	for (int ch = 0; ch < channelNum; ch++) {
		for (int row = 0; row < src.rows; row++) {
			for (int column = 0; column < src.cols; column++) {
				if (channelNum == 1) {
					dst.at<uchar>(row, column) = src.at<uchar>(row, column);
				}
				else if (channelNum == 3) {
					dst.at<Vec3b>(row, column)[ch] = src.at<Vec3b>(row, column)[ch];
				}
			}
		}
	}
}
// This is an example of an exported function.
IMGFUNC_API void Blur(unsigned char* imageBuffer, int width, int height, float value)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		blur(src, src, Size(value, value));
	}
}
/*110 06 12*/
//CH3_胡椒鹽雜訊 PepperPercent,SaltPercent，最大值皆為 50 (%)，最小值：0
IMGFUNC_API void GeneratePepperSalt(unsigned char* imageBuffer, int width, int height, float PepperPercent,float SaltPercent)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat randMtx = Mat::zeros(src.size(), CV_8U);
		randu(randMtx, 0, 255);
		Mat pepperMask = randMtx < 2.55 * PepperPercent; //Generate the mask of pepper noice
		Mat saltMask = randMtx > 255 - 2.55 * SaltPercent; //Generate the mask of salt noice
		//Add the pepper and salt noise to image
		src.setTo(255, saltMask); //Add salt noice
		src.setTo(0, pepperMask); //Add pepper noice
	}
}

//CH3_中位數濾波器 KernelSize 濾波器kernel = KernelSize * KernelSize
IMGFUNC_API void MedianFilter(unsigned char* imageBuffer, int width, int height, int KernelSize)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		medianBlur(src, src, KernelSize);
	}
}

//CH3_最大值濾波器 mode：0->maxFilter,!=0->minFilter   KernelSize 濾波器kernel = KernelSize * KernelSize (可接受偶數*偶數) 
IMGFUNC_API void MaxOrMinFilter(unsigned char* imageBuffer, int width, int height,int mode, int KernelSize,void* &dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		int tempMaxValue = 0;
		int tempMinValue = 255;
		int channelNum = src.channels();
		Mat dst = src.clone();
		for (int ch = 0; ch < channelNum; ch++) {
			for (int row = 0; row < src.rows; row++) {
				for (int column = 0; column < src.cols; column++) {
					//跑kernel 判斷Channel是多少 也判斷maxValue或minValue
					for (int tempR = row- KernelSize/2; tempR < (row+(KernelSize+1)/2); tempR++) {
						for (int tempC = column - KernelSize / 2; tempC < (column + (KernelSize + 1) / 2); tempC++) {
							if (tempR < 0 || tempC < 0 || tempR >= src.rows|| tempC >= src.cols) continue;
							if (channelNum == 1) {
								if (mode == 0) {
									if (src.at<uchar>(tempR, tempC) > tempMaxValue)
										tempMaxValue = src.at<uchar>(tempR, tempC);
								}
								else {
									if (src.at<uchar>(tempR, tempC) < tempMinValue)
										tempMinValue = src.at<uchar>(tempR, tempC);
								}
							}
							else if (channelNum == 3) {
								if (mode == 0) {
									if (src.at<Vec3b>(tempR, tempC)[ch] > tempMaxValue)
										tempMaxValue = src.at<Vec3b>(tempR, tempC)[ch];
								}
								else {
									if (src.at<Vec3b>(tempR, tempC)[ch] < tempMinValue)
										tempMinValue = src.at<Vec3b>(tempR, tempC)[ch];
								}
							}
						}
					}
					if (channelNum == 1) {
						if (mode == 0) 
							dst.at<uchar>(row, column) = tempMaxValue;
						else
							dst.at<uchar>(row, column) = tempMinValue;
					}
					else if (channelNum == 3) {
						if (mode == 0)
							dst.at<Vec3b>(row, column)[ch] = tempMaxValue;
						else
							dst.at<Vec3b>(row, column)[ch] = tempMinValue;
					}
					tempMaxValue = 0;
					tempMinValue = 255;
				}
			}
		}
		global_temp_mat[0]=dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(dst, src);
	}
}

//CH3_銳化濾波器(Sharp/Laplician filter)
	//isAddOriImage：true->有再加原圖,false->沒有加原圖(純邊緣資訊)
	//沒有開周圍4格，目前統一周圍8格
IMGFUNC_API void LaplicianFilter(unsigned char* imageBuffer, int width, int height, bool isAddOriImage)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat mask;
		if(isAddOriImage)
			mask = (Mat_<double>(3, 3) << -1, -1, -1, -1, 9, -1, -1, -1, -1);
		else mask = (Mat_<double>(3, 3) << -1, -1, -1, -1, 8, -1, -1, -1, -1);
		filter2D(src, src, src.depth(), mask);
	}
}

//CH3_取得鈍化圖形資訊(UnsharpInformation)
	//
IMGFUNC_API void getUnsharpInformation(unsigned char* imageBuffer, int width, int height, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat blu, unsharp_mask;
		//Prepare and apply the Laplacian filter
		Mat mask = (Mat_<double>(3, 3) << 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9);
		filter2D(src, blu, src.depth(), mask);
		unsharp_mask = src - blu; //取出特徵(unsharp mask)
		global_temp_mat[0] = unsharp_mask.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(unsharp_mask, src);
	}
}

//CH3_高增幅濾波器(Highboost filter)
	//k：鈍化倍數 float(>=0)
IMGFUNC_API void HighboostFilter(unsigned char* imageBuffer, int width, int height,float k, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat blu, unsharp_mask, sharp_mat;
		//Prepare and apply the Laplacian filter
		Mat mask = (Mat_<double>(3, 3) << 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9);
		filter2D(src, blu, src.depth(), mask);
		unsharp_mask = src - blu; //取出特徵(unsharp mask)
		sharp_mat = src + k * unsharp_mask;
		global_temp_mat[0] = sharp_mat.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(sharp_mat, src);
	}
}

//CH3_取得水平或垂直強度影像(display horizontal intensity images)
	//目前mask矩陣大小固定
	//isHorizontal：true->水平,false->垂直
	//isAddOriImage：true->有再加原圖,false->沒有加原圖(純水平或垂直強度資訊)
IMGFUNC_API void horizontalIntensityFilter(unsigned char* imageBuffer, int width, int height,bool isHorizontal,bool isAddOriImage, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat mask,dst;
		//Prepare and apply the Laplacian filter
		if (isHorizontal) 
			mask = (Mat_<double>(3, 3) << -1,-2,-1,0,0,0,1,2,1);
		else
			mask = (Mat_<double>(3, 3) << -1,0,1,-2,0,2,-1,0,1);
		if (isAddOriImage)
			mask.at<double>(1, 1) = 1;
		filter2D(src, dst, src.depth(), mask);
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(dst, src);
	}
}

//CH3_閥值處理(thresholding for Image)
	//thresh：閥值條件 (0~254,可預設127)
	//maxval：觸發閥值後設定的值 (0~254 可預設255)
IMGFUNC_API void thresholdProcessing(unsigned char* imageBuffer, int width, int height, double thresh, double maxval)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		threshold(src, src, thresh, maxval,THRESH_BINARY);
	}
}

//CH3_負片(negative)
IMGFUNC_API void negative(unsigned char* imageBuffer, int width, int height)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		src = 255 - src;
	}
}

//CH3_亮度調整1(Log)
	//c ：亮度倍率(>1,可預設2,float)
IMGFUNC_API void brightProcessing_log(unsigned char* imageBuffer, int width, int height,float c, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat log_dst;
		src.convertTo(log_dst, CV_32F, 1.f / 255.f);
		cv::log(log_dst + 1, log_dst);
		log_dst = c * log_dst / log(2.0);
		global_temp_mat[0] = log_dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(log_dst, src);
	}
}

//CH3_亮度調整2(Power conversion)
	//c ：亮度倍率(>=1,可預設1,float)
	//gamma：指數參數(=1->不變, >1->變暗, <1->變亮,可預設0.5)
IMGFUNC_API void brightProcessing_power(unsigned char* imageBuffer, int width, int height, float c,float gamma, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat log_dst;
		src.convertTo(log_dst, CV_32F, 1.f / 255.f);
		cv::pow(log_dst, gamma, log_dst);
		log_dst = c * log_dst ;
		global_temp_mat[0] = log_dst.clone();
		dstBuffer = global_temp_mat[0].data;
		copyContent(log_dst, src);
	}
}

//CH3_位元平面切片(bit plane Slicing)
	//bit：bit多少的切片(int,值域0~7)
IMGFUNC_API void bitPlaneSlicing(unsigned char* imageBuffer, int width, int height, int bit)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		for (int ch = 0; ch < src.channels(); ch++) {
			for (int row = 0; row < src.rows; row++) {
				for (int column = 0; column < src.cols; column++) {
					src.at<Vec3b>(row, column)[ch] = ((src.at<Vec3b>(row, column)[ch] >> bit) & 1) << 7;
				}
			}
		}
	}
}

//CH3_直方圖(Histogram Processing)
IMGFUNC_API void HistogramProcessing(unsigned char* imageBuffer,int width, int height, int bit, void*& dstBufferB, void*& dstBufferG, void*& dstBufferR)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		int histSize = 256;
		float range[] = { 0, 256 };
		const float* histRange = { range };
		Mat hist_b, hist_g, hist_r;
		Mat bgr_planes[3];
		split(src, bgr_planes);
		calcHist(&bgr_planes[0], 1, 0, noArray(), hist_b, 1, &histSize, &histRange); //來源照片，照片數量，CHANNEL，遮罩(1採用 0不採用)，OUTPUT，維度，直方圖大小，直方圖值範圍
		calcHist(&bgr_planes[1], 1, 0, noArray(), hist_g, 1, &histSize, &histRange); //來源照片，照片數量，CHANNEL，遮罩(1採用 0不採用)，OUTPUT，維度，直方圖大小，直方圖值範圍
		calcHist(&bgr_planes[2], 1, 0, noArray(), hist_r, 1, &histSize, &histRange); //來源照片，照片數量，CHANNEL，遮罩(1採用 0不採用)，OUTPUT，維度，直方圖大小，直方圖值範圍
		normalize(hist_b, hist_b, 0, src.rows, NORM_MINMAX);//正規化(以最高的直方當最高點) //NORM_MINMAX：選擇的正規化方法 389：最高 0：最低
		normalize(hist_g, hist_g, 0, src.rows, NORM_MINMAX);
		normalize(hist_r, hist_r, 0, src.rows, NORM_MINMAX);
		// Draw the histogram
		int hist_w = 512, hist_h = 400, bin_w = (double)hist_w / histSize + 0.5;
		//hist_b
		global_temp_mat[0]=Mat(hist_h, hist_w, CV_8U, Scalar(255)); //圖高 圖寬 單位  Scalar(255)：會是全白色(全部255)
		for (int i = 0; i < histSize; i++) {
			line(global_temp_mat[0], Point(bin_w * i, hist_h), Point(bin_w * i, hist_h - hist_b.at<float>(i)), Scalar(0)); //畫線 *圖是左上為原點：由底往上畫
		}
		//hist_g
		global_temp_mat[1] = Mat(hist_h, hist_w, CV_8U, Scalar(255)); //圖高 圖寬 單位  Scalar(255)：會是全白色(全部255)
		for (int i = 0; i < histSize; i++) {
			line(global_temp_mat[1], Point(bin_w * i, hist_h), Point(bin_w * i, hist_h - hist_g.at<float>(i)), Scalar(0)); //畫線 *圖是左上為原點：由底往上畫
		}
		//hist_r
		global_temp_mat[2] = Mat(hist_h, hist_w, CV_8U, Scalar(255)); //圖高 圖寬 單位  Scalar(255)：會是全白色(全部255)
		for (int i = 0; i < histSize; i++) {
			line(global_temp_mat[2], Point(bin_w * i, hist_h), Point(bin_w * i, hist_h - hist_r.at<float>(i)), Scalar(0)); //畫線 *圖是左上為原點：由底往上畫
		}
		//return to c#
		dstBufferB = global_temp_mat[0].data;
		dstBufferG = global_temp_mat[1].data;
		dstBufferR = global_temp_mat[2].data;
		
	}
}

//CH3_等化直方圖處理(equalizeHist)
	//mode (int,1->RGB,2->HSV)
IMGFUNC_API void equalizeHist(unsigned char* imageBuffer, int width, int height, int mode, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat dst, Channels[3];
		//Histogram equalization
		if (mode == 1) {
			split(src, Channels); // split color channels
			equalizeHist(Channels[0], Channels[0]); //Proces channel 0
			equalizeHist(Channels[1], Channels[1]); //Proces channel 1
			equalizeHist(Channels[2], Channels[2]); //Proces channel 2
			merge(Channels, 3, dst);
		}
		else if (mode == 2) {
			cvtColor(src, dst, COLOR_BGR2HSV);
			split(dst, Channels); // split color channels
			equalizeHist(Channels[2], Channels[2]); //Proces V channel only
			merge(Channels, 3, dst);
			cvtColor(dst, dst, COLOR_HSV2BGR);
		}
		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(dst, src);
	}
}

//CH2_改變長寬比例(change the aspect ratio)
	//xtimes ：x軸放大倍數(double,>0.1)
	//ytimes ：x軸放大倍數(double,>0.1)
	//isfullsize ：記憶體大小是否隨著放大縮小而改變 (true：隨著新圖改變大小，false：不改變大小，可直接設成true)
IMGFUNC_API void changeImageSize(unsigned char* imageBuffer, int width, int height, double xtimes, double ytimes, bool isfullsize, int*& dst_width, int*& dst_height, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {

		Mat dst;
		Mat M = (Mat_<double>(2, 3) << xtimes, 0, 0, 0, ytimes, 0); // prepare matrix 2->colunm數 3->row數，左上到左下中上到中下
		if (isfullsize) {
			dst = Mat::zeros(src.rows * xtimes, src.cols * ytimes, CV_8UC3);
			Size mysize = dst.size();
			warpAffine(src, dst, M, mysize); //size可以直接做除法 (ex：長寬都1/3：orgImg.size()/3)
		}
		else {
			warpAffine(src, dst, M, src.size()); // call opencv's affine transform
		}
		//return to c#
		*dst_width = (int)width * xtimes;
		*dst_height= (int)height * ytimes;
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
		
	}
}

//CH2_旋轉(Rotate)
	//angle ：順時針旋轉angle度(double)
IMGFUNC_API void Rotate(unsigned char* imageBuffer, int width, int height, double angle, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat dst;
		double rad = PI * angle / 180.0; // degree to radian
		Mat M = (Mat_<double>(2, 3) << cos(rad), -sin(rad), 0, sin(rad), cos(rad), 0); // prepare matrix 2->colunm數 3->row數，左上到左下中上到中下
		warpAffine(src, dst, M, src.size()); // call opencv's affine transform
		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

//CH2_剪形(Shear)
	//xshear ：水平剪形程度 (double)
	//yshear ：垂直剪形程度 (double)
IMGFUNC_API void Shear(unsigned char* imageBuffer, int width, int height, double xshear, double yshear, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat dst;
		Mat M = (Mat_<double>(2, 3) << 1, xshear, 0, yshear, 1, 0); 
		warpAffine(src, dst, M, src.size());

		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

//CH2_鏡射(Reflect)
	//isReflectAboutXaxis：true->上下鏡射 false->不上下鏡射
	//isReflectAboutYaxis：true->左右鏡射 false->不左右鏡射
IMGFUNC_API void Reflect(unsigned char* imageBuffer, int width, int height, bool isReflectAboutXaxis, bool isReflectAboutYaxis, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat dst,M;
		if (isReflectAboutXaxis)
			if (isReflectAboutYaxis)
				M = (Mat_<double>(2, 3) << -1, 0, src.cols, 0, -1, src.rows); //上下左右鏡射
			else
				M = (Mat_<double>(2, 3) << 1, 0, 0, 0, -1, src.rows); //上下鏡射
		else if(isReflectAboutYaxis)
			M = (Mat_<double>(2, 3) << -1, 0, src.cols, 0, -1, 0); //左右鏡射
		else 
			M = (Mat_<double>(2, 3) << 1, 0, 0, 0, 1, 0); //維持不變
		warpAffine(src, dst, M, src.size());

		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

//CH4_頻率域圖形調整(使越中間越低頻) ----功能函式----
void swapFreq(Mat& F)
{
	int cx = F.cols / 2;
	int cy = F.rows / 2;
	Mat q0(F, Rect(0, 0, cx, cy)); // Top-Left
	Mat q1(F, Rect(cx, 0, cx, cy)); // Top-Right
	Mat q2(F, Rect(0, cy, cx, cy)); // Bottom-Left
	Mat q3(F, Rect(cx, cy, cx, cy)); // Bottom-Right
	//swap quadrants
	Mat tmp;
	q0.copyTo(tmp);
	q3.copyTo(q0);
	tmp.copyTo(q3);
	q1.copyTo(tmp);
	q2.copyTo(q1);
	tmp.copyTo(q2);
}

//CH4_DFT transform ----功能函式----
Mat myDFT(Mat& f)
{
	Mat F; //frequency data
	Mat padded; //Padded image
	//Pad image to optimal DFT size with 0s
	int m = getOptimalDFTSize(f.rows);
	int n = getOptimalDFTSize(f.cols);
	copyMakeBorder(f, padded, 0, m - f.rows, 0, n - f.cols, BORDER_CONSTANT, Scalar::all(0));
	// allocate memory for storing frequency data and doing DFT
	Mat planes[] = { Mat_<float>(padded),
	Mat(padded.size(), CV_32F, 0.0f) };
	merge(planes, 2, F);
	dft(F, F);
	swapFreq(F);
	return F;
}

//CH4_DFT_BGR transform ----功能函式----
Mat* myDFT_BGR(Mat& f)
{
	Mat BGR_planes[3];
	Mat DFT_planes[3];
	split(f, BGR_planes);
	DFT_planes[0] = myDFT(BGR_planes[0]);
	DFT_planes[1] = myDFT(BGR_planes[1]);
	DFT_planes[2] = myDFT(BGR_planes[2]);
	return DFT_planes;
}

//IDFT transform ----功能函式----
Mat myIDFT(Mat& F)
{
	Mat planes[2];
	swapFreq(F);
	idft(F, F, DFT_SCALE);
	split(F, planes);
	return planes[0].clone();
}

//IDFT_BGR transform ----功能函式----
Mat myIDFT_BGR(Mat* F)
{
	Mat dst_planes[3];
	Mat dst;
	dst_planes[0] = myIDFT(F[0]);
	dst_planes[1] = myIDFT(F[1]);
	dst_planes[2] = myIDFT(F[2]);
	merge(dst_planes, 3, dst);
	return dst;
}

//CH4_取得頻率資訊圖 ----功能函式----
	//原圖當input，回傳可直接秀圖的Mat
Mat getFrequencyDomainInformation_internalFunc(Mat& src) {
	if (!src.empty()) {
		src.convertTo(src, CV_32F, 1.f / 255);
		Mat F = myDFT(src); //F：頻率域的圖
		//Compute manitude of frequencies
		Mat planes[2], Fmag;
		split(F, planes); // planes[0] = Re(DFT(I), planes[1] = Im(DFT(I))
		magnitude(planes[0], planes[1], Fmag); // Fmag = magnitude
		//log enhancement
		Fmag += 1;
		log(Fmag, Fmag);
		//show result
		normalize(Fmag, Fmag, 0, 1, NORM_MINMAX);
		return Fmag;
	}
}

//CH4_取得頻率資訊圖(getFrequencyDomainInformation)
IMGFUNC_API void getFrequencyDomainInformation(unsigned char* imageBuffer, int width, int height, void*& dstBufferB, void*& dstBufferG, void*& dstBufferR)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {

		Mat BGR_planes[3];
		Mat dst_planes[3];
		split(src, BGR_planes);
		dst_planes[0] = getFrequencyDomainInformation_internalFunc(BGR_planes[0]);
		dst_planes[1] = getFrequencyDomainInformation_internalFunc(BGR_planes[1]);
		dst_planes[2] = getFrequencyDomainInformation_internalFunc(BGR_planes[2]);
		//return to c#
		global_temp_mat[0] = dst_planes[0].clone();
		global_temp_mat[1] = dst_planes[1].clone();
		global_temp_mat[2] = dst_planes[2].clone();
		dstBufferB = global_temp_mat[0].data;
		dstBufferG = global_temp_mat[1].data;
		dstBufferR = global_temp_mat[2].data;
	}
}

//CH4_理想低通濾波器 ----功能函式----
void IdealLowPassFilter(Mat& F, int d0)
{
	Mat H(F.rows, F.cols, CV_32FC2, Scalar(0, 0));
	circle(H, Point(H.cols / 2, H.rows / 2), d0, Scalar::all(1), -1);
	F = F.mul(H);
}

//CH4_理想高通濾波器 ----功能函式----
void IdealHighPassFilter(Mat& F, int d0)
{
	Mat H(F.rows, F.cols, CV_32FC2, Scalar(1, 1));
	circle(H, Point(H.cols / 2, H.rows / 2), d0, Scalar::all(0), -1);
	F = F.mul(H);
}

//CH4_高斯低通濾波器 ----功能函式----
void GaussianLowPassFilter(Mat& F, int d0)
{
	Mat_<Vec2f> H = Mat(F.rows, F.cols, CV_32FC2);
	int cx = F.rows / 2;
	int cy = F.cols / 2;
	for (int u = 0; u < F.rows; u++) {
		for (int v = 0; v < F.cols; v++) {
			float d = sqrt((float)((u - cx) * (u - cx) + (v - cy) * (v - cy)));
			H(u, v)[0] = (float)exp((-d * d) / (2 * d0 * d0));
			H(u, v)[1] = H(u, v)[0];
		}
	}
	F = F.mul(H);
}

//CH4_高斯高通濾波器 ----功能函式----
void GaussianHighPassFilter(Mat& F, int d0)
{
	Mat_<Vec2f> H = Mat(F.rows, F.cols, CV_32FC2);
	int cx = F.rows / 2;
	int cy = F.cols / 2;
	for (int u = 0; u < F.rows; u++) {
		for (int v = 0; v < F.cols; v++) {
			float d = sqrt((float)((u - cx) * (u - cx) + (v - cy) * (v - cy)));
			H(u, v)[0] = 1 - (float)exp((-d * d) / (2 * d0 * d0));
			H(u, v)[1] = H(u, v)[0];
		}
	}
	F = F.mul(H);
}

//CH4_Butterworth低通濾波器 ----功能函式----
void ButterworthLowPassFilter(Mat& F, int d0, float n)
{
	Mat_<Vec2f> H = Mat(F.rows, F.cols, CV_32FC2);
	int cx = F.rows / 2;
	int cy = F.cols / 2;
	for (int u = 0; u < F.rows; u++) {
		for (int v = 0; v < F.cols; v++) {
			float d = sqrt((float)((u - cx) * (u - cx) + (v - cy) * (v - cy)));
			H(u, v)[0] = (float)1 / (1 + pow((d / d0), 2 * n));
			H(u, v)[1] = H(u, v)[0];
		}
	}
	F = F.mul(H);
}

//CH4_Butterworth高通濾波器 ----功能函式----
void ButterworthHighPassFilter(Mat& F, int d0, float n)
{
	Mat_<Vec2f> H = Mat(F.rows, F.cols, CV_32FC2);
	int cx = F.rows / 2;
	int cy = F.cols / 2;
	for (int u = 0; u < F.rows; u++) {
		for (int v = 0; v < F.cols; v++) {
			float d = sqrt((float)((u - cx) * (u - cx) + (v - cy) * (v - cy)));
			H(u, v)[0] = (float)1 / (1 + pow((d0 / d), 2 * n));
			H(u, v)[1] = H(u, v)[0];
		}
	}
	F = F.mul(H);
}

//CH4_(理想/高斯)(高通/低通)濾波器(idealOrGaussianPassFilter)
	//isIdeal：true->理想濾波器,false->高斯濾波器
	//isHighPass：true->高通,false->低通
	//d0：影響大小參數 (int 最小0)
	//isAddOri：true->最後再加上原圖，false->純粹顯示濾波後的圖片
IMGFUNC_API void idealOrGaussianPassFilter(unsigned char* imageBuffer, int width, int height, bool isIdeal, bool isHighPass, int d0,bool isAddOri, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat* DFT_planes;
		Mat dst;
		DFT_planes = myDFT_BGR(src);
		isIdeal ? isHighPass ? IdealHighPassFilter(DFT_planes[0], d0) : IdealLowPassFilter(DFT_planes[0], d0) : isHighPass ? GaussianHighPassFilter(DFT_planes[0], d0) : GaussianLowPassFilter(DFT_planes[0], d0);
		isIdeal ? isHighPass ? IdealHighPassFilter(DFT_planes[1], d0) : IdealLowPassFilter(DFT_planes[1], d0) : isHighPass ? GaussianHighPassFilter(DFT_planes[1], d0) : GaussianLowPassFilter(DFT_planes[1], d0);
		isIdeal ? isHighPass ? IdealHighPassFilter(DFT_planes[2], d0) : IdealLowPassFilter(DFT_planes[2], d0) : isHighPass ? GaussianHighPassFilter(DFT_planes[2], d0) : GaussianLowPassFilter(DFT_planes[2], d0);

		dst = myIDFT_BGR(DFT_planes);
		if (isAddOri)dst = dst + src;
		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

//CH4_Butterworth(高通/低通)濾波器(butterworthPassFilter)
	//isHighPass：true->高通,false->低通
	//d0：影響大小參數 (int,最小0)
	//n：影響大小參數 (float,1->不變,動一些就差很多)
	//isAddOri：true->最後再加上原圖，false->純粹顯示濾波後的圖片
IMGFUNC_API void butterworthPassFilter(unsigned char* imageBuffer, int width, int height, bool isHighPass, int d0,float n, bool isAddOri, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat* DFT_planes;
		Mat dst;
		DFT_planes = myDFT_BGR(src);
		isHighPass ? ButterworthHighPassFilter(DFT_planes[0], d0, n) : ButterworthLowPassFilter(DFT_planes[0], d0, n);
		isHighPass ? ButterworthHighPassFilter(DFT_planes[1], d0, n) : ButterworthLowPassFilter(DFT_planes[1], d0, n);
		isHighPass ? ButterworthHighPassFilter(DFT_planes[2], d0, n) : ButterworthLowPassFilter(DFT_planes[2], d0, n);
		
		dst = myIDFT_BGR(DFT_planes);
		if (isAddOri)dst = dst + src;
		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}
//CH5_----適應性中間值濾波器的功能函式----
void maxFilter(Mat& src, Mat& dst, int size) {
	Mat element = getStructuringElement(MORPH_RECT, Size(2 * size + 1, 2 * size + 1), Point(size, size)); //先做filter
	dilate(src, dst, element); //膨脹的作用
}
//CH5_----適應性中間值濾波器的功能函式----
void minFilter(Mat& src, Mat& dst, int size)
{
	Mat element = getStructuringElement(MORPH_RECT, Size(2 * size + 1, 2 * size + 1), Point(size, size));
	erode(src, dst, element); //侵蝕
}
//CH5_adaptiveMedianFilte 單面_適應性中間值濾波器(adaptiveMedianFilter) ----功能函式----
Mat adaptiveMedianFilter(Mat& Zxy, int s_max)
{
	//allocate memory for storing min, median, and max filters
	int numSize = (s_max - 3) / 2 + 1; //3是自己定 從3開始 3*3 5*5 7*7
	Mat* Zmin = new Mat[numSize];
	Mat* Zmed = new Mat[numSize];
	Mat* Zmax = new Mat[numSize];
	//get results of min, median, and max filters
	int boxSize = 3;
	int pos;
	for (pos = 0; pos < numSize; pos++, boxSize += 2) { //跑3*3 5*5 7*7個各種結果
		minFilter(Zxy, Zmin[pos], boxSize);
		medianBlur(Zxy, Zmed[pos], boxSize);
		maxFilter(Zxy, Zmax[pos], boxSize);
	}
	//Adaptive median filter
	Mat rlt = Mat(Zxy.size(), CV_8UC1);
	for (int r = 0; r < Zxy.rows; r++) { // for every row
		for (int c = 0; c < Zxy.cols; c++) { // for every column //刷每個點
		// Level A
			boxSize = 3; //一開始：3*3
			while (boxSize <= s_max) {
				pos = (boxSize - 3) / 2;
				int A1 = Zmed[pos].at<uchar>(r, c) - Zmin[pos].at<uchar>(r, c);
				int A2 = Zmed[pos].at<uchar>(r, c) - Zmax[pos].at<uchar>(r, c);
				if ((A1 > 0) && (A2 < 0)) break;
				else boxSize += 2;
			}
			if (boxSize > s_max) {  //表示找不到
				rlt.at<uchar>(r, c) = Zxy.at<uchar>(r, c);  //rlt：要回傳的結果
			}
			else {
				// Level B
				int B1 = Zxy.at<uchar>(r, c) - Zmin[pos].at<uchar>(r, c);
				int B2 = Zxy.at<uchar>(r, c) - Zmax[pos].at<uchar>(r, c);
				if ((B1 > 0) && (B2 < 0)) {
					rlt.at<uchar>(r, c) = Zxy.at<uchar>(r, c);
				}
				else {
					rlt.at<uchar>(r, c) = Zmed[pos].at<uchar>(r, c);
				}
			}
		}
	}
	//release memory and return result
	delete[] Zmin;
	delete[] Zmed;
	delete[] Zmax;
	return rlt;
}

//CH5_adaptiveMedianFilter_BGR適應性中間值濾波器(adaptiveMedianFilter)
	//s_max：Filter kernel大小 (要奇數,int)
IMGFUNC_API void adaptiveMedianFilter_BGR(unsigned char* imageBuffer, int width, int height,int s_max, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat planes[3];
		Mat dst;
		split(src, planes);
		planes[0] = adaptiveMedianFilter(planes[0], s_max);
		planes[1] = adaptiveMedianFilter(planes[1], s_max);
		planes[2] = adaptiveMedianFilter(planes[2], s_max);
		merge(planes, 3, dst);
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

//CH5_幾何平均濾波器 KernelSize 濾波器kernel = KernelSize * KernelSize (可接受偶數*偶數 不可0*0) 
IMGFUNC_API void geometricMeanFilter(unsigned char* imageBuffer, int width, int height, int KernelSize, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		double tempTotal = 1;
		double tempTotalNum = 0;
		int channelNum = src.channels();
		Mat dst = src.clone();
		for (int ch = 0; ch < channelNum; ch++) {
			for (int row = 0; row < src.rows; row++) {
				for (int column = 0; column < src.cols; column++) {
					//跑kernel 判斷Channel是多少 也判斷maxValue或minValue
					for (int tempR = row - KernelSize / 2; tempR < (row + (KernelSize + 1) / 2); tempR++) {
						for (int tempC = column - KernelSize / 2; tempC < (column + (KernelSize + 1) / 2); tempC++) {
							if (tempR < 0 || tempC < 0 || tempR >= src.rows || tempC >= src.cols) continue;
							if (channelNum == 1) {
								tempTotal *= src.at<uchar>(tempR, tempC);
								tempTotalNum++;
							}
							else if (channelNum == 3) {
								tempTotal *= src.at<Vec3b>(tempR, tempC)[ch];
								tempTotalNum++;
							}
						}
					}
					if (tempTotalNum <= 0)tempTotalNum = 1;
					if (channelNum == 1) {
						dst.at<uchar>(row, column) = pow(tempTotal, 1 / tempTotalNum);
					}
					else if (channelNum == 3) {
						dst.at<Vec3b>(row, column)[ch] = pow(tempTotal, 1 / tempTotalNum);
					}
					tempTotal = 1;
					tempTotalNum = 0;
				}
			}
		}
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(dst, src);
	}
}

//CH5_調和平均濾波器 KernelSize 濾波器kernel = KernelSize * KernelSize (可接受偶數*偶數 不可0*0) 
IMGFUNC_API void harmonicMeanFilter(unsigned char* imageBuffer, int width, int height, int KernelSize, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		double tempTotal = 0;
		double tempTotalNum = 0;
		int channelNum = src.channels();
		Mat dst = src.clone();
		for (int ch = 0; ch < channelNum; ch++) {
			for (int row = 0; row < src.rows; row++) {
				for (int column = 0; column < src.cols; column++) {
					//跑kernel 判斷Channel是多少 也判斷maxValue或minValue
					for (int tempR = row - KernelSize / 2; tempR < (row + (KernelSize + 1) / 2); tempR++) {
						for (int tempC = column - KernelSize / 2; tempC < (column + (KernelSize + 1) / 2); tempC++) {
							if (tempR < 0 || tempC < 0 || tempR >= src.rows || tempC >= src.cols) continue;
							if (channelNum == 1) {
								if (src.at<uchar>(tempR, tempC) <= 0)src.at<uchar>(tempR, tempC) = 1;
								tempTotal +=1/(double)src.at<uchar>(tempR, tempC);
								tempTotalNum++;
							}
							else if (channelNum == 3) {
								if (src.at<Vec3b>(tempR, tempC)[ch] <= 0)src.at<Vec3b>(tempR, tempC)[ch] = 1;
								tempTotal += 1 / (double)src.at<Vec3b>(tempR, tempC)[ch];
								tempTotalNum++;
							}
						}
					}
					if (tempTotal <= 0)tempTotal = 1;
					if (channelNum == 1) {
						dst.at<uchar>(row, column) = tempTotalNum/ tempTotal;
					}
					else if (channelNum == 3) {
						dst.at<Vec3b>(row, column)[ch] = tempTotalNum / tempTotal;
					}
					tempTotal = 0;
					tempTotalNum = 0;
				}
			}
		}
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(dst, src);
	}
}

//CH5_反調和平均濾波器 KernelSize 濾波器kernel = KernelSize * KernelSize (可接受偶數*偶數 不可0*0) 
	//Q：影響程度(Q>1：解決黑雜點，Q<-1：解決白雜點,可float)
IMGFUNC_API void counterHarmonicMeanFilter(unsigned char* imageBuffer, int width, int height, int KernelSize,float Q, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		double tempTotal_Denominator = 0; //分母總和
		double tempTotal_Molecular = 0; //分子總和
		int channelNum = src.channels();
		Mat dst = src.clone();
		for (int ch = 0; ch < channelNum; ch++) {
			for (int row = 0; row < src.rows; row++) {
				for (int column = 0; column < src.cols; column++) {
					//跑kernel 判斷Channel是多少 也判斷maxValue或minValue
					for (int tempR = row - KernelSize / 2; tempR < (row + (KernelSize + 1) / 2); tempR++) {
						for (int tempC = column - KernelSize / 2; tempC < (column + (KernelSize + 1) / 2); tempC++) {
							if (tempR < 0 || tempC < 0 || tempR >= src.rows || tempC >= src.cols) continue;
							if (channelNum == 1) {
								tempTotal_Molecular += pow((double)src.at<uchar>(tempR, tempC), (double)Q + 1);
								tempTotal_Denominator += pow((double)src.at<uchar>(tempR, tempC), (double)Q);
							}
							else if (channelNum == 3) {
								tempTotal_Molecular += pow((double)src.at<Vec3b>(tempR, tempC)[ch], (double)Q + 1);
								tempTotal_Denominator += pow((double)src.at<Vec3b>(tempR, tempC)[ch], (double)Q);
							}
						}
					}
					if (tempTotal_Denominator <= 0)tempTotal_Denominator = 1;
					if (channelNum == 1) {
						dst.at<uchar>(row, column) = tempTotal_Molecular / tempTotal_Denominator;
					}
					else if (channelNum == 3) {
						dst.at<Vec3b>(row, column)[ch] = tempTotal_Molecular / tempTotal_Denominator;
					}
					tempTotal_Denominator = 0;
					tempTotal_Molecular = 0;
				}
			}
		}
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(dst, src);
	}
}
