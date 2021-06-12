// imgFunc.cpp : 定義 DLL 應用程式的匯出函式。
//
#include "pch.h"
#include "imgFunc.h"
#include <opencv2/opencv.hpp>
using namespace cv;
Mat global_temp_mat;//用來當函式呼叫之間的媒介，每次用完記得release
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
		Mat salt_mat = src.clone();
		salt_mat.setTo(255, saltMask); //Add salt noice
		salt_mat.setTo(0, pepperMask); //Add pepper noice
		src = salt_mat.clone();
	}
}

//CH3_中位數濾波器 KernelSize 濾波器kernel = KernelSize * KernelSize
IMGFUNC_API void MedianFilter(unsigned char* imageBuffer, int width, int height, float KernelSize)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		medianBlur(src, src, KernelSize);
	}
}

//CH3_最大值濾波器 mode：0->maxFilter,!=0->minFilter   KernelSize 濾波器kernel = KernelSize * KernelSize (可接受偶數*偶數) 
IMGFUNC_API void MaxOrMinFilter(unsigned char* imageBuffer, int width, int height,int mode, float KernelSize)
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
		src = dst.clone();
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
IMGFUNC_API void getUnsharpInformation(unsigned char* imageBuffer, int width, int height)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat blu, unsharp_mask;
		//Prepare and apply the Laplacian filter
		Mat mask = (Mat_<double>(3, 3) << 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9);
		filter2D(src, blu, src.depth(), mask);
		unsharp_mask = src - blu; //取出特徵(unsharp mask)
		src = unsharp_mask.clone();
	}
}

//CH3_高增幅濾波器(Highboost filter)
	//k：鈍化倍數 float(>=0)
IMGFUNC_API void HighboostFilter(unsigned char* imageBuffer, int width, int height,float k)
{
	Mat src = Mat(height, width, CV_8UC3, imageBuffer);
	if (!src.empty()) {
		Mat blu, unsharp_mask, sharp_mat;
		//Prepare and apply the Laplacian filter
		Mat mask = (Mat_<double>(3, 3) << 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9, 1. / 9);
		filter2D(src, blu, src.depth(), mask);
		unsharp_mask = src - blu; //取出特徵(unsharp mask)
		sharp_mat = src + k * unsharp_mask;
		src = sharp_mat.clone();
	}
}


