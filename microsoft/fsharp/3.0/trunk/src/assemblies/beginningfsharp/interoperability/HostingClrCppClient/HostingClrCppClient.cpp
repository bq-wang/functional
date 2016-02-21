// HostingClrCppClient.cpp : Defines the entry point for the console application.
//
/************************************************************************************

This technique is not suitable for high performance fine grain calls between C++ and F# since you have 
less control over the signatures used and the CLR method invocation is done using the reflection, 
meaning the module and method are found using string comparison which can be quite slow. However, 
if you are calling quite significant portions of F# code will probably find the cost of 
invocation is amortized quickly.

you need to create a Visual Studio Console Application template.

1. The #include <mscoree.h> tells the C++ compiler to import the header files that contains the
functions and interfaces for loading the CLR.

2. You then need to load and initialize the CLR. You do this by calling CorBindToRuntimeEx followed
by the Start method on the resulting object

3.You can call the method ExecuteInDefaultAppDomain to invoke a method in a CLR assembly.


/************************************************************************************/


/*-------------------------------------------------------

A special note: 
1. additional input on the mscoree.lib

Project properties | Linker | Input | Additional Dependencies: add mscoree.lib

2. copy the comlibrary.dll to the output folder


-------------------------------------------------------*/


/************************************************************************************

CLR inside out - CLR Hosting APIs: http://msdn.microsoft.com/en-us/magazine/cc163567.aspx
Common HRESULT Values: http://msdn.microsoft.com/en-us/library/windows/desktop/aa378137(v=vs.85).aspx 
   you will need to include the "Winerror.h"

Where can I find the declaration of HOST_E_CLRNOTAVAILABLE (type HRESULT) constant? http://stackoverflow.com/questions/6979826/where-can-i-find-the-declaration-of-host-e-clrnotavailable-type-hresult-consta?rq=1
  corerror.h
************************************************************************************/

#include "stdafx.h"

//#include <mscoree.h>
//#include <WinError.h>
//#include <CorError.h>

#include <windows.h>
#include <mscoree.h>
#include <corerror.h>
#include <metahost.h>

#pragma comment (lib, "mscoree.lib")

//int WINAPI WinMain (HINSTANCE hinst, HINSTANCE hinstPrev, LPSTR lpszCmdLine, int nCmdShow)
int _tmain(int argc, _TCHAR* argv[])
{
	HRESULT hr;
	ICLRRuntimeHost * pRuntimeHost;
	TCHAR szBuf [256];
	DWORD dwResult;
	ICLRMetaHost * pMetaHost;
	ICLRRuntimeInfo * pRuntimeInfo;

	hr = CLRCreateInstance (CLSID_CLRMetaHost, IID_PPV_ARGS (& pMetaHost));
	if (FAILED (hr))
		return 0;

	pMetaHost-> GetRuntime (L"v4.0.30319", IID_PPV_ARGS (& pRuntimeInfo));
	pRuntimeInfo-> GetInterface (CLSID_CLRRuntimeHost, IID_PPV_ARGS (& pRuntimeHost));
	pRuntimeInfo-> Release ();
	pMetaHost-> Release ();
	
	pRuntimeHost-> Start ();

	hr = pRuntimeHost-> ExecuteInDefaultAppDomain (L"ComLibraryCS.dll", L"StrangeLights.TestModule", L"Print", NULL, & dwResult);
	if (FAILED (hr)) {
		if (hr == COR_E_NEWER_RUNTIME)
			MessageBox (NULL, TEXT(". Version does not match"), NULL, MB_ICONWARNING);
		else {
			wsprintf (szBuf, TEXT ("ExecuteInDefaultAppDomain:%x"), hr);
			MessageBox (NULL, szBuf, TEXT ("OK"), MB_OK);
		}
		pRuntimeHost-> Stop ();
		pRuntimeHost-> Release ();
		return 0;
	}

	wsprintf (szBuf, TEXT ("random number %d"), dwResult);
	MessageBox (NULL, szBuf, TEXT ("OK"), MB_OK);

	pRuntimeHost-> Stop ();
	pRuntimeHost-> Release ();

    return 0;
}


