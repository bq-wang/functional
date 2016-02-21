module CollectionSeqModule_InitInitInfinite

// what will be covered in this chapter in the following 
//    1. init 
//    2. initInifite functions 

(*
init of type int -> (int -> 'a) -> seq<'a>
initInfite type (int -> 'a) -> seq<'a>.

*)
let tenOnes = Seq.init 10 (fun _ -> 1)
let allIntegers = Seq.initInfinite (fun x -> System.Int32.MinValue + x)
let firstTenInts = Seq.take 10 allIntegers
tenOnes |> Seq.iter (fun x -> printf "%i ... " x)
printfn ""
printfn "%A" firstTenInts
(*

1 ... 1 ... 1 ... 1 ... 1 ... 1 ... 1 ... 1 ... 1 ... 1 ...
[-2147483648; -2147483647; -2147483646; -2147483645; -2147483644; -2147483643;
-2147483642; -2147483641; -2147483640; -2147483639]

*)