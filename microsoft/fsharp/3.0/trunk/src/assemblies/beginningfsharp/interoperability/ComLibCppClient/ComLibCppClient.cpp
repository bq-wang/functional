// ComLibCppClient.cpp : Defines the entry point for the console application.
//

/************************************************************************************

you need to create a Visual Studio Console Application template and activates ATL.

1. The #import command tells the compiler to import your type library. You may need to use the full
path to its location. The compiler will also automatically generate a header file, in this case
comlibrary.tlh, located in the debug or release directory. This is useful because it lets you know
the functions and identifiers that are available as a result of your type library.

2. You then need to declare a pointer to the IMath interface you created. You do this via the code
comlibrary::IMathPtr pDotNetCOMPtr;. Note how the namespace comes from the library name
rather than the .NET namespace.


3. you need to create an instance of your Math class. You achieve this by calling the
CreateInstance, method passing it the GUID of the Math class. Fortunately, there is a constant
defined for this purpose.

4. If this was successful, you can call the Add function. Note how the result of the function is actually
an HRESULT, a value that will tell you whether the call was successful. The actual result of the
function is passed out via an out parameter.


/************************************************************************************/


/*-------------------------------------------------------

A special note: you will need to copy the .comlibrary.dll and comlibrary.tlb to the output directory (or configure the library path), another way is to dump it to a well-known location such as the C:\Windows\System32

Another note is that it is not ncessary to run the regasm twice.

-------------------------------------------------------*/


#include "stdafx.h"

//#import "..\Interoperability\comlibrary.tlb" named_guids raw_interfaces_only
#import "..\..\..\..\Debug\comlibrary.tlb" named_guids raw_interfaces_only


// the applications main entry point
int _tmain(int argc, _TCHAR* argv[])
{
  // initialize the COM runtiem
  CoInitialize(NULL);

  /* NOTE: no intelligence is found */
  // a pointer to the COM runtime 
  comlibrary::IMathPtr pDotNetCOMPtr;

  // create a new instance of the Match class
  HRESULT hRes = pDotNetCOMPtr.CreateInstance(comlibrary::CLSID_Math);
  // check it was created okay
  if (hRes == S_OK) {
    // define a local to hold the result 
    long res = 0L;
    // call the Add function 
    hRes = pDotNetCOMPtr->Add(1, 2, &res);
    // check Add was called okay
    if (hRes == S_OK)
    {
        // print the result
      printf("The result was: %ld", res);
    }

    // release the pointer to the math COM class
    pDotNetCOMPtr.Release();
  }
  // unitialize the COM runtime
  CoUninitialize();

	return 0;
}

/*==============

the result was:

The result was: 3

===============*/