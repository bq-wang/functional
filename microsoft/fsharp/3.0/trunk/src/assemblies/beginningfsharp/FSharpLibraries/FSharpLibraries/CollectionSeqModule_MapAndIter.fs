module CollectionSeqModule_MapAndIter


// what we will cover in this chaper include the following 
//  1. the map function 
//  2. the iter function 

(*

map: create a new collecton by transforming each element in the collection


*)


let myArray = [|1; 2; 3|]

let myNewCollection = 
    myArray |>
    Seq.map (fun x -> x * 2) 


(*
iter: apply an operation that has a side-effect to each item in the collection 
*)


printfn "%A" myArray 

myNewCollection |> Seq.iter (fun x -> printf "%i ..." x) 


