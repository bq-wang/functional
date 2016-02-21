module CollectionSeqModule_Choose

// what we will cover the following 
//   choose function 

(*
type ('a -> 'b option) -> #seq<'a> -> seq<'b>.
*)

let floatArray = [|0.5; 0.75; 1.0; 1.25; 1.5; 1.75; 2.0 |]
let integers =
    floatArray |>
    Seq.choose
        (fun x ->
            let y = x * 2.0
            let z = floor y
            if y - z = 0.0 then
                Some (int z)
            else
                None)
integers |> Seq.iter (fun x -> printf "%i ... " x)


(*

1 ... 2 ... 3 ... 4 ...

*)