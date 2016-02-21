module CollectionSeqModule_Cast

// what will be covered in this chapter 
//  1. cast function 

(*

the cast function is designed to convert from those non-generic version to the generic versions .

the generic version is from the System.Collections.Generic and the non-generic version is from the System.Collections.

which is common when you are dealing with the IEnumerable interface 

*)

(*

Using cast function always required using type annotations to tell the compiler what type of list you are
producing
Using cast function always required using type annotations to tell the compiler what type of list you are
producing
*)

open System.Collections
open System.Collections.Generic

let floatArrayList = 
    let temp = new ArrayList()
    temp.AddRange([| 1.0; 2.0; 3.0 |])
    temp


let (typedFloatSeq: seq<float>) = Seq.cast floatArrayList