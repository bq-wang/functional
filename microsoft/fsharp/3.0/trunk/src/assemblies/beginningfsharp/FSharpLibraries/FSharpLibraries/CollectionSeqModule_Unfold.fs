module CollectionSeqModule_Unfold

// the following will be covered in the following 
//   1. unfold functions 

(*

the unfold functions is the reverse of hte fold functions . 


*)


let fibs = 
    (1, 1) |> Seq.unfold
        (fun (n0, n1) ->
            Some(n0, (n1, n0 + n1)))

let first20 = Seq.take 20 fibs

printfn "%A" first20 

(*

[1; 1; 2; 3; 5; 8; 13; 21; 34; 55; 89; 144; 233; 377; 610; 987;
1597; 2584; 4181; 6765]

*)


(* the following will show you a use example of the unfold function, which uses the 

*)


let decayPattern =
    Seq.unfold
        (fun x -> 
            let limit = 0.01
            let n = x - (x / 2.0)
            if n > limit then 
                Some(x, n)
            else 
                None)
        10.0

decayPattern |> Seq.iter (fun x -> printf "%f ..." x)

(*
10.000000 ...5.000000 ...2.500000 ...1.250000 ...0.625000 ...0.312500 ...0.156250 ...0.078125 ...0.039063 ...
val decayPattern : seq<float>

*)