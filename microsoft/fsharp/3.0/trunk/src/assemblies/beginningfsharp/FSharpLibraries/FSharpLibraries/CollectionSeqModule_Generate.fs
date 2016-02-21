module CollectionSeqModule_Generate

// what will be covered in this chaper include the following 
// 1. the generate function 


(*

the Seq.generate methods is availabe in the FSharp.Powrpack.dll

http://fsharppowerpack.codeplex.com/


you can download the source and play 


or you can do the following 

http://stackoverflow.com/questions/5602564/f-convert-sequence-generate-to-sequence-expression


Or you can find the source file here: 

https://bitbucket.org/mbhwork/fsharp/src/62307fc2959353690449e36f75807e82ea60ff8e/Feb2010/src/FSharp.PowerPack.Compatibility/?at=default

and the source file is here:

https://bitbucket.org/mbhwork/fsharp/src/62307fc2959353690449e36f75807e82ea60ff8e/Feb2010/src/FSharp.PowerPack.Compatibility/Compat.Seq.fs?at=default


*)
#nowarn "9"

//namespace Microsoft.FSharp.Compatibility.OCaml
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

open System 
open System.Text
open System.IO

// test.txt: the , cat, sat, on, the , mat

let opener() = File.OpenText("test.txt")
let generator (stream : StreamReader) =
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
    let chars = generatorInner []
    if List.length chars = 0 && !endStream then
        None
    else
        Some(new string(List.toArray (List.rev chars)))

let closer(stream: StreamReader) = 
    stream.Dispose()

let wordList =  
    Seq.generate  
        opener 
        generator 
        closer

wordList |> Seq.iter (fun s -> printfn "%s" s)

(*

the
cat
sat
on
the
mat

*)

