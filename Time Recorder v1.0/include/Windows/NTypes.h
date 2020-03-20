/*!doc * \file NTypes.h \brief Defines types and macros used in Neurotechnology components. */

/*!doc 
|******************************************************************************|
|*                                                                            *|
|*                          Neurotechnology Core 2.4                          *|
|*                                                                            *|
|* NTypes.h                                                                   *|
|* Types and various defines definition                                       *|
|*                                                                            *|
|* Copyright (C) 2005-2008 Neurotechnology                                    *|
|*                                                                            *|
\******************************************************************************/

#ifndef N_TYPES_H_INCLUDED
#define N_TYPES_H_INCLUDED

/*!doc  C++ detection */
#ifdef __cplusplus
#define N_CPP /*!doc < Defined if compiling as C++ code. */
#endif

#ifdef N_CPP
extern "C"
{
#endif

/*!doc  Debug detection */
#ifdef _DEBUG
#define N_DEBUG /*!doc < Defined if compiling in debug mode. */
#endif

/*!doc  Static library detection */
#ifdef _LIB
#define N_LIB /*!doc < Defined if compiling static library. */
#endif

/*!doc  Windows detection */
#if defined(_WIN32) || defined(WIN32) || defined(_WIN64) || defined(WIN64)
#define N_WINDOWS /*!doc < Defined if compiling for Windows. */
#endif

/*!doc  Linux detection */
#ifdef __linux__
#define N_LINUX /*!doc < Defined if compiling for Linux. */
#endif

/*!doc  Mac detection */
#ifdef __APPLE__
#define N_MAC /*!doc < Defined if compiling for Mac OS. */
#endif

#ifdef _AIX
#define N_AIX
#endif

#ifndef N_DOCUMENTATION
#ifndef N_WINDOWS
#define N_NO_UNICODE /*!doc < Defined if compiling without Unicode support. */
#endif
#endif

/*!doc  Unicode detection */
#if defined(N_WINDOWS) && (defined(_UNICODE) || defined(UNICODE))
#define N_UNICODE
#endif

/*!doc  Compiler detection */

#ifdef _MSC_VER
#if (_MSC_VER >= 1300)
#define N_MSVC /*!doc < Defined if compiling with Microsoft Visual C++. */
#else
#define N_NO_INT_64 /*!doc < Defined if compiling for platform without 64-bit integer types support. */
#endif
#endif

#ifdef __GNUC__
#define N_GCC /*!doc < Defined if compiling with GCC. */
#endif

#if defined(__STDC__) && !defined(N_GCC)
#define N_ANSI_C /*!doc < Defined if ANSI C language compliance is enabled in compiler. */
#endif

/*!doc  Struct packing/alignment */
#ifdef N_GCC
#define N_PACKED __attribute__((__packed__))
#else
#define N_PACKED
#endif

/*!doc  Deprecation */
#if defined(__GNUC__) && (__GNUC__ - 0 > 3 || (__GNUC__ - 0 == 3 && __GNUC_MINOR__ - 0 >= 2))
#define N_DEPRECATED(message) __attribute__ ((deprecated))
#elif defined(N_MSVC)
#define N_DEPRECATED(message) __declspec(deprecated(message))
#else
#define N_DEPRECATED(message)
#endif

/*!doc  Processor detection */

#if defined(__POWERPC__) || defined(_POWER)
#define N_BIG_ENDIAN /*!doc < Defined if compiling for big-endian processor architecture. */
#endif

#if defined(_M_IX86) || defined(__i386__) || defined(_M_X64) || defined(__x86_64__) || defined(__POWERPC__)
#define N_FAST_FLOAT /*!doc < Defined if CPU has floating-point instructions */
#endif

#if defined(_M_X64) || defined(__x86_64__)
#define N_64 /*!doc < Defined if compiling for 64-bit architecture. */
#endif

/*!doc #define N_NO_FLOAT */
/*!doc #define N_NO_INT_64 */

#if defined(N_64) && defined(N_NO_INT_64)
#error N_64 and N_NO_INT_64 defined simultaneously
#endif

/*!doc  Integer types */

#ifdef N_MSVC

/*!doc < 8-bit unsigned integer (byte). */
typedef unsigned __int8  NUInt8;
/*!doc < 8-bit signed integer (signed byte). */
typedef signed   __int8  NInt8;
/*!doc < 16-bit unsigned integer (unsigned short). */
typedef unsigned __int16 NUInt16;
/*!doc < 16-bit signed integer (short). */
typedef signed   __int16 NInt16;
/*!doc < 32-bit unsigned integer (unsigned int). */
typedef unsigned __int32 NUInt32;
/*!doc < 32-bit signed integer (int). */
typedef signed   __int32 NInt32;

/*!doc < Minimum value for #NUInt8. */
#define N_UINT8_MIN 0x00ui8
/*!doc < Maximum value for #NUInt8. */
#define N_UINT8_MAX 0xFFui8
/*!doc < Minimum value for #NInt8. */
#define N_INT8_MIN 0x80i8
/*!doc < Maximum value for #NInt8. */
#define N_INT8_MAX 0x7Fi8
/*!doc < Minimum value for #NUInt16. */
#define N_UINT16_MIN 0x0000ui16
/*!doc < Maximum value for #NUInt16. */
#define N_UINT16_MAX 0xFFFFui16
/*!doc < Minimum value for #NInt16. */
#define N_INT16_MIN 0x8000i16
/*!doc < Maximum value for #NInt16. */
#define N_INT16_MAX 0x7FFFi16
/*!doc < Minimum value for #NUInt32. */
#define N_UINT32_MIN 0x00000000ui32
/*!doc < Maximum value for #NUInt32. */
#define N_UINT32_MAX 0xFFFFFFFFui32
/*!doc < Minimum value for #NInt32. */
#define N_INT32_MIN 0x80000000i32
/*!doc < Maximum value for #NInt32. */
#define N_INT32_MAX 0x7FFFFFFFi32

#else

typedef unsigned char  NUInt8;
typedef signed   char  NInt8;
typedef unsigned short NUInt16;
typedef signed   short NInt16;
typedef unsigned int   NUInt32;
typedef signed   int   NInt32;

#define N_UINT8_MIN ((NUInt8)0x00u)
#define N_UINT8_MAX ((NUInt8)0xFFu)
#define N_INT8_MIN ((NInt8)0x80)
#define N_INT8_MAX ((NInt8)0x7F)
#define N_UINT16_MIN ((NUInt16)0x0000u)
#define N_UINT16_MAX ((NUInt16)0xFFFFu)
#define N_INT16_MIN ((NInt16)0x8000)
#define N_INT16_MAX ((NInt16)0x7FFF)
#define N_UINT32_MIN 0x00000000u
#define N_UINT32_MAX 0xFFFFFFFFu
#define N_INT32_MIN 0x80000000
#define N_INT32_MAX 0x7FFFFFFF

#endif

#ifndef N_NO_INT_64

#ifdef N_MSVC

/*!doc < 64-bit unsigned integer (unsigned long). Not available on some 32-bit platforms. */
typedef unsigned __int64 NUInt64;
/*!doc < 64-bit signed integer (long). Not available on some 32-bit platforms. */
typedef signed   __int64 NInt64;

/*!doc < Minimum value for #NUInt64. */
#define N_UINT64_MIN 0x0000000000000000ui64
/*!doc < Maximum value for #NUInt64. */
#define N_UINT64_MAX 0xFFFFFFFFFFFFFFFFui64
/*!doc < Minimum value for #NInt64. */
#define N_INT64_MIN 0x8000000000000000i64
/*!doc < Maximum value for #NInt64. */
#define N_INT64_MAX 0x7FFFFFFFFFFFFFFFi64

#else

/*!doc < 64-bit unsigned integer (long). Not available on some 32-bit platforms. */
typedef unsigned long long NUInt64;
/*!doc < 64-bit signed integer (long). Not available on some 32-bit platforms. */
typedef signed   long long NInt64;

/*!doc < Minimum value for #NUInt64. */
#define N_UINT64_MIN 0x0000000000000000ull
/*!doc < Maximum value for #NUInt64. */
#define N_UINT64_MAX 0xFFFFFFFFFFFFFFFFull
/*!doc < Minimum value for #NInt64. */
#define N_INT64_MIN 0x8000000000000000ll
/*!doc < Maximum value for #NInt64. */
#define N_INT64_MAX 0x7FFFFFFFFFFFFFFFll

#endif

#endif

/*!doc  Shorthand integer types */

/*!doc < Same as NUInt8. */
typedef NUInt8 NByte;
/*!doc < Same as NInt8. */
typedef NInt8 NSByte;
/*!doc < Same as NUInt16. */
typedef NUInt16 NUShort;
/*!doc < Same as NInt16. */
typedef NInt16 NShort;
/*!doc < Same as NUInt32. */
typedef NUInt32 NUInt;
/*!doc < Same as NInt32. */
typedef NInt32 NInt;

#ifndef N_NO_INT_64

/*!doc < Same as NUInt64. */
typedef NUInt64 NULong;
/*!doc < Same as NInt64. */
typedef NInt64 NLong;

#endif

/*!doc < Minimum value for #NByte. */
#define N_BYTE_MIN N_UINT8_MIN
/*!doc < Maximum value for #NByte. */
#define N_BYTE_MAX N_UINT8_MAX
/*!doc < Minimum value for #NSByte. */
#define N_SBYTE_MIN N_INT8_MIN
/*!doc < Maximum value for #NSByte. */
#define N_SBYTE_MAX N_INT8_MAX
/*!doc < Minimum value for #NUShort. */
#define N_USHORT_MIN N_UINT16_MIN
/*!doc < Maximum value for #NUShort. */
#define N_USHORT_MAX N_UINT16_MAX
/*!doc < Minimum value for #NShort. */
#define N_SHORT_MIN N_INT16_MIN
/*!doc < Maximum value for #NShort. */
#define N_SHORT_MAX N_INT16_MAX
/*!doc < Minimum value for #NUInt. */
#define N_UINT_MIN N_UINT32_MIN
/*!doc < Maximum value for #NUInt. */
#define N_UINT_MAX N_UINT32_MAX
/*!doc < Minimum value for #NInt. */
#define N_INT_MIN N_INT32_MIN
/*!doc < Maximum value for #NInt. */
#define N_INT_MAX N_INT32_MAX

#ifndef N_NO_INT_64

/*!doc < Minimum value for #NULong. */
#define N_ULONG_MIN N_UINT64_MIN
/*!doc < Maximum value for #NULong. */
#define N_ULONG_MAX N_UINT64_MAX
/*!doc < Minimum value for #NLong. */
#define N_LONG_MIN N_INT64_MIN
/*!doc < Maximum value for #NLong. */
#define N_LONG_MAX N_INT64_MAX

#endif

#ifndef N_NO_FLOAT

/*!doc  Float types */
typedef float NSingle;  /*!doc < Single precision floating point number. */
typedef double NDouble; /*!doc < Double precision floating point number. */

/*!doc < Minimum value for #NSingle. */
#define N_SINGLE_MIN 1.175494351e-38F
/*!doc < Maximum value for #NSingle. */
#define N_SINGLE_MAX 3.402823466e+38F
/*!doc < Epsilon value for #NSingle. */
#define N_SINGLE_EPSILON 1.192092896e-07F
/*!doc < Minimum value for #NDouble. */
#define N_DOUBLE_MIN 2.2250738585072014e-308
/*!doc < Maximum value for #NDouble. */
#define N_DOUBLE_MAX 1.7976931348623158e+308
/*!doc < Epsilon value for #NDouble. */
#define N_DOUBLE_EPSILON 2.2204460492503131e-016

/*!doc  Shorthand float type */
typedef NSingle NFloat; /*!doc < Same as NSingle. */

/*!doc < Minimum value for #NFloat. */
#define N_FLOAT_MIN N_SINGLE_MIN
/*!doc < Maximum value for #NFloat. */
#define N_FLOAT_MAX N_SINGLE_MAX
/*!doc < Epsilon value for #NFloat. */
#define N_FLOAT_EPSILON N_SINGLE_EPSILON

#endif

/*!doc  32-bit boolean value. See also #NTrue and #NFalse. */
typedef int NBoolean;

/*!doc  Boolean constants */
/*!doc < True value for #NBoolean. */
#define NTrue 1
/*!doc < False value for #NBoolean. */
#define NFalse 0

/*!doc  Same as #NBoolean. */
typedef NBoolean NBool;

/*!doc  Character types */

#if defined(N_NO_UNICODE) && defined(N_UNICODE)
#error "N_NO_UNICODE and N_UNICODE defined simultaneously"
#endif

typedef char NAChar; /*!doc < ANSI character (8-bit). */

#ifndef N_NO_UNICODE

/*!doc  Unicode character (16-bit). */
#ifndef _WCHAR_T_DEFINED
typedef NUShort NWChar;
#else
typedef wchar_t NWChar;
#endif

#endif /*!doc  !N_NO_UNICODE */

/*!doc  Char type */

/*!doc  Character type. Either #NAChar or #NWChar (if N_UNICODE is defined). */
#ifdef N_UNICODE
typedef NWChar NChar;
#else
typedef NAChar NChar;
#endif

/*!doc *
 * \brief  Makes either ANSI or Unicode (if N_UNICODE is defined) string or
 *         character constant.
 */
#ifdef N_UNICODE
#define N_T_(text) L##text
#else
#define N_T_(text) text
#endif

#define N_T(text) N_T_(text)

#ifdef N_UNICODE
/*!doc < Picks either ANSI or Unicode (if N_UNICODE is defined) version of the function (with either 'A' or 'W' suffix accordingly). */
#define N_FUNC_AW(name) name##W
/*!doc < Picks either ANSI or Unicode (if N_UNICODE is defined) version of the callback (with either 'A' or 'W' suffix accordingly). */
#define N_CALLBACK_AW(name) name##W
/*!doc < Picks either ANSI or Unicode (if N_UNICODE is defined) version of the struct (with either 'A' or 'W' suffix accordingly). */
#define N_STRUCT_AW(name) name##W
#else
#define N_FUNC_AW(name) name##A 

#define N_CALLBACK_AW(name) name##A 
#define N_STRUCT_AW(name) name##A
#endif

#ifdef WINCE
/*!doc < Defined if compiling for platform without ANSI versions of the functions support. */
#define N_NO_ANSI_FUNC
#ifndef N_UNICODE
#error "N_UNICODE must be defined under Windows CE"
#endif
#endif

#if defined(N_NO_ANSI_FUNC) && !defined(N_UNICODE)
#error "N_NO_ANSI_FUNC defined when N_UNICODE is not defined"
#endif

/*!doc  Size type */
#ifdef N_64

/*!doc *
 * \brief  Platform dependent size type. Unsigned 32-bit integer on 32-bit
 *         platform, unsigned 64-bit integer on 64-bit platform.
 */
typedef NUInt64 NSizeType;

/*!doc < Minimum value for #NSizeType. */
#define N_SIZE_TYPE_MIN N_UINT64_MIN
/*!doc < Maximum value for #NSizeType. */
#define N_SIZE_TYPE_MAX N_UINT64_MAX

#else

/*!doc *
 * \brief  Platform dependent size type. Unsigned 32-bit integer on 32-bit
 *         platform, unsigned 64-bit integer on 64-bit platform.
 */
#ifdef N_MSVC
typedef __w64 NUInt32 NSizeType;
#else
typedef NUInt32 NSizeType;
#endif

/*!doc < Minimum value for #NSizeType. */
#define N_SIZE_TYPE_MIN N_UINT32_MIN
/*!doc < Maximum value for #NSizeType. */
#define N_SIZE_TYPE_MAX N_UINT32_MAX

#endif

/*!doc  Pos type */

#ifndef N_NO_INT_64

/*!doc *
 * \brief  Platform dependent position type. Signed 64-bit (or 32-bit on some
 *         platforms) integer on 32-bit platform, signed 64-bit integer on
 *         64-bit platform).
 */
typedef NInt64 NPosType;

/*!doc < Minimum value for #NPosType. */
#define N_POS_TYPE_MIN N_INT64_MIN
/*!doc < Maximum value for #NPosType. */
#define N_POS_TYPE_MAX N_INT64_MAX

#else

/*!doc *
 * \brief Platform dependent position type. Signed 64-bit (or 32-bit on some
 *        platforms) integer on 32-bit platform, signed 64-bit integer on
 *        64-bit platform).
 */
#ifdef N_MSVC
typedef __w64 NInt32 NPosType;
#else
typedef NInt32 NPosType;
#endif

/*!doc < Minimum value for #NPosType. */
#define N_POS_TYPE_MIN N_INT32_MIN
/*!doc < Maximum value for #NPosType. */
#define N_POS_TYPE_MAX N_INT32_MAX

#endif

#ifndef NULL
	/*!doc < Null value for pointer. */
	#define NULL 0
#endif

/*!doc  Result of a function (same as NInt). See also NErrors.h. */
typedef NInt NResult;

/*!doc  API and callback functions' calling convention */

/*!doc < Defines functions calling convention (stdcall on Windows). */
#ifndef N_API
#if defined(N_WINDOWS) && !defined(UNDER_CE)
#define N_API __stdcall
#else
#define N_API
#endif
#endif

/*!doc < Defined callbacks calling convention (stdcall on Windows). */
#ifndef N_CALLBACK
#ifdef N_WINDOWS
#define N_CALLBACK __stdcall
#else
#define N_CALLBACK
#endif
#endif

/*!doc  Handle */

/*!doc < Pointer to unspecified data (same as void *). */
typedef void * NHandle;

/*!doc  Declares handle with specified name. */
#define N_DECLARE_HANDLE(name) typedef struct name##_ { int unused; } * name;

/*!doc  Rational */

/*!doc  Represents an unsigned rational number. */
typedef struct NURational_
{
	/*!doc < Numerator of this NURational. */
	NUInt Numerator;
	NUInt Denominator; /*!doc < Denominator of this NURational. */
} NURational;

/*!doc  Represents a signed rational number. */
typedef struct NRational_
{
	NInt Numerator;   /*!doc < Numerator of this NRational. */
	NInt Denominator; /*!doc < Denominator of this NRational. */
} NRational;

/*!doc  Specifies access to a file. */
typedef enum NFileAccess_ /*!doc  Flags */
{
	nfaRead = 1,                      /*!doc < Read access to the file. */
	nfaWrite = 2,                     /*!doc < Write access to the file. */
	nfaReadWrite = nfaRead | nfaWrite /*!doc < Read and write access to the file. */
} NFileAccess;

/*!doc  Specifies byte order. */
typedef enum NByteOrder_
{
	nboLittleEndian = 0,        /*!doc < Little-endian byte order. */
	nboBigEndian = 1,           /*!doc < Big-endian byte order. */
#ifdef N_BIG_ENDIAN
	nboSystem = nboBigEndian    /*!doc < System-dependent byte order (either little-endian or big-endian). */
#else
	nboSystem = nboLittleEndian /*!doc < System-dependent byte order (either little-endian or big-endian). */
#endif
} NByteOrder;

/*!doc  Checks if specified byte order is reverse to system byte order. */
#define NIsReverseByteOrder(byteOrder) ((byteOrder) != nboSystem)

/*!doc  Represents a pair of indexes. */
typedef struct NIndexPair_
{
	NInt Index1; /*!doc < First index of this #NIndexPair. */
	NInt Index2; /*!doc < Second index of this #NIndexPair. */
} NIndexPair;

typedef struct NGuid_
{
	NUInt Data1;
	NUShort Data2;
	NUShort Data3;
	NByte Data4[8];
} NGuid;

typedef struct NRange_
{
	NInt From;
	NInt To;
} NRange;

#ifdef N_CPP
}
#endif

#endif /*!doc  !N_TYPES_H_INCLUDED */
