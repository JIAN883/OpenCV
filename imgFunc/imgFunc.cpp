// imgFunc.cpp : �w�q DLL ���ε{�����ץX�禡�C
//
#include "pch.h"
#include "imgFunc.h"
#include <opencv2/opencv.hpp>
using namespace cv;
#define PI 3.14159
#define global_size 5
#define ILL_A 109.850, 100.0, 35.585
#define ILL_D50 96.422, 100.0, 82.521
#define ILL_D55 95.682, 100.0, 92.149
#define ILL_D65 95.047, 100.0, 108.883
#define ILL_D75 94.972, 100.0, 122.638
/*
#define B 0
#define G 1
#define R 2
#define C 3
#define M 4
#define Y 5
*/
Mat global_temp_mat[global_size];//�Ψӷ�禡�I�s�������C���A�C���Χ��O�orelease

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
//CH3_�J���Q���T PepperPercent,SaltPercent�A�̤j�ȬҬ� 50 (%)�A�̤p�ȡG0
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

//CH3_������o�i�� KernelSize �o�i��kernel = KernelSize * KernelSize
IMGFUNC_API void MedianFilter(unsigned char* imageBuffer, int width, int height, int KernelSize)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		medianBlur(src, src, KernelSize);
	}
}

//CH3_�̤j���o�i�� mode�G0->maxFilter,!=0->minFilter   KernelSize �o�i��kernel = KernelSize * KernelSize (�i��������*����) 
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
					//�]kernel �P�_Channel�O�h�� �]�P�_maxValue��minValue
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

//CH3_�U���o�i��(Sharp/Laplician filter)
	//isAddOriImage�Gtrue->���A�[���,false->�S���[���(����t��T)
	//�S���}�P��4��A�ثe�Τ@�P��8��
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

//CH3_���o�w�ƹϧθ�T(UnsharpInformation)
	//
IMGFUNC_API void getUnsharpInformation(unsigned char* imageBuffer, int width, int height, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat blu, unsharp_mask;
		//Prepare and apply the Laplacian filter
		Mat mask = (Mat_<double>(3, 3) << 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9);
		filter2D(src, blu, src.depth(), mask);
		unsharp_mask = src - blu; //���X�S�x(unsharp mask)
		global_temp_mat[0] = unsharp_mask.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(unsharp_mask, src);
	}
}

//CH3_���W�T�o�i��(Highboost filter)
	//k�G�w�ƭ��� float(>=0)
IMGFUNC_API void HighboostFilter(unsigned char* imageBuffer, int width, int height,float k, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat blu, unsharp_mask, sharp_mat;
		//Prepare and apply the Laplacian filter
		Mat mask = (Mat_<double>(3, 3) << 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9);
		filter2D(src, blu, src.depth(), mask);
		unsharp_mask = src - blu; //���X�S�x(unsharp mask)
		sharp_mat = src + k * unsharp_mask;
		global_temp_mat[0] = sharp_mat.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(sharp_mat, src);
	}
}

//CH3_���o�����Ϋ����j�׼v��(display horizontal intensity images)
	//�ثemask�x�}�j�p�T�w
	//isHorizontal�Gtrue->����,false->����
	//isAddOriImage�Gtrue->���A�[���,false->�S���[���(�¤����Ϋ����j�׸�T)
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

//CH3_�֭ȳB�z(thresholding for Image)
	//thresh�G�֭ȱ��� (0~254,�i�w�]127)
	//maxval�GĲ�o�֭ȫ�]�w���� (0~254 �i�w�]255)
IMGFUNC_API void thresholdProcessing(unsigned char* imageBuffer, int width, int height, double thresh, double maxval)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		threshold(src, src, thresh, maxval,THRESH_BINARY);
	}
}

//CH3_�t��(negative)
IMGFUNC_API void negative(unsigned char* imageBuffer, int width, int height)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat plane[3];
		split(src, plane);
		for(int temp=0;temp<3;temp++)
			plane[temp] = 255 - plane[temp];
		merge(plane,3,src);
	}
}

//CH3_�G�׽վ�1(Log)
	//c �G�G�׭��v(>1,�i�w�]2,float)