/*
int _tmain(int argc, _TCHAR* argv[])
{
  // pointer to the CLR host object
  ICLRRuntimeHost *pClrHost = NULL;

  // invoke the method that loads the CLR
  HRESULT hrCorBind = CorBindToRuntimeEx(
    //NULL, // CLR version - NULL load the latest available
    L"v2.0.50727",
    //L"v4.0.30319",
    L"wks", // GC Type ("wks" = workstation or "svr" = Server)
    0,
    CLSID_CLRRuntimeHost,
    IID_ICLRRuntimeHost,
    (PVOID*)&pClrHost);

  // starts the CLR.
  HRESULT hrStart = pClrHost->Start();

  // define the assembly, type, function to load 
  // as well as the parameter and variable for the return type 
  //LPCWSTR pwzAssemblyPath = L"fslib.dll";
  //LPCWSTR pwzAssemblyPath = L"comlibrary.dll";
  LPCWSTR pwzAssemblyPath = L"ComLibraryCS.dll";
  //LPCWSTR pwzAssemblyPath = L"fslib.dll";
  LPCWSTR pwzTypeName = L"Strangelights.TestModule";
  //LPCWSTR pwzTypeName = L"HostClrTestModule";
  LPCWSTR pwzMethodName = L"print";
  LPCWSTR pwzMethodArgs = L"Hello world!";
  DWORD retVal;

  // load an assembly and execute a method in it.
  HRESULT hrExecute = pClrHost -> ExecuteInDefaultAppDomain(
      pwzAssemblyPath, pwzTypeName,
      pwzMethodName, pwzMethodArgs,
      &retVal);

  /*
  ICLRRuntimeHost::ExecuteInDefaultAppDomain Method http://msdn.microsoft.com/en-us/library/ms164411(v=vs.110).aspx

  the invoked method must have the following signature
  static int pwzMethodName (String pwzArgument)


  check to display the Hexadecimal helps you to find out the result: 

  ExecuteInDefaultAppDomain returns 8013101B: http://stackoverflow.com/questions/9009569/executeindefaultappdomain-returns-8013101b

  COR_E_NEWER_RUNTIME  == 0x8013101b

  CLR Hosting: Call a function with an arbitrary method signature? http://s240.codeinspot.com/q/3335606

  How to: Add or Remove References By Using the Reference Manager http://msdn.microsoft.com/en-us/library/hh708954.aspx

  Cannot get to work VB.NET DLL referenced by VB6 client in reg-free scenario: http://stackoverflow.com/questions/11469592/cannot-get-to-work-vb-net-dll-referenced-by-vb6-client-in-reg-free-scenario
  Registration-Free Activation of .NET-Based Components: A Walkthrough: http://msdn.microsoft.com/en-us/library/ms973915.aspx
  Distributed Services: Notes from the field: http://blogs.msdn.com/b/dsnotes/archive/2012/08/10/error-0x8013101b-when-doing-a-registration-free-com-activation.aspx
  * /

  //if (hrExecute & S_OK == S_OK)
  //{
  //}
  //else if (hrExecute & HOST_E_CLRNOTAVAILABLE == HOST_E_CLRNOTAVAILABLE)
  //{
  //}
  //else if (hrExecute & HOST_E_TIMEOUT == HOST_E_TIMEOUT)
  //{
  //}
  //else if (hrExecute & HOST_E_NOT_OWNER == HOST_E_NOT_OWNER)
  //{
  //}
  //else if (hrExecute & HOST_E_ABANDONED == HOST_E_ABANDONED) 
  //{
  //}
  //else if (hrExecute & E_FAIL == E_FAIL)

  switch (hrExecute)
  {
  case COR_E_NEWER_RUNTIME:
    printf ("get COR_E_NEWER_RUNTIME error!");
    break;
  default:
    break;
  }



  // print the result 
  printf ("retVal: %i", retVal);
	return 0;
}
*/


