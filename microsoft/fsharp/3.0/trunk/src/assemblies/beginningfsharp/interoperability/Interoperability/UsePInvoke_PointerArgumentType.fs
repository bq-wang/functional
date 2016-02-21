de

// what will be covered in this chapter include the following 
//  1. continue to learn some tips on the P/Invoke when the target function expect some pointer or ...

(*
tips on the P/Invoke on the functions that need argument of type pointer..
few points:

1. when defining the function, you need to put an asteric (*) after the type name to show you are passing a pointer 
2. you need to define a mutable identifier before the function call to represent the area of memory that is pointed to. This may not be
    global, in the top level, but it must be part of a function definition This is why you define the function
    main, so the identifier status can be part of the definition of this.
3. you must us the address of operator (&&) to ensure the pointer is passed to the function rather than the value 

*) 

(*
to suppress the warning on the use of "address of operator (&&)", use 

#nowarn "51"

or the 

--nowarn 51

compiler flags
*)
module UsePInvoke_PointerArgumentType
#nowarn "51"

open System.Runtime.InteropServices

// declare a function found in an external dll
[<DllImport("Advapi32.dll")>]
extern bool FileEncryptionStatus(string filename, uint32* status)

let main() =
    // declare a mutable identifier to be passed to the function 
    let mutable status = 0ul
    // call the function, using the address of operator with the 
    // second parameter 
//    FileEncryptionStatus(@"C:\\test.txt", && status) |> ignore 
    FileEncryptionStatus(@"C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\interoperability\Interoperability\test.txt", && status) |> ignore 
    // print the status to check it has be altered
    printfn "%d" status

do main()


(*
0

val FileEncryptionStatus : string * nativeptr<uint32> -> bool
val main : unit -> unit

*)