module CommentsForCrossCompilation

// what will be covered in this chapter include the following .
//  1. to know what is "cross compilation" that is supported in the F# compiler 
//  2. to give some example of the "Cross compilation"

(*

the following tag will be ignored and the content within will be treated as code in F# compiler 
*)

(*F#
printfn "This will be printed by a F# program" 
F#*)


(* the following will be treated by the o-camel compiler as code, but in the eye of 
F# compiler, it is just some commetn code 

If you use the O’Caml-compatible version of
the F# syntax, then you should save your file with the extension .ml instead of .fs


*)

(*IF-OCAML*)
Format.printf "this will be printed by an O'Caml program"
(*ENDIF-OCAML*)



