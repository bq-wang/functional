
module FParsec_CombineParserAndResults

// in this chapter we will cover the following
//   1. it is more important to be able to parse the result as well as the parser itself.

#I "C:\\dev\\workspaces\\functional\\microsoft\\fsharp\\3.0\\trunk\\src\\assemblies\\beginningfsharp\\ParsingText\\ParsingText"
#r "FParsec.dll"
#r "FParsecCS.dll"
open FParsec
open FParsec.Primitives

(*
the key here is the use of the combinator operator, >>=, left accepts a parser and right accepts a function which is passed the results of the first parser and return a parser.. 
*)

let simpleAdd = CharParsers.pfloat >>= fun x ->
                CharParsers.spaces >>= fun () ->
                CharParsers.pfloat >>= fun y ->
                preturn (x + y) // preturn return a parser rather a simple return statement, the Parser is expected by the >>= operator 

let pi2 = CharParsers.run simpleAdd "3.1416 3.1416"

printfn "Result: %A" pi2

(*

Result: Success: 6.2832

val simpleAdd : Parser<float,unit>
val pi2 : ParserResult<float,unit> = Success: 6.2832
)