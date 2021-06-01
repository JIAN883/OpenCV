// imgFunc.cpp : �w�q DLL ���ε{�����ץX�禡�C
//
#include "pch.h"
#include "imgFunc.h"
#include <opencv2/opencv.hpp>
using namespace cv;
// This is an example of an exported function.
IMGFUNC_API void showImage(char *filename, void *imgPtr)
{
	Mat src;
	src = imread(filename, IMREAD_REDUCED_COLOR_2);
	if (src.data) {
		//imshow("Image", src);

		imgPtr = src.data;
	}
}

IMGFUNC_API void test(void *image)
{
	Mat *temp = (Mat *)image;
	imshow("Image1", *temp);
}