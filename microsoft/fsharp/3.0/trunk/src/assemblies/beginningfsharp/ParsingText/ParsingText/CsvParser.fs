module CsvParser

// what will be covered in this chapter include the following 
//  1 . how ot parse the CSV (the comma-separated) text and create a strong-typed object/collections out of it


open System
open System.IO
open System.Collections
open System.Reflection
open Microsoft.FSharp.Reflection

// a class to reas CSF values from a file
type CsvReader<'a> (filename) = 
    // fail with the generic type is no a tupel
    do if not (FSharpType.IsTuple(typeof<'a>)) then
        failwith "Type parameter must be type"
    // get the elements of the tuple 
    let elements = FSharpType.GetTupleElements(typeof<'a>)

    // create functions to parse a element of type t (this metho
    let getParseFunc t = 
        match t with 
        | _ when t = typeof<string> ->
            // for string type returns a function that down 
            // cast to an object
            fun x -> x :> obj   // what is the different between the :> and hte :?> ?
        | _ -> 
            // for all other types test to see if they have a 
            // parse static method and use that 
            let parse = t.GetMethod("Parse",
                                    BindingFlags.Static |||
                                    BindingFlags.Public,
                                    null,
                                    [| typeof<string> |],
                                    null)
            fun (s : string) ->
                parse.Invoke(null, [| box s |])
    // create a list of parse functions from the tuple's elements
    let funcs = Seq.map getParseFunc elements
    // read all lines from the file 
    let lines =  File.ReadAllLines filename
    // create a function parse each row
    let parseRow row =
        let items = 
            Seq.zip (List.ofArray row) funcs
            |> Seq.map (fun (ele, parser) -> parser ele)
        FSharpValue.MakeTuple(Array.ofSeq items, typeof<'a>)
    // parse each row cast value to thetype of the given tuple
    let items = 
        lines
        |> Seq.map (fun x -> (parseRow (x.Split(','))) :?> 'a) // why this time, it uses the operator like ":>" not operator called ":?>"
        |> Seq.toList
    // implemnets the generic IEnumerable<'a> interface  (* this can be treated as the paradigm on how to treat the Genumerator methods *)
    interface seq<'a> with 
        member x.GetEnumerator() = 
            let seq = Seq.ofList items
            seq.GetEnumerator()
    // implement the non-geneci IEnumerable interface (* this can be treated as the paradigm on how to implement the IEnumerable interface in other occasions *)
    interface IEnumerable with 
        member x.GetEnumerator() =
            let seq = Seq.ofList items
            seq.GetEnumerator() :> IEnumerator

let values = new CsvReader<int * int * int> ("numbers.csv")


for x,y,z in values do 
    assert (x + y = z)
    printfn "%i + %i = %i" x y z

(*

the result of running the application is as follow 

1 + 2 = 3
2 + 4 = 6
4 + 5 = 9

*)

