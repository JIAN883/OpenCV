// imgFunc.cpp : 定義 DLL 應用程式的匯出函式。
//
#include "pch.h"
#include "imgFunc.h"
#include <opencv2/opencv.hpp>
using namespace cv;

// This is an example of an exported function.
IMGFUNC_API void showImage(int& ptr, char *filename)
{
	Mat img = imread(filename);
	ptr = (int)img.data;

	//Mat src;
	//src = imread(filename, flags);
	//if (src.data) {
	//	imshow(label_name, src);
	//	imgPtr = src.data;
	//}
}



IMGFUNC_API void test(void *image)
{
	Mat *temp = (Mat *)image;
	imshow("Image1", *temp);
}