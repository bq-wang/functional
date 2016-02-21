module CollectionSeqModule_Concat

// what we will cover in this chaper include  
//   1. the Seq module function "concat"


(*

concat: #seq <#seq<'a> > -> seq <'a>

*)


open System.Collections.Generic

let myList = 
    let temp = new List<int[]>() 
    temp.Add([|1; 2; 3|])
    temp.Add([|4; 5; 6|])
    temp.Add([|7; 8; 9|])
    temp


let myCompleteList = Seq.concat myList 
myCompleteList |> Seq.iter (fun x -> printf "%i ... " x) 


