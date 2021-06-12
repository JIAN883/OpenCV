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
IMGFUNC_API void MaxOrMinFilter(unsigned char* imageBuffer, int width, int height, int mode, float KernelSize);
IMGFUNC_API void LaplicianFilter(unsigned char* imageBuffer, int width, int height, bool isAddOriImage);
IMGFUNC_API void getUnsharpInformation(unsigned char* imageBuffer, int width, int height);
IMGFUNC_API void HighboostFilter(unsigned char* imageBuffer, int width, int height, float k);
IMGFUNC_API void horizontalIntensityFilter(unsigned char* imageBuffer, int width, int height, bool isHorizontal, bool isAddOriImage);
IMGFUNC_API void thresholdProcessing(unsigned char* imageBuffer, int width, int height, double thresh, double maxval);
IMGFUNC_API void negative(unsigned char* imageBuffer, int width, int height);
IMGFUNC_API void brightProcessing_log(unsigned char* imageBuffer, int width, int height, float c);
IMGFUNC_API void brightProcessing_power(unsigned char* imageBuffer, int width, int height, float c, float gamma);