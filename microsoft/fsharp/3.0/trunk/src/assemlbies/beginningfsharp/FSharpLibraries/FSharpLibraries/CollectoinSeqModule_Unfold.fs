module CollectoinSeqModule_Unfold

// what will be covered in this chapter include the following.
//  1. unfold function 


(*
unfold is the reverse of the fold function 

unfold can produce either a finite or an infinite sequence. 

unfold can return a item as well as the accumulator 
unfold use Some to indicate continue, and None to indcate stop 
return type of unfold is "'a * 'b option". meaning a option type that contains a tupe of values

*)


(*
seq [1; 1; 2; 3; ...]

val fibs : seq<int>
val first20 : seq<int>

*)

let fibs = 
    (1, 1) |> Seq.unfold
        (fun (n0, n1) -> 
            Some(n0, (n1 , n0 + n1)))

let first20 = Seq.take 20 fibs

printfn "%A" first20;


(*
we will simuate some decary functions , stop when reaching some limits 

*)
let decayPattern = 
    Seq.unfold (fun x -> 
                    let limit = 0.01
                    let n = x - (x / 2.0)
                    if n > limit then 
                        Some(x, n)
                    else
                        None)  10.0

decayPattern |> Seq.iter (fun x -> printf "%f ..." x)
