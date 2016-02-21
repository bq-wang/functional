module CollectoinSeqModule_Choose

// what will be covered in this chapter is 
//  1. choose function 

(*

choose : a clever function that allows you to do a filter and a map at the same time.

the type of the choose function is as follow: ('a -> 'b option) -> #seq<'a> -> seq<'b>.
*)

let floatArray = [|0.5; 0.75; 1.0; 1.25; 1.5; 1.75; 2.0 |]


let integers = 
    floatArray |>
    Seq.choose 
        (fun x -> 
            let y = x * 2.0
            let z = floor y 
            if y - z = 0.0 then 
                Some(int z) 
            else
                None)

integers |> Seq.iter (fun x ->  printf "%i ..." x ) 


