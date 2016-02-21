//module UseFSharpFromNativeCodeViaCOM

// what will be covered in this chatper 
//  1. show how to call the F# function from COM via Native code 

(*

The easiest way to do this is to use the tools provided with .NET to create a COM wrapper for your F# assembly. You can then use the COM runtime to call the F# functions from C++.


To expose functions though COM, you need to develop them in a certain way. First
1. you must define an interface that will specify the contract for your functions, the members of the interface must be written using named arguments (see the section on “Calling F# Libraries from C#” earlier in the chapter)
2. the interface itself must be marked with the System.Runtime.InteropServices.Guid attribute
3. Then you must provide a class that implements the interface. This too must be marked the System.Runtime.InteropServices.Guid attribute and also the System.Runtime.InteropServices.ClassInterface
    and you should always pass the ClassInterfaceType.None enumeration member to the ClassInterface attribute constructor to say that no interface should be automatically generated


*)

(*
below will try to expose two functions called "Add" and "Sub"  

we define IMatch in namespace Strangelights, and then create a class Math to implement this interface 
*)

(*
to make the F# libraries usable from the Native parts. what you will need to do 
1. registering the assembly so the COM runtime can find it 
    regasm comlibrary.dll /tlb:comlibrary.tlb
    regasm comlibrary.dll

    NOTE: the first call of "regasm" is to create a type library file, a .tlb file, which you can use in your C++ project to develop against.
          the second call of "regasm" registers the assembly itself so the COM runtime can find it.

the output is as follow
> register and create .tlb

C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\interoperability\Interoperability>regasm comlibrary.dll /tlb:comlibrary.tlb
Microsoft (R) .NET Framework Assembly Registration Utility 4.0.30319.1
Copyright (C) Microsoft Corporation 1998-2004.  All rights reserved.

Types registered successfully
Assembly exported to 'C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\interoperability\Interoperability\comlibrary.tlb',
and the type library was registered successfully

> register the .dll
C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\interoperability\Interoperability>regasm comlibrary.dll
Microsoft (R) .NET Framework Assembly Registration Utility 4.0.30319.1
Copyright (C) Microsoft Corporation 1998-2004.  All rights reserved.

Types registered successfully
*)
namespace Strangelights

open System
open System.Runtime.InteropServices

// define an interface (since all COM classes must
// have a seperate interface)
// mark it with a freshly generated Guid
[<Guid("6180B9DF-2BA7-4a9f-8B67-AD43D4EE0563")>]
type IMath = 
    abstract Add : x: int * y: int -> int
    abstract Sub : x: int * y: int -> int

// implement the interface, the class must:
// - have an empty constuctor
// - be marked with its own guid
// - be marked with the ClassInterface attribute
[<Guid("B040B134-734B-4a57-8B46-9090B41F0D62");
ClassInterface(ClassInterfaceType.None)>]
type Math() =
    interface IMath with 
        member this.Add(x, y) = x + y
        member this.Sub(x, y) = x + y