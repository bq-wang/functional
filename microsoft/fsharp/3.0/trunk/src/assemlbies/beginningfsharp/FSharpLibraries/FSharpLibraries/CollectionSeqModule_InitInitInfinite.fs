module CollectionSeqModule_InitInitInfinite

// what will be covered in this chapter include the following 
//   1. init 
//   2. initInfinite 


(*

init of type int -> (int -> 'a) -> seq<'a> 
initInfinite of type (int -> 'a) -> seq<'a>.

init will create a finite sequence. 
initInfinite will create an infinite sequence 
*)

(*
the printed results is as follow 


1 ...1 ...1 ...1 ...1 ...1 ...1 ...1 ...1 ...1 ...
seq [-2147483648; -2147483647; -2147483646; -2147483645; ...]

*)
let tenOnes = Seq.init 10 (fun _ -> 1) 

let allIntegers = Seq.initInfinite( fun x -> System.Int32.MinValue + x) 

let firstTenInts = Seq.take 10 allIntegers

tenOnes |> Seq.iter(fun x -> printf "%i ..." x) 

printfn ""
printfn "%A" firstTenInts

