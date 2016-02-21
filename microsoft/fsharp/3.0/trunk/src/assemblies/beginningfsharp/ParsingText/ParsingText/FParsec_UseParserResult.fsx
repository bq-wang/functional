module FParsec_UseParserResult

// in this chapter we will cover the following
//   1. we will introduce something on the FParsec library and 
//   2. an example that uses the ParserResult result (we will implementing the same arithmetic language we implemented with fslex and fsyacc )


(*
FParsec is an open source combinator library for parsing text.

it is available from the : http://www.quanttec.com/fparsec/ , it is based on the Haskell parsing library Parsec http://www.haskell.org/haskellwiki/Parsec

A note:If you are used to reading BNF grammars and using regular expressions then you’ll probably find using fslex.exe and fsyacc.exe a little more intuitive than using FParsec.

FParsec is still fairly easy to use once you get your head round a few key concepts.. , the advantages of the FParsec libraries are that:
    1) just library and no code generation or external tools are required.
    2) FParsec has been designed with performance in mind and generally produces parsers that are very fast and produce good error messages.

*)


(*

operations that are available from the Executing the parsers various Text types

run 
runParser
runParserOnString
runParserOnSubstring
runParserOnStream
runParserOnSubStream: Runs the parser on part of a FParsec.CharStream specified by a start and end position
runParserOnFile: Runs the parser on a file



*)

#I "C:\\dev\\workspaces\\functional\\microsoft\\fsharp\\3.0\\trunk\\src\\assemblies\\beginningfsharp\\ParsingText\\ParsingText"
#r "FParsec.dll"
#r "FParsecCS.dll"

open FParsec

(*
there are interfaces changes since last FParser libraries

check the following code on the ParserResult type

type ParserResult<'Result,'UserState> =
     /// Success(result, userState, endPos) holds the result and the user state returned by a successful parser,
     /// together with the position where the parser stopped.
     | Success of 'Result * 'UserState * Position
     /// Failure(errorAsString, error, suserState) holds the parser error and the user state returned by a failing parser,
     /// together with a string representation of the parser error.
     | Failure of string * ParserError * 'UserState

*)

let parseAndPrint input =   
    let result = CharParsers.run  CharParsers.pfloat input
    match result with 
//    | CharParsers.Success (result, _, _) ->
    | ParserResult.Success (result, _, _) ->
        printfn "Result: %A" result
//    | CharParsers.Failure (_, errorDetails, _) ->
    | ParserResult.Failure (_, errorDetails, _) ->
        printfn "Error details: %A" errorDetails

parseAndPrint "3.1416"
parseAndPrint "  3.1416"
parseAndPrint "Not a number"

(*

Result: 3.1416
Error details: Error in Ln: 1 Col: 1
Expecting: floating-point number

Error details: Error in Ln: 1 Col: 1

Expecting: floating-point number

*)