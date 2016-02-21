
module FParsec_CombineWsFloatParser

// in this chapter we will cover the following
//   1. show a example to demonstrate that you can combine the predefined parser to handle a more sophisticated input (with an example of float number prefixed with the white spaces)

#I "C:\\dev\\workspaces\\functional\\microsoft\\fsharp\\3.0\\trunk\\src\\assemblies\\beginningfsharp\\ParsingText\\ParsingText"
#r "FParsec.dll"
#r "FParsecCS.dll"
open FParsec
open FParsec.Primitives

(*
the key here is the use of the combinator operator, >>. - which means combine two parsers, but only return the result of the second. 

.>>  which means combine two parsers, but only return the result of the first. 

*)
let wsfloat = CharParsers.spaces >>. CharParsers.pfloat

let pi = CharParsers.run wsfloat "    3.1416"
printfn "Result: %A" pi

(*

Result: Success: 3.1416

)