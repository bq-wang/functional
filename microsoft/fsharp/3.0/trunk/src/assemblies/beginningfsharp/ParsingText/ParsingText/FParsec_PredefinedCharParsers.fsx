module FParsec_PredefinedCharParsers

// in this chapter we will cover the following
//   1. we will introduce something on the FParsec library and 
//   2. an example to show the primitive bulit-in parser


(*
FParsec is an open source combinator library for parsing text.

it is available from the : http://www.quanttec.com/fparsec/ , it is based on the Haskell parsing library Parsec http://www.haskell.org/haskellwiki/Parsec

A note:If you are used to reading BNF grammars and using regular expressions then you’ll probably find using fslex.exe and fsyacc.exe a little more intuitive than using FParsec.

FParsec is still fairly easy to use once you get your head round a few key concepts.. , the advantages of the FParsec libraries are that:
    1) just library and no code generation or external tools are required.
    2) FParsec has been designed with performance in mind and generally produces parsers that are very fast and produce good error messages.



*)

(*
table of the useful predefined parsers 

upper  
lower
digit
hex
spaces: Matches zero or more whitespace character, that is space, tab, and new line
spaces1 : Matches one or more whitespace, that is space, tab, and new line
pfloat: 
pint32: 32 bit integer

*)

#I "C:\\dev\\workspaces\\functional\\microsoft\\fsharp\\3.0\\trunk\\src\\assemblies\\beginningfsharp\\ParsingText\\ParsingText"
#r "FParsec.dll"
#r "FParsecCS.dll"

open FParsec

let pi = CharParsers.run CharParsers.pfloat "3.1416"

printfn "Result: %A" pi

(*
the result is as follow :

Result: Success: 3.1416

val pi : FParsec.CharParsers.ParserResult<float,unit> = Success: 3.1416


*)