IMGFUNC_API void brightProcessing_log(unsigned char* imageBuffer, int width, int height,float c, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat log_dst;
		Mat planes[3];
		split(src, planes);
		for (int i = 0; i < 3; i++) {
			planes[i].convertTo(planes[i], CV_32F, 1.f / 255.f);
			cv::log(planes[i] + 1, planes[i]);
			planes[i] = c * planes[i] / log(2.0);
			planes[i].convertTo(planes[i], CV_8U, 255.f);
		}
		merge(planes, 3, log_dst);
		/*src.convertTo(log_dst, CV_32F, 1.f / 255.f);
		cv::log(log_dst + 1, log_dst);
		log_dst = c * log_dst / log(2.0);*/
		global_temp_mat[0] = log_dst.clone();
		dstBuffer = global_temp_mat[0].data;
		//copyContent(log_dst, src);
	}
}

//CH3_�G�׽վ�2(Power conversion)
	//c �G�G�׭��v(>=1,�i�w�]1,float)
	//gamma�G���ưѼ�(=1->����, >1->�ܷt, <1->�ܫG,�i�w�]0.5)
IMGFUNC_API void brightProcessing_power(unsigned char* imageBuffer, int width, int height, float c,float gamma, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat log_dst;

		Mat planes[3];
		split(src, planes);
		for (int i = 0; i < 3; i++) {
			planes[i].convertTo(planes[i], CV_32F, 1.f / 255.f);
			cv::pow(planes[i], gamma, planes[i]);
			planes[i] = c * planes[i];
			planes[i].convertTo(planes[i], CV_8U, 255.f);
		}
		merge(planes, 3, log_dst);

		/*src.convertTo(log_dst, CV_32F, 1.f / 255.f);
		cv::pow(log_dst, gamma, log_dst);
		log_dst = c * log_dst ;*/
		global_temp_mat[0] = log_dst.clone();
		dstBuffer = global_temp_mat[0].data;
		copyContent(log_dst, src);
	}
}

//CH3_�줸��������(bit plane Slicing)
	//bit�Gbit�h�֪�����(int,�Ȱ�0~7)
IMGFUNC_API void bitPlaneSlicing(unsigned char* imageBuffer, int width, int height, int bit)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Mat dst=src.clone();
	if (!src.empty()) {
		for (int ch = 0; ch < src.channels(); ch++) {
			for (int row = 0; row < src.rows; row++) {
				for (int column = 0; column < src.cols; column++) {
					dst.at<Vec3b>(row, column)[ch] = 0;
					for (int tempBit = 0; tempBit < 8; tempBit++) {
						dst.at<Vec3b>(row, column)[ch] += (((src.at<Vec3b>(row, column)[ch] >> tempBit) & 0x01 ) << tempBit) & bit;
					}
				}
			}
		}
		copyContent(dst, src);
	}
}

