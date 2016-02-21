module CollectionSeqModule_Cast

// the following will be covered in this chapter
//  1. the cast function 

(*
the use of the cast function is ensure that it works with the 
generic verion and with the non-generic version


to work with the cast, you will need the type annotation, which is to instruct the compile the right conversion to use
 *)


open System.Collections
open System.Collections.Generic

let floatArrayList =
    let temp =new ArrayList()
    temp.AddRange([|1.0; 2.0; 3.0|])
    temp
let (typedFloatSeq: seq<float>) = Seq.cast floatArrayList