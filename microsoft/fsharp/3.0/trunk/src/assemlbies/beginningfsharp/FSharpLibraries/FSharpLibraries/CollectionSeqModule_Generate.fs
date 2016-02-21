module CollectionSeqModule_Generate

// the following will be discussed 
// 1. the generate function 

open System
open System.Text
open System.IO

(*


type: (unit -> 'b) -> ('b -> 'a option) -> ('b -> unit) -> seq<'a>


generate function of type is a useful function for creating IEnumerable collections . an example of the use case is 

The cursor can be a file stream, as shown in these examples, or
perhaps more commonly a database cursor.



*)



(*

NOTE: to use the Seq.generate methods, you will need to reference and use the FSharp.PowerPack.Compatbility


http://stackoverflow.com/questions/5505820/seq-generate-not-defined-is-this-deprecated

*)

(*  http://fsharppowerpack.codeplex.com/SourceControl/changeset/view/54799#684960 *)
// (c) Microsoft Corporation 2005-2009. 

#nowarn "9"
   
// namespace Microsoft.FSharp.Compatibility.OCaml
open System.Collections.Generic

[<RequireQualifiedAccess>]
[<CompilationRepresentation(CompilationRepresentationFlags.ModuleSuffix)>]
module Seq = 

    let generate openf compute closef = 
        seq { let r = openf() 
              try 
                let x = ref None
                while (x := compute r; (!x).IsSome) do
                    yield (!x).Value
              finally
                 closef r }



// test.txt: the,cat,sat,on,the,mat

let opener () = File.OpenText("test.txt")
let generator (stream: StreamReader) = 
    let endStream = ref false
    let rec generatorInner chars = 
        match stream.Read() with 
            | -1 -> 
            endStream := true
            chars 
            | x -> 
                match Convert.ToChar(x) with 
                | ',' -> chars
                | c -> generatorInner (c :: chars) 
    let chars = generatorInner[]
    if List.length chars = 0 && !endStream then 
        None
    else 
        Some(new string(List.toArray (List.rev chars)))

let closer (stream : StreamReader) =
    stream.Dispose()


let wordList =  
    Seq.generate
         opener 
         generator 
         closer    

wordList |> Seq.iter (fun s -> printfn "%s" s) 