//CH3_�����(Histogram Processing)
IMGFUNC_API void HistogramProcessing(unsigned char* imageBuffer,int width, int height, void*& dstBufferB, void*& dstBufferG, void*& dstBufferR)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		int histSize = 256;
		float range[] = { 0, 256 };
		const float* histRange = { range };
		Mat hist_b, hist_g, hist_r;
		Mat bgr_planes[3];
		split(src, bgr_planes);
		calcHist(&bgr_planes[0], 1, 0, noArray(), hist_b, 1, &histSize, &histRange); //�ӷ��Ӥ��A�Ӥ��ƶq�ACHANNEL�A�B�n(1�ĥ� 0���ĥ�)�AOUTPUT�A���סA����Ϥj�p�A����ϭȽd��
		calcHist(&bgr_planes[1], 1, 0, noArray(), hist_g, 1, &histSize, &histRange); //�ӷ��Ӥ��A�Ӥ��ƶq�ACHANNEL�A�B�n(1�ĥ� 0���ĥ�)�AOUTPUT�A���סA����Ϥj�p�A����ϭȽd��
		calcHist(&bgr_planes[2], 1, 0, noArray(), hist_r, 1, &histSize, &histRange); //�ӷ��Ӥ��A�Ӥ��ƶq�ACHANNEL�A�B�n(1�ĥ� 0���ĥ�)�AOUTPUT�A���סA����Ϥj�p�A����ϭȽd��
		normalize(hist_b, hist_b, 0, src.rows, NORM_MINMAX);//���W��(�H�̰��������̰��I) //NORM_MINMAX�G��ܪ����W�Ƥ�k 389�G�̰� 0�G�̧C
		normalize(hist_g, hist_g, 0, src.rows, NORM_MINMAX);
		normalize(hist_r, hist_r, 0, src.rows, NORM_MINMAX);
		// Draw the histogram
		int hist_w = 512, hist_h = 400, bin_w = (double)hist_w / histSize + 0.5;
		//hist_b
		global_temp_mat[0]=Mat(hist_h, hist_w, CV_8U, Scalar(255)); //�ϰ� �ϼe ���  Scalar(255)�G�|�O���զ�(����255)
		for (int i = 0; i < histSize; i++) {
			line(global_temp_mat[0], Point(bin_w * i, hist_h), Point(bin_w * i, hist_h - hist_b.at<float>(i)), Scalar(0)); //�e�u *�ϬO���W�����I�G�ѩ����W�e
		}
		//hist_g
		global_temp_mat[1] = Mat(hist_h, hist_w, CV_8U, Scalar(255)); //�ϰ� �ϼe ���  Scalar(255)�G�|�O���զ�(����255)
		for (int i = 0; i < histSize; i++) {
			line(global_temp_mat[1], Point(bin_w * i, hist_h), Point(bin_w * i, hist_h - hist_g.at<float>(i)), Scalar(0)); //�e�u *�ϬO���W�����I�G�ѩ����W�e
		}
		//hist_r
		global_temp_mat[2] = Mat(hist_h, hist_w, CV_8U, Scalar(255)); //�ϰ� �ϼe ���  Scalar(255)�G�|�O���զ�(����255)
		for (int i = 0; i < histSize; i++) {
			line(global_temp_mat[2], Point(bin_w * i, hist_h), Point(bin_w * i, hist_h - hist_r.at<float>(i)), Scalar(0)); //�e�u *�ϬO���W�����I�G�ѩ����W�e
		}
		//return to c#
		dstBufferB = global_temp_mat[0].data;
		dstBufferG = global_temp_mat[1].data;
		dstBufferR = global_temp_mat[2].data;
		
	}
}

//CH3_���ƪ���ϳB�z(equalizeHist)
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

//CH2_���ܪ��e���(change the aspect ratio)
	//xtimes �Gx�b��j����(double,>0.1)
	//ytimes �Gx�b��j����(double,>0.1)
	//isfullsize �G�O����j�p�O�_�H�۩�j�Y�p�ӧ��� (true�G�H�۷s�ϧ��ܤj�p�Afalse�G�����ܤj�p�A�i�����]��true)
IMGFUNC_API void changeImageSize(unsigned char* imageBuffer, int width, int height, double xtimes, double ytimes, bool isfullsize, int& dst_width, int& dst_height, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		/*
		Mat dst;
		Mat M = (Mat_<double>(2, 3) << xtimes, 0, 0, 0, ytimes, 0); // prepare matrix 2->colunm�� 3->row�ơA���W�쥪�U���W�줤�U
		if (isfullsize) {
			dst = Mat::zeros(src.rows * xtimes, src.cols * ytimes, CV_8UC3);
			Size mysize = dst.size();
			warpAffine(src, dst, M, mysize); //size�i�H���������k (ex�G���e��1/3�GorgImg.size()/3)
		}
		else {
			warpAffine(src, dst, M, src.size()); // call opencv's affine transform
		}*/
		Mat dst;
		int newCols = (int)(((double)src.cols) * xtimes);
		int newRows = (int)(((double)src.rows) * ytimes);
		Size dstSize(newCols, newRows) ;
		resize(src, dst, dstSize, 0, 0, INTER_LINEAR);
		//return to c#
		dst_width = newCols;
		dst_height= newRows;
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
		
	}
}

//CH2_����(Rotate)
	//angle �G���ɰw����angle��(double)
