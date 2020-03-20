/*!doc * \file NErrors.h \brief  Defines error codes used in Neurotechnology components. */

/*!doc 
|******************************************************************************|
|*                                                                            *|
|*                          Neurotechnology Core 2.4                          *|
|*                                                                            *|
|* NErrors.h                                                                  *|
|* Error codes definition                                                     *|
|*                                                                            *|
|* Copyright (C) 2005-2008 Neurotechnology                                    *|
|*                                                                            *|
\******************************************************************************/

#ifndef N_ERRORS_H_INCLUDED
#define N_ERRORS_H_INCLUDED

#include <NTypes.h>

#ifdef N_CPP
extern "C"
{
#endif

#ifndef N_NO_ERROR_CODES
/*!doc < No error. */
#define N_OK                                     0
/*!doc < Unspecified error has occurred. */
#define N_E_FAILED                              -1
	/*!doc < Standard error has occurred (for internal use). */
	#define N_E_CORE                            -2
		/*!doc < Null reference has occurred (for internal use). */
		#define N_E_NULL_REFERENCE              -3
		/*!doc < There were not enough memory. */
		#define N_E_OUT_OF_MEMORY               -4
		/*!doc < Functionality is not implemented. */
		#define N_E_NOT_IMPLEMENTED             -5
		/*!doc < Functionality is not supported. */
		#define N_E_NOT_SUPPORTED               -6
		/*!doc < Attempted to perform invalid operation. */
		#define N_E_INVALID_OPERATION           -7
		/*!doc < Arithmetic overflow has occurred. */
		#define N_E_OVERFLOW                    -8
		/*!doc < Index is out of range (for internal use). */
		#define N_E_INDEX_OUT_OF_RANGE          -9
		/*!doc < Argument is invalid. */
		#define N_E_ARGUMENT                   -10
			/*!doc < Argument value is #NULL where non-NULL value was expected. */
			#define N_E_ARGUMENT_NULL          -11
			/*!doc < Argument value is out of range. */
			#define N_E_ARGUMENT_OUT_OF_RANGE  -12
		/*!doc < Format of argument value is invalid. */
		#define N_E_FORMAT                     -13
		/*!doc < Input/output error has occurred. */
		#define N_E_IO                         -14
			/*!doc < Attempted to read file or buffer after its end. */
			#define N_E_END_OF_STREAM          -15
		/*!doc < Error in external code has occured (for internal use). */
		#define N_E_EXTERNAL                   -90
			/*!doc < Win32 error has occured. */
			#define N_E_WIN32                  -91
			/*!doc < COM error has occured. */
			#define N_E_COM                    -92
			/*!doc < CLR exception has occured. */
			#define N_E_CLR                    -93

	/*!doc < Parameter id is invalid. */
	#define N_E_PARAMETER                     -100
	/*!doc < Attempted to set read only parameter. */
	#define N_E_PARAMETER_READ_ONLY           -101

	/*!doc < Module is not registered. */
	#define N_E_NOT_REGISTERED                -200
#endif

/*!doc  Determines whether function result indicates error. */
#define NFailed(result) ((result) < 0)
/*!doc  Determines whether function result indicates success. */
#define NSucceeded(result) ((result) >= 0)

#ifndef N_DOCUMENTATION
#ifndef N_NO_ANSI_FUNC
NInt N_API NErrorGetDefaultMessageA(NResult code, NAChar * szValue);
#endif
#ifndef N_NO_UNICODE
NInt N_API NErrorGetDefaultMessageW(NResult code, NWChar * szValue);
#endif
#define NErrorGetDefaultMessage N_FUNC_AW(NErrorGetDefaultMessage)
#endif

N_DECLARE_HANDLE(HNError)

HNError N_API NErrorGetLast();

NResult N_API NErrorGetCode(HNError hError);

#ifndef N_DOCUMENTATION
#ifndef N_NO_ANSI_FUNC
NInt N_API NErrorGetMessageA(HNError hError, NAChar * szValue);
#endif
#ifndef N_NO_UNICODE
NInt N_API NErrorGetMessageW(HNError hError, NWChar * szValue);
#endif
#define NErrorGetMessage N_FUNC_AW(NErrorGetMessage)
#endif
NInt N_API NErrorGetCallStackLength(HNError hError);

#ifndef N_NO_ANSI_FUNC
NInt N_API NErrorGetCallStackFunctionA(HNError hError, NInt index, NAChar * szValue);
#endif
#ifndef N_NO_UNICODE
NInt N_API NErrorGetCallStackFunctionW(HNError hError, NInt index, NWChar * szValue);
#endif
#define NErrorGetCallStackFunction N_FUNC_AW(NErrorGetCallStackFunction)

#ifndef N_NO_ANSI_FUNC
NInt N_API NErrorGetCallStackFileA(HNError hError, NInt index, NAChar * szValue);
#endif
#ifndef N_NO_UNICODE
NInt N_API NErrorGetCallStackFileW(HNError hError, NInt index, NWChar * szValue);
#endif
#define NErrorGetCallStackFile N_FUNC_AW(NErrorGetCallStackFile)

NInt N_API NErrorGetCallStackLine(HNError hError, NInt index);
HNError N_API NErrorGetInnerError(HNError hError);

NUInt N_API NErrorGetWin32Error(HNError hError);
NInt N_API NErrorGetComError(HNError hError);
NHandle N_API NErrorGetClrError(HNError hError);

#ifdef N_CPP
}
#endif

#endif /*!doc  !N_ERRORS_H_INCLUDED */
