
module FParsec_ChoiceParser

// in this chapter we will cover the following
//   1. show you how to use the <|> choice combinator

#I "C:\\dev\\workspaces\\functional\\microsoft\\fsharp\\3.0\\trunk\\src\\assemblies\\beginningfsharp\\ParsingText\\ParsingText"
#r "FParsec.dll"
#r "FParsecCS.dll"
open FParsec
open FParsec.Primitives

(*
the key here is the use of the combinator operator, <|>, Choice between two input types. 
*)


(*

functions for creating Parsers from Predicates

manySatisfy
skipManySatisfy
many1Satisfy
skipMany1Satisfy
manyMinMaxSatisfy

Note that all these functions have a version post fixed with a capital L, for label, which allows the user to provide a label that will be used in error message generation. You now have most of the elements you need to implement your

*)

type AstFragment = 
    | Val of float
    | Ident of string

(*
the key here is the many1Satisfy , which is a function that allows us to create a parser from a predicate function, which it accepts as a parameter. 

*)
let number = CharParsers.pfloat |>> (fun x -> Val x) 
let id = 
    CharParsers.many1Satisfy CharParsers.isLetter
    |>> (fun x -> Ident x)

let stringOrFloat = id <|> number

let num = CharParsers.run stringOrFloat "3.1416"
let ident = CharParsers.run stringOrFloat "anIdent"

printfn "Result 'num': %A Result 'ident': %A" num ident

(*

Result 'num': Success: Val 3.1416 Result 'ident': Success: Ident "anIdent"

type AstFragment =
  | Val of float
  | Ident of string
val number : Parser<AstFragment,unit>
val id : Parser<AstFragment,unit>
val stringOrFloat : Parser<AstFragment,unit>
val num : ParserResult<AstFragment,unit> = Success: Val 3.1416
val ident : ParserResult<AstFragment,unit> = Success: Ident "anIdent"
)