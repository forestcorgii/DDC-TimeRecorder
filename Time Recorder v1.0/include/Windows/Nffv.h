/*!doc
|******************************************************************************|
|*                                                                            *|
|*                   Neurotechnology Fingerprint Engine 1.0                   *|
|*                                                                            *|
|* Nffv.h                                                                     *|
|* Header file for Nffv module                                                *|
|*                                                                            *|
|* Copyright (C) 2008 Neurotechnology                                         *|
|*                                                                            *|
\******************************************************************************/

#ifndef NFFV_H_INCLUDED
#define NFFV_H_INCLUDED

#include <NTypes.h>
#include <NErrors.h>
#include <NLibraryInfo.h>

#ifdef N_CPP
extern "C"
{
#endif

#define NFFV_MAX_USER_COUNT       10

typedef enum NffvStatus_
{
	nfesNone = 0,
	nfesTemplateCreated = 1,
	nfesNoScanner = 2,
	nfesScannerTimeout = 3,
	nfesUserCanceled = 4,
	nfesQualityCheckFailed = 100
} NffvStatus;

#ifndef N_NO_ANSI_FUNC
NResult N_API NffvGetInfoA(NLibraryInfoA * pValue);
#endif
#ifndef N_NO_UNICODE
NResult N_API NffvGetInfoW(NLibraryInfoW * pValue);
#endif
#define NffvGetInfo N_FUNC_AW(NffvGetInfo)

#ifndef N_NO_ANSI_FUNC
NResult N_API NffvGetAvailableScannerModulesA(NAChar * * pSzValue);
#endif
#ifndef N_NO_UNICODE
NResult N_API NffvGetAvailableScannerModulesW(NWChar * * pSzValue);
#endif
#define NffvGetAvailableScannerModules N_FUNC_AW(NffvGetAvailableScannerModules)

N_DECLARE_HANDLE(HNffvUser)

#ifndef N_NO_ANSI_FUNC
NResult N_API NffvInitializeA(const NAChar * szDbName, const NAChar * szPassword, const NAChar * szScannerModules);
#endif
#ifndef N_NO_UNICODE
NResult N_API NffvInitializeW(const NWChar * szDbName, const NWChar * szPassword, const NWChar * szScannerModules);
#endif
#define NffvInitialize N_FUNC_AW(NffvInitialize)

void N_API NffvUninitialize();

NResult N_API NffvGetUserCount(NInt * pValue);
NResult N_API NffvGetUser(NInt index, HNffvUser * pValue);
NResult N_API NffvRemoveUser(NInt index);
NResult N_API NffvClearUsers();

NResult N_API NffvEnroll(NUInt timeout, NffvStatus * pStatus, HNffvUser * pHUser);
NResult N_API NffvVerify(HNffvUser hUser, NUInt timeout, NffvStatus * pStatus, NInt * pScore);
NResult N_API NffvCancel();
NResult N_API NffvGetUserById(NInt id, HNffvUser * pValue);
NResult N_API NffvGetUserIndexById(NInt id, NInt * pValue);

NResult N_API NffvGetQualityThreshold(NByte * pValue);
NResult N_API NffvSetQualityThreshold(NByte value);
NResult N_API NffvGetMatchingThreshold(NInt * pValue);
NResult N_API NffvSetMatchingThreshold(NInt value);

NResult N_API NffvUserGetImage(HNffvUser hUser, NUInt * pWidth, NUInt * pHeight,
	NFloat * pHorzResolution, NFloat * pVertResolution, NSizeType * pStride, void * pPixels);
#ifdef N_WINDOWS
NResult N_API NffvUserGetHBitmap(HNffvUser hUser, NHandle * pHBitmap);
#endif

NResult N_API NffvUserGetId(HNffvUser hUser, NInt * pValue);

void N_API NffvFreeMemory(void * pBlock);

#ifndef N_NO_ANSI_FUNC
NInt N_API NffvGetErrorMessageA(NResult code, NAChar * szValue);
#endif
#ifndef N_NO_UNICODE
NInt N_API NffvGetErrorMessageW(NResult code, NWChar * szValue);
#endif
#define NffvGetErrorMessage N_FUNC_AW(NffvGetErrorMessage)

#ifdef N_CPP
}
#endif

#endif // !NFFV_H_INCLUDED
