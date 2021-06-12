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
IMGFUNC_API void MedianFilter(unsigned char* imageBuffer, int width, int height, float KernelSize);
IMGFUNC_API void MaxOrMinFilter(unsigned char* imageBuffer, int width, int height, int mode, float KernelSize);