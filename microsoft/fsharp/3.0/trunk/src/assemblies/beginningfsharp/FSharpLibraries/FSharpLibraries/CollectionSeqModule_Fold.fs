module CollectionSeqModule_Fold

//  what will be cvovered in this chaper include 
//    1. the fold function 


(*
the fold function ; 'b -> 'a -> 'b) -> 'b -> #seq<'a> -> 'b
*)
let myPhrase = [|"How"; "do"; "you"; "do?"|]


let myCompletePhrase = 
    myPhrase |>
    Seq.fold(fun acc x -> acc + " " + x) " " 

printfn "%s" myCompletePhrase