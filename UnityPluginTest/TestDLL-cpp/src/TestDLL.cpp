// ReSharper disable CppClangTidyClangDiagnosticOldStyleCast
// ReSharper disable CppClangTidyCertMsc51Cpp
// ReSharper disable CppCStyleCast
// ReSharper disable CppParameterMayBeConst
#include <cstdint>
#include <cstdlib>
#include <ctime>

using uint8   = uint8_t;
using uint16  = uint16_t;
using uint32  = uint32_t;
using uint64  = uint64_t;
using float32 = float;
using float64 = double;

using uint = uint32;

extern "C" {

	__declspec(dllexport) void  dllRandomSeed()                                     { srand((uint32)time(nullptr)); }
	__declspec(dllexport) int   dllRandomInt  (int   low = 0,    int   high = 10)   { return rand() % (high - low + 1) + low; }
	__declspec(dllexport) uint  dllRandomUInt (uint  low = 0u,   uint  high = 10u)  { return rand() % (high - low + 1) + low; }
	__declspec(dllexport) float dllRandomFloat(float low = 0.0f, float high = 1.0f) { return (float32)((float64)rand() / (float64)RAND_MAX) * (high - low) + low; }

}
