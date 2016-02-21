//module FormDesignerFormInFSharp

[<AutoOpen>]
module Strangelights.Fibonacci 

open Microsoft.FSharp.Control.LazyExtensions

// what will be covered in this chapter include the following 
//   1.  form designer's form in F#

(*

Fsharp has great interoperability with the .NET, it means that you can use the 
.NET forms.

*)

(*
In case that you get an "NullReferenceException", you may want to get the reference to the FSharp.Core reference.

Check this for example: 

calling F# functions from C# and getting null reference exceptions:   http://stackoverflow.com/questions/1633562/calling-f-functions-from-c-sharp-and-getting-null-reference-exceptions

it seems that you will need to make the output of FSharp module to be a Class libary rather than a console application
*)
let fibs = 
        (1, 1) |> Seq.unfold
            (fun (n0, n1) ->
                Some(n0, (n1, n0 + n1)))

let innerget n = 
    Seq.nth n fibs

// a function to get the nth fibonnaci number
let get n = 
     innerget n
