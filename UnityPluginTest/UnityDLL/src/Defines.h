#pragma once
#ifndef DEFINES_H
#define DEFINES_H

#if PLUGIN_EXPORT
#	define PLUGIN_API __declspec(dllexport)
#elif PLUGIN_IMPORT
#	define PLUGIN_API __declspec(dllimport)
#else
#	define PLUGIN_API
#endif

#define global_var    static
#define local_persist static
#define internal_func static

#include <cstdint>

using i8  = int8_t;
using i16 = int16_t;
using i32 = int32_t;
using i64 = int64_t;

using u8  = uint8_t;
using u16 = uint16_t;
using u32 = uint32_t;
using u64 = uint64_t;

using f32 = float;
using f64 = double;

#endif
