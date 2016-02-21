// what will be covered in this chapter include the following 
//  1. show you that if the IL code is not well controlled, it can easily create some non-sense 

// create a faulty add function
let add (x:int) (y:int) = (# "ret" x y : int #)


// test these functions
let x = add 1 1

(*

UseInlineIL_CreateNonsenseIL.fsx(5,28): warning FS0042: This construct is deprecated: it is only for use in the F# library
System.InvalidProgramException: JIT Compiler encountered an internal limitation.
   at <StartupCode$FSI_0008>.$FSI_0008.main@()
Stopped due to error

*)