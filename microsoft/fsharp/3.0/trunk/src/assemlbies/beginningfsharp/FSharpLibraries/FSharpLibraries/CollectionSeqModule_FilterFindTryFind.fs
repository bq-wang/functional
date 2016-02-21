module CollectionSeqModule_FilterFindTryFind

// what will be covered in this chapter is 
//  1. filter 
//  2. find
//  3. tryFInd functions


(*

the types of the functions is as follow 

filter type ('a -> bool) -> #seq<'a> -> seq<'a>, find of type ('a -> bool) -> #seq<'a> -> 'a and tryfind of
type ('a -> bool) -> #seq<'a> -> 'a


*)

let shortWordList = [|"hat"; "hot"; "bat"; "lot"; "mat"; "dot"; "rat";|]


let atWords = 
    shortWordList
    |> Seq.filter (fun x -> x.EndsWith("at"))

let otWord = 
    shortWordList
    |> Seq.find (fun x -> x.EndsWith("ot"))


(* tryFind will return None if no element in the collection is find, find will throw out exception  *)

let ttWord = 
    shortWordList 
    |> Seq.tryFind(fun x -> x.EndsWith("tt"))

atWords |> Seq.iter(fun x -> printfn "%s ...." x)

printfn ""

printfn "%s" otWord
printfn "%s" (match ttWord with | Some x -> x | None -> "Not found")


