module CallingUsingDomObjects

// what will be covered in this chapter include the following 
//   1. calling using COM Objects

(*

some of the COM object still do  not have .NET frameowrk (the managed equivalent). and still some vendors that exposes the APIs via COM 

the .NET framework was designed to interoperate well with COM, and calling COM component is generally quite straightfoward. calling COM components is always done through a managed wrapper that takes care of 
calling the unmanaged code for you, you can produce these wrapper using a tool called 
"TlbImp.exe"
the Type Library Importer, that ships with the .NET SDK.

you can find the more information about the TlbImp.exe from the http://msdn2.microsoft.com/en-us/library/tt0cf3sx(VS.80).aspx


despite the existenced of the TlbImp.exe, but if you find yourself in a situation where you need to use a COM component, first check the vendeor provides a managed wrapper for it, called 
"Primary Interop Assemblies", for more informatoin on Primary Interop Assemblies


when it is necessary to use the TlbImp.exe, fortunately, it is straightforward, normally all that is necessary is to pass TlbImp.exe the location of hte .dll that contains the COM component./

e.g.

    tlbimp "C:\Program Files\Common Files\Microsoft Shared\Speech\sapi.dll"

there are two command-line switches, that are /out: (controls the name and location of the resulting manager wrapper) , and /keyfile: (to sign0

normally all classes from the TlbImp.exe
libraries will have a word "Class" and each one is provided with a separate interfaces: this is a requirement of the COM object. 

e.g.

C:\Windows\System32\Speech\Common\sapi.dll

C:\dev\functional\microsoft\fsharp\3.0\trunk\src\assemblies\BeginningFSharp\Interoperability\Interoperability\Lib>tlbimp sapi.dll

Microsoft (R) .NET Framework Type Library to Assembly Converter 4.0.30319.1
Copyright (C) Microsoft Corporation.  All rights reserved.

TlbImp : warning TI3002 : Importing a type library into a platform agnostic assembly.  This can cause errors if the type library is not truly platform agnostic.
...
TlbImp : Type library imported to SpeechLib.dll

*)

open SpeechLib

let main() = 
    // create an new instance of a com classes
    // (these almost always end with "Class")
    let voice = new SpVoiceClass()
    // call a method Speak, ignoring the result 
    voice.Speak("中国", SpeechVoiceSpeakFlags.SVSFDefault) |> ignore 
do main()