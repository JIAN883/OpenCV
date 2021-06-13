// imgFunc.cpp : �w�q DLL ���ε{�����ץX�禡�C
//
#include "pch.h"
#include "imgFunc.h"
#include <opencv2/opencv.hpp>
using namespace cv;
#define PI 3.14159
#define global_size 5
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
		src = 255 - src;
	}
}

//CH3_�G�׽վ�1(Log)
	//c �G�G�׭��v(>1,�i�w�]2,float)
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

//CH3_�G�׽վ�2(Power conversion)
	//c �G�G�׭��v(>=1,�i�w�]1,float)
	//gamma�G���ưѼ�(=1->����, >1->�ܷt, <1->�ܫG,�i�w�]0.5)
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

//CH3_�줸��������(bit plane Slicing)
	//bit�Gbit�h�֪�����(int,�Ȱ�0~7)
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

//CH3_�����(Histogram Processing)
	//
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
IMGFUNC_API void changeImageSize(unsigned char* imageBuffer, int width, int height, double xtimes, double ytimes, bool isfullsize, int*& dst_width, int*& dst_height, void*& dstBuffer)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {

		Mat dst;
		Mat M = (Mat_<double>(2, 3) << xtimes, 0, 0, 0, ytimes, 0); // prepare matrix 2->colunm�� 3->row�ơA���W�쥪�U���W�줤�U
		if (isfullsize) {
			dst = Mat::zeros(src.rows * xtimes, src.cols * ytimes, CV_8UC3);
			Size mysize = dst.size();
			warpAffine(src, dst, M, mysize); //size�i�H���������k (ex�G���e��1/3�GorgImg.size()/3)
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
			M = (Mat_<double>(2, 3) << -1, 0, src.cols, 0, -1, 0); //���k��g
		else 
			M = (Mat_<double>(2, 3) << 1, 0, 0, 0, 1, 0); //��������
		warpAffine(src, dst, M, src.size());

		//return to c#
		global_temp_mat[0] = dst.clone();
		dstBuffer = global_temp_mat[0].data;
	}
}
//�W�v��
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
// DFT transform
Mat myDFT(Mat& f)
{
	Mat F; //frequency data
	Mat padded; //Padded image
	//Pad image to optimal DFT size with 0s
	int m = getOptimalDFTSize(f.rows);
	int n = getOptimalDFTSize(f.cols);
	copyMakeBorder(f, padded, 0, m - f.rows, 0, n - f.cols,
		BORDER_CONSTANT, Scalar::all(0));
	// allocate memory for storing frequency data and doing DFT
	Mat planes[] = { Mat_<float>(padded),
	Mat(padded.size(), CV_32F, 0.0f) };
	merge(planes, 2, F);
	dft(F, F);
	swapFreq(F);
	return F;
}
