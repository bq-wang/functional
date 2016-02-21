module CollectionSeqModule_FilterFindTryFind

// what we will cover in this chapter include the following. 
// 

(*

filter of type ('a -> bool) -> #seq<'a> -> seq<'a>,
find of type ('a -> bool) -> #seq<'a> -> 'a  
tryfind of type ('a -> bool) -> #seq<'a> -> 'a option


*)


(*
The tryfind will return null instead of throw out exception when there is no element found for find operation


(*

hat ... bat ... mat ... rat ...
hot
Not found

*)

let shortWordList = [|"hat"; "hot"; "bat"; "lot"; "mat"; "dot"; "rat";|]
let atWords =
    shortWordList
    |> Seq.filter (fun x -> x.EndsWith("at"))

let otWord =
    shortWordList
    |> Seq.find (fun x -> x.EndsWith("ot"))
let ttWord =
    shortWordList
    |> Seq.tryFind (fun x -> x.EndsWith("tt"))

atWords |> Seq.iter (fun x -> printf "%s ... " x)
printfn ""
printfn "%s" otWord
printfn "%s" (match ttWord with | Some x -> x | None -> "Not found")