
// what will be covered in this chapter include the following 
//  1. how to use the Inline IL

(*
normally you won't need to inline IL code, the IL inlining allow the F# function to directly emit IL code, to accomplish tasks that is not possbile with the F# language itself, such as the "box" "not" operation

*) 
(*
the key here is to use the "pound signs", such as (# #)

the code has to be correctly formed IL, or you will get a compiler error. you then can pass parameters to your IL instruction
*)

// declare add function using the IL add instruction
let add (x:int) (y:int) = (# "add" x y : int #)
// declare a sub function using the IL sub instruction
let sub (x:int) (y:int) = (# "sub" x y : int #)

// test these functions
let x = add 1 1
let y = sub 4 2


// prints the results
printfn "x: %i y: %i" x y

(*

UseInlineIL.fsx(16,28): warning FS0042: This construct is deprecated: it is only for use in the F# library


UseInlineIL.fsx(18,28): warning FS0042: This construct is deprecated: it is only for use in the F# library
x: 2 y: 2

val add : int -> int -> int
val sub : int -> int -> int
val x : int = 2
val y : int = 2

*)