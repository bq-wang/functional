
module FParsec_ApplyTransformToParserRsult

// in this chapter we will cover the following
//   1. show how to do some parser transform (transform on the result) 

#I "C:\\dev\\workspaces\\functional\\microsoft\\fsharp\\3.0\\trunk\\src\\assemblies\\beginningfsharp\\ParsingText\\ParsingText"
#r "FParsec.dll"
#r "FParsecCS.dll"
open FParsec
open FParsec.Primitives

(*
the key here is the use of the combinator operator, |>>, accept a parser and return the parser transformed
*)

let addTwo = CharParsers.pfloat |>> (fun x -> x + 2.0)

let pi2 = CharParsers.run addTwo "3.1416"
printfn "Result: %A" pi2

(*

Result: Success: 5.1416

val addTwo : Parser<float,unit>
val pi2 : ParserResult<float,unit> = Success: 5.1416
)