IMGFUNC_API void Rotate(unsigned char* imageBuffer, int width, int height, double angle, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat dst;
		double rad = PI * angle / 180.0; // degree to radian
		Mat M = (Mat_<double>(2, 3) << cos(rad), -sin(rad), 0, sin(rad), cos(rad), 0); // prepare matrix 2->colunm�� 3->row�ơA���W�쥪�U���W�줤�U
		warpAffine(src, dst, M, src.size()); // call opencv's affine transform
		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

//CH2_�ŧ�(Shear)
	//xshear �G�����ŧε{�� (double)
	//yshear �G�����ŧε{�� (double)
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

//CH2_��g(Reflect)
	//isReflectAboutXaxis�Gtrue->�W�U��g false->���W�U��g
	//isReflectAboutYaxis�Gtrue->���k��g false->�����k��g
IMGFUNC_API void Reflect(unsigned char* imageBuffer, int width, int height, bool isReflectAboutXaxis, bool isReflectAboutYaxis, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat dst,M;
		if (isReflectAboutXaxis)
			if (isReflectAboutYaxis)
				M = (Mat_<double>(2, 3) << -1, 0, src.cols, 0, -1, src.rows); //�W�U���k��g
			else
				M = (Mat_<double>(2, 3) << 1, 0, 0, 0, -1, src.rows); //�W�U��g
		else if(isReflectAboutYaxis)
			M = (Mat_<double>(2, 3) << -1, 0, src.cols, 0, 1, 0); //���k��g
		else 
			M = (Mat_<double>(2, 3) << 1, 0, 0, 0, 1, 0); //��������
		warpAffine(src, dst, M, src.size());

		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

//CH4_�W�v��ϧνվ�(�϶V�����V�C�W) ----�\��禡----
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

//CH4_DFT transform ----�\��禡----
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

//CH4_DFT_BGR transform ----�\��禡----
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

//IDFT transform ----�\��禡----
Mat myIDFT(Mat& F)
{
	Mat planes[2];
	swapFreq(F);
	idft(F, F, DFT_SCALE);
	split(F, planes);
	return planes[0].clone();
}

//IDFT_BGR transform ----�\��禡----
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

//CH4_���o�W�v��T�� ----�\��禡----
	//��Ϸ�input�A�^�ǥi�����q�Ϫ�Mat
Mat getFrequencyDomainInformation_internalFunc(Mat& src) {
	if (!src.empty()) {
		src.convertTo(src, CV_32F, 1.f / 255);
		Mat F = myDFT(src); //F�G�W�v�쪺��
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

//CH4_���o�W�v��T��(getFrequencyDomainInformation)
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

//CH4_�z�Q�C�q�o�i�� ----�\��禡----
void IdealLowPassFilter(Mat& F, int d0)
{
	Mat H(F.rows, F.cols, CV_32FC2, Scalar(0, 0));
	circle(H, Point(H.cols / 2, H.rows / 2), d0, Scalar::all(1), -1);
	F = F.mul(H);
}

//CH4_�z�Q���q�o�i�� ----�\��禡----
void IdealHighPassFilter(Mat& F, int d0)
{
	Mat H(F.rows, F.cols, CV_32FC2, Scalar(1, 1));
	circle(H, Point(H.cols / 2, H.rows / 2), d0, Scalar::all(0), -1);
	F = F.mul(H);
}

//CH4_�����C�q�o�i�� ----�\��禡----
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

//CH4_�������q�o�i�� ----�\��禡----
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

//CH4_Butterworth�C�q�o�i�� ----�\��禡----
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

//CH4_Butterworth���q�o�i�� ----�\��禡----
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

//CH4_(�z�Q/����)(���q/�C�q)�o�i��(idealOrGaussianPassFilter)
	//isIdeal�Gtrue->�z�Q�o�i��,false->�����o�i��
	//isHighPass�Gtrue->���q,false->�C�q
	//d0�G�v�T�j�p�Ѽ� (int �̤p1)
	//isAddOri�Gtrue->�̫�A�[�W��ϡAfalse->�º�����o�i�᪺�Ϥ�
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

//CH4_Butterworth(���q/�C�q)�o�i��(butterworthPassFilter)
	//isHighPass�Gtrue->���q,false->�C�q
	//d0�G�v�T�j�p�Ѽ� (int,�̤p1)
	//n�G�v�T�j�p�Ѽ� (float,1->����,�ʤ@�ǴN�t�ܦh)
	//isAddOri�Gtrue->�̫�A�[�W��ϡAfalse->�º�����o�i�᪺�Ϥ�
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
//CH5_----�A���ʤ������o�i�����\��禡----
void maxFilter(Mat& src, Mat& dst, int size) {
	Mat element = getStructuringElement(MORPH_RECT, Size(2 * size + 1, 2 * size + 1), Point(size, size)); //����filter
	dilate(src, dst, element); //���Ȫ��@��
}
//CH5_----�A���ʤ������o�i�����\��禡----
void minFilter(Mat& src, Mat& dst, int size)
{
	Mat element = getStructuringElement(MORPH_RECT, Size(2 * size + 1, 2 * size + 1), Point(size, size));
	erode(src, dst, element); //�I�k
}
//CH5_adaptiveMedianFilte �歱_�A���ʤ������o�i��(adaptiveMedianFilter) ----�\��禡----
Mat adaptiveMedianFilter(Mat& Zxy, int s_max)
{
	//allocate memory for storing min, median, and max filters
	int numSize = (s_max - 3) / 2 + 1; //3�O�ۤv�w �q3�}�l 3*3 5*5 7*7
	Mat* Zmin = new Mat[numSize];
	Mat* Zmed = new Mat[numSize];
	Mat* Zmax = new Mat[numSize];
	//get results of min, median, and max filters
	int boxSize = 3;
	int pos;
	for (pos = 0; pos < numSize; pos++, boxSize += 2) { //�]3*3 5*5 7*7�ӦU�ص��G
		minFilter(Zxy, Zmin[pos], boxSize);
		medianBlur(Zxy, Zmed[pos], boxSize);
		maxFilter(Zxy, Zmax[pos], boxSize);
	}
	//Adaptive median filter
	Mat rlt = Mat(Zxy.size(), CV_8UC1);
	for (int r = 0; r < Zxy.rows; r++) { // for every row
		for (int c = 0; c < Zxy.cols; c++) { // for every column //��C���I
		// Level A
			boxSize = 3; //�@�}�l�G3*3
			while (boxSize <= s_max) {
				pos = (boxSize - 3) / 2;
				int A1 = Zmed[pos].at<uchar>(r, c) - Zmin[pos].at<uchar>(r, c);
				int A2 = Zmed[pos].at<uchar>(r, c) - Zmax[pos].at<uchar>(r, c);
				if ((A1 > 0) && (A2 < 0)) break;
				else boxSize += 2;
			}
			if (boxSize > s_max) {  //��ܧ䤣��
				rlt.at<uchar>(r, c) = Zxy.at<uchar>(r, c);  //rlt�G�n�^�Ǫ����G
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

//CH5_adaptiveMedianFilter_BGR�A���ʤ������o�i��(adaptiveMedianFilter)
	//s_max�GFilter kernel�j�p (�n�_��,int)
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

//CH5_�X�󥭧��o�i�� KernelSize �o�i��kernel = KernelSize * KernelSize (�i��������*���� ���i0*0) 
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
					//�]kernel �P�_Channel�O�h�� �]�P�_maxValue��minValue
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

//CH5_�թM�����o�i�� KernelSize �o�i��kernel = KernelSize * KernelSize (�i��������*���� ���i0*0) 
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
					//�]kernel �P�_Channel�O�h�� �]�P�_maxValue��minValue
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

//CH5_�ϽթM�����o�i�� KernelSize �o�i��kernel = KernelSize * KernelSize (�i��������*���� ���i0*0) 
	//Q�G�v�T�{��(Q>1�G�ѨM�����I�AQ<-1�G�ѨM�����I,�ifloat)
IMGFUNC_API void counterHarmonicMeanFilter(unsigned char* imageBuffer, int width, int height, int KernelSize,float Q, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		double tempTotal_Denominator = 0; //�����`�M
		double tempTotal_Molecular = 0; //���l�`�M
		int channelNum = src.channels();
		Mat dst = src.clone();
		for (int ch = 0; ch < channelNum; ch++) {
			for (int row = 0; row < src.rows; row++) {
				for (int column = 0; column < src.cols; column++) {
					//�]kernel �P�_Channel�O�h�� �]�P�_maxValue��minValue
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

//CH6_���ܥ��� (changeIlluminant)  ----�\��禡----
Mat changeIlluminant(Mat& src, Scalar_<float> srcIll, Scalar_<float> dstIll) {
	Mat xyz, dst;
	//Generate transform matrix
	Scalar_<float> ratio(dstIll[0] / srcIll[0],
		dstIll[1] / srcIll[1],
		dstIll[2] / srcIll[2]);
	Mat ratioMat(src.size(), CV_32FC3, ratio);
	//Convert colorspace
	src.convertTo(dst, CV_32FC3, 1.f / 255);
	cvtColor(dst, xyz, COLOR_BGR2XYZ);
	xyz = xyz.mul(ratioMat);
	cvtColor(xyz, dst, COLOR_XYZ2BGR);
	return dst;
}

//CH6_�p����� ----�\��禡----
Scalar_<float> calLightSource(Mat& src) {
	Scalar_<float> ill(0.0f, 0.0f, 0.0f);
	Mat xyz;
	cvtColor(src, xyz, COLOR_BGR2XYZ);
	//split(dst, planes);
	ill = mean(xyz);
	ill[0] = ill[0] / ill[1] * 100;
	ill[2] = ill[2] / ill[1] * 100;
	ill[1] = 100;
	return ill;
}

//CH6_���ܥ���(�q�T�w�X�ӥ����D) changeIlluminantFromModel
	//mode�G�Ҧ� (0->ILL_A�A1->ILL_D50�A2->ILL_D55�A3->ILL_D65�A��L->ILL_D75)
IMGFUNC_API void changeIlluminantFromModel(unsigned char* imageBuffer, int width, int height,int mode, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Scalar_<float> oriILL = calLightSource(src);
	Scalar_<float> dstIll;
	switch (mode) {
		case 0: //ILL_A
			dstIll=Scalar_<float>(ILL_A);
			break;
		case 1: //ILL_D50
			dstIll = Scalar_<float>(ILL_D50);
			break;
		case 2: //ILL_D55
			dstIll = Scalar_<float>(ILL_D55);
			break;
		case 3: //ILL_D65
			dstIll = Scalar_<float>(ILL_D65);
			break;
		default: //ILL_D75
			dstIll = Scalar_<float>(ILL_D75);
			break;
	}
	Mat dst= changeIlluminant(src, oriILL, dstIll);
	global_temp_mat[0] = dst.clone();
	dstBuffer = global_temp_mat[0].data;
}

//CH6_���ܥ���(�ۤv��X,Z��) changeIlluminantFromCustomizeXZ
	//x�Gx��E��
	//z�Gz��E��
IMGFUNC_API void changeIlluminantFromCustomizeXZ(unsigned char* imageBuffer, int width, int height, int x, int z, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Scalar_<float> oriILL = calLightSource(src);
	Scalar_<float> dstIll((float)x,100.0,(float)z);
	Mat dst = changeIlluminant(src, oriILL, dstIll);
	global_temp_mat[0] = dst.clone();
	dstBuffer = global_temp_mat[0].data;
}

//CH6_�վ㹡�M��
	//rate�G���M�׭��� (double)
IMGFUNC_API void changeSaturation(unsigned char* imageBuffer, int width, int height, double rate, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Mat dst;
	Mat hsv, hsvPlanes[3];
	//Get HSV planes
	cvtColor(src, hsv, COLOR_BGR2HSV);
	split(hsv, hsvPlanes);
	//Generate the image of saturation * rate
	hsvPlanes[1] *= rate;
	merge(hsvPlanes, 3, hsv);
	cvtColor(hsv, dst, COLOR_HSV2BGR);
	global_temp_mat[0] = dst.clone();
	dstBuffer = global_temp_mat[0].data;
}

//CH6_���oCMY��m���� ----�\��禡----
Mat* getCMYPlane(Mat src) {
	Mat bgr[3], cmy[3];
	split(src, bgr);
	cmy[0] =255- bgr[2];
	cmy[1] =255- bgr[1];
	cmy[2] =255- bgr[0];
	return cmy;
}

//CH6_���o��m����(B,G,R,C,M,Y��@)(����ܷ|�O�Ǧ�A��ܸӦ�m���q)
	//color�G��ܬY��m������(B:0,G:1,R:2,C:3,M:4,Y:5�M��L int)
IMGFUNC_API void getColorPlane(unsigned char* imageBuffer, int width, int height, int color, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Mat bgr[3];
	Mat dst;
	Mat* cmy = getCMYPlane(src);
	split(src, bgr);
	switch (color) {
	case 0: //B 0
		dst = bgr[0];
		break;
	case 1: //G 1
		dst = bgr[1];
		break;
	case 2: //R 2
		dst = bgr[2];
		break;
	case 3: //C 3
		dst = cmy[0];
		break;
	case 4: //M 4
		dst = cmy[0];
		break;
	case 5: //Y 5
		dst = cmy[1];
		break;
	default: //Y 5
		dst = cmy[2];
		break;
	}
	global_temp_mat[0] = dst.clone();
	dstBuffer = global_temp_mat[0].data;
}
//CH6_���o��@�Φh����m���Ϥ�(B,G,R���ƿ�AC,M,Y�����)(�i����ءGBGR�@�ؽƿ�ACMY�@�س��) (CMY���ܥu��@����@�ӳ�)
	//color�G2�i������ܬO�_�t���Ӧ⪺���� 4��bit�A�N�q�p�U�G0bit->�O�_R/Y�A1bit->�O�_G/M�A2bit->�O�_B/C�A3bit->�O�_BGR�t��(1->BGR,0->CMY) 
IMGFUNC_API void getSingleOrMultiColorImage(unsigned char* imageBuffer, int width, int height, int color, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Mat bgr[3];
	Mat dst;
	Mat* cmy = getCMYPlane(src);
	Mat tmp[3];
	bool isHasCMY = false;
	split(src, bgr);
	if ((color>>3) & 1){ //BGR
		for (int tempBit = 0; tempBit < 3; tempBit++) {
			((color >> tempBit) & 0x01) ? tmp[2 - tempBit] = bgr[2 - tempBit].clone() : tmp[2 - tempBit] = Mat::zeros(src.size(), CV_8U);
		}
	}
	else { //CMY
		for (int tempBit = 0; tempBit < 3; tempBit++) {
			if ((color >> tempBit) & 0x01) {
				switch (tempBit)
				{
					case 0: //Y
						tmp[0] = Mat::zeros(src.size(), CV_8U);
						tmp[1] = cmy[2];
						tmp[2] = cmy[2];
						break;
					case 1: //M
						tmp[0] = cmy[1];
						tmp[1] = Mat::zeros(src.size(), CV_8U);
						tmp[2] = cmy[1];
						break;
					case 2: //C
						tmp[0] = cmy[0];
						tmp[1] = cmy[0];
						tmp[2] = Mat::zeros(src.size(), CV_8U);
						break;
					default: //C
						tmp[0] = cmy[0];
						tmp[1] = cmy[0];
						tmp[2] = Mat::zeros(src.size(), CV_8U);
						break;
				}
				isHasCMY = true;
				break;
			}
		}
		if (!isHasCMY) {
			for(int i=0;i<3;i++)
				tmp[i] = Mat::zeros(src.size(), CV_8U);
		}
	}
	merge(tmp, 3, dst);
	global_temp_mat[0] = dst.clone();
	dstBuffer = global_temp_mat[0].data;
}

//CH6_��m�ഫ(colorTransformation)
	//k�GnewBGR=BGR*k (k����쥻��m)
IMGFUNC_API void colorTransformation(unsigned char* imageBuffer, int width, int height, float k, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Mat bgr[3];
	Mat dst;
	split(src, bgr);
	for (int i = 0; i < 3; i++)
	{
		bgr[i].convertTo(bgr[i], CV_32FC3, 1.f / 255);
		bgr[i] = bgr[i] * k;
	}
	merge(bgr, 3, dst);
	global_temp_mat[0] = dst.clone();
	dstBuffer = global_temp_mat[0].data;
}

//CH6_���o�m�����(colorSlicing)
	//lowerH�BlowerS�BlowerV�G����m�d�򪺤U��(�C�󦹪�HSV���|�Q���)
	//upperH�BupperS�BupperV�G����m�d�򪺤W��(���󦹪�HSV���|�Q���)
IMGFUNC_API void colorSlicing(unsigned char* imageBuffer, int width, int height, int lowerH, int lowerS, int lowerV, int upperH, int upperS, int upperV, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	Mat hsv;
	Mat dst,catchArea;
	Scalar lowerBound(lowerH, lowerS, lowerV);
	Scalar upperBound(upperH, upperS, upperV);
	cvtColor(src, hsv, COLOR_BGR2HSV);
	inRange(hsv, lowerBound, upperBound, catchArea);
	cvtColor(hsv, dst, COLOR_HSV2BGR);
	bitwise_and(dst, dst, dst, catchArea);

	global_temp_mat[0] = dst.clone();
	dstBuffer = global_temp_mat[0].data;
}

//CH6_canny����t����(cannyEdgeDetection)
	//lowerThreshold�G�C�󦹭ȴN���Q�襤
	//upperThreshold�G���󦹭ȴN���Q�襤
IMGFUNC_API void cannyEdgeDetection(unsigned char* imageBuffer, int width, int height, int lowerThreshold, int upperThreshold, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) { // Read image success
		Mat edge, dst;
		//Retrieve edge mask using canny method
		Canny(src, edge, lowerThreshold, upperThreshold);
		src.copyTo(dst, edge);
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
	
}

//CH6_morphologyEx���v���B�z(morphologicalOperation)
	//mode�G���morphologyEx���Ҧ�(0�GDilation, 1�GErosion, 2�Ggradient, 3�GOpen, 4�GClose, 5�GTop Hat, 6�P��L�GBlack Hat)
	//size�Gkernel�O�X���X (�u��kernel�j�p=2*size+1)
IMGFUNC_API void morphologicalOperation(unsigned char* imageBuffer, int width, int height, int mode,int size, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) { // Read image success
		Mat dst;
		Mat element = getStructuringElement(MORPH_RECT, Size(2 * size + 1, 2 * size + 1), Point(size, size));
		switch (mode)
		{
		case 0:
			dilate(src, dst, element);
			break;
		case 1:
			erode(src, dst, element);
			break;
		case 2:
			morphologyEx(src, dst, MORPH_GRADIENT, element);
			break;
		case 3:
			morphologyEx(src, dst, MORPH_OPEN, element);
			break;
		case 4:
			morphologyEx(src, dst, MORPH_CLOSE, element);
			break;
		case 5:
			morphologyEx(src, dst, MORPH_TOPHAT, element);
			break;
		case 6:
			morphologyEx(src, dst, MORPH_BLACKHAT, element);
			break;
		default:
			morphologyEx(src, dst, MORPH_BLACKHAT, element);
			break;
		}
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}
//��L�\��_�`���o��_�J��(CommonFilters-sculpture) ----�\��禡----
Mat sculpture(Mat src) {
	Mat dst(src.size(), CV_8UC3);
	for (int y = 1; y < src.rows - 1; y++)
	{
		uchar* p0 = src.ptr<uchar>(y);
		uchar* p1 = src.ptr<uchar>(y + 1);

		uchar* q1 = dst.ptr<uchar>(y);
		for (int x = 1; x < src.cols - 1; x++)
		{
			for (int i = 0; i < 3; i++)
			{
				int tmp1 = p0[3 * (x - 1) + i] - p1[3 * (x + 1) + i] + 128;//�J��
				if (tmp1 < 0)
					q1[3 * x + i] = 0;
				else if (tmp1 > 255)
					q1[3 * x + i] = 255;
				else
					q1[3 * x + i] = tmp1;
			}
		}
	}
	return dst;
}
//��L�\��_�`���o��_�B�J(CommonFilters-elief) ----�\��禡----
Mat Relief(Mat src) {
	Mat dst(src.size(), CV_8UC3);
	for (int y = 1; y < src.rows - 1; y++)
	{
		uchar* p0 = src.ptr<uchar>(y);
		uchar* p1 = src.ptr<uchar>(y + 1);

		uchar* q0 = dst.ptr<uchar>(y);
		for (int x = 1; x < src.cols - 1; x++)
		{
			for (int i = 0; i < 3; i++)
			{
				int tmp0 = p1[3 * (x + 1) + i] - p0[3 * (x - 1) + i] + 128;//�B�J
				if (tmp0 < 0)
					q0[3 * x + i] = 0;
				else if (tmp0 > 255)
					q0[3 * x + i] = 255;
				else
					q0[3 * x + i] = tmp0;
			}
		}
	}
	return dst;
}
//��L�\��_�`���o����(cannyEdgeDetection)
	//mode�G�o��Ҧ�(0�G�J��A1�G�B�J)
IMGFUNC_API void CommonFilters(unsigned char* imageBuffer, int width, int height, int mode, void*& dstBuffer) {
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) { // Read image success
		Mat dst;
		Mat mask;
		switch (mode)
		{
		case 0:
			dst = sculpture(src);
			break;
		case 1:
			dst = Relief(src);
			break;
		default:
			dst = Relief(src);
			break;
		}
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}

