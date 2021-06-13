#pragma once
#pragma once
//¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K¡K
#ifdef IMGFUNC_EXPORTS
#define IMGFUNC_API extern "C" __declspec(dllexport)
#else
#define IMGFUNC_API extern "C" __declspec(dllimport)
#endif
IMGFUNC_API void Blur(unsigned char* imageBuffer, int width, int height, float value);
IMGFUNC_API void GeneratePepperSalt(unsigned char* imageBuffer, int width, int height, float PepperPercent, float SaltPercent);
IMGFUNC_API void MedianFilter(unsigned char* imageBuffer, int width, int height, int KernelSize);
IMGFUNC_API void MaxOrMinFilter(unsigned char* imageBuffer, int width, int height, int mode, int KernelSize, void*& dstBuffer);
IMGFUNC_API void LaplicianFilter(unsigned char* imageBuffer, int width, int height, bool isAddOriImage);
IMGFUNC_API void getUnsharpInformation(unsigned char* imageBuffer, int width, int height, void*& dstBuffer);
IMGFUNC_API void HighboostFilter(unsigned char* imageBuffer, int width, int height, float k, void*& dstBuffer);
IMGFUNC_API void horizontalIntensityFilter(unsigned char* imageBuffer, int width, int height, bool isHorizontal, bool isAddOriImage, void*& dstBuffer);
IMGFUNC_API void thresholdProcessing(unsigned char* imageBuffer, int width, int height, double thresh, double maxval);
IMGFUNC_API void negative(unsigned char* imageBuffer, int width, int height);
IMGFUNC_API void brightProcessing_log(unsigned char* imageBuffer, int width, int height, float c, void*& dstBuffer);
IMGFUNC_API void brightProcessing_power(unsigned char* imageBuffer, int width, int height, float c, float gamma, void*& dstBuffer);
IMGFUNC_API void bitPlaneSlicing(unsigned char* imageBuffer, int width, int height, int bit);
IMGFUNC_API void HistogramProcessing(unsigned char* imageBuffer, int width, int height, int bit, void*& dstBufferB, void*& dstBufferG, void*& dstBufferR);
IMGFUNC_API void equalizeHist(unsigned char* imageBuffer, int width, int height, int mode, void*& dstBuffer);
IMGFUNC_API void changeImageSize(unsigned char* imageBuffer, int width, int height, double xtimes, double ytimes, bool isfullsize, int*& dst_width, int*& dst_height, void*& dstBuffer);
IMGFUNC_API void Rotate(unsigned char* imageBuffer, int width, int height, double angle, void*& dstBuffer);
IMGFUNC_API void Shear(unsigned char* imageBuffer, int width, int height, double xshear, double yshear, void*& dstBuffer);
IMGFUNC_API void Reflect(unsigned char* imageBuffer, int width, int height, bool isReflectAboutXaxis, bool isReflectAboutYaxis, void*& dstBuffer);