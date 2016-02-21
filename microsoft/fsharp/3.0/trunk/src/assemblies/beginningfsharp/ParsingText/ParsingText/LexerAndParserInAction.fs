module LexerAndParserInAction

// in this chapter we will cover the following
//   1. it is more common to see that the lexer and paser work together 


(*

as a prerequisite to the rule, you will need to first create the fsyacc.exe

fsyacc.exe Fsyacc.fsy --module Strangelights.ExpressionParser.Parser

and you have to put the generated "Fsyacc.fs" file before the "Fslex.fs" file 


*)

open System.Text
open Microsoft.FSharp.Text.Lexing

(*

REMEMBER to import the generated lexer
*)
open Strangelights.ExpressionParser

let lexbuf3 = 
    LexBuffer<byte>.FromBytes(Encoding.ASCII.GetBytes("(1 * 1) + 2"))
let e = Parser.Expression Lexer.token lexbuf3
printfn "%A" e

printfn "Done"

(*

the output is as follow 

Plus (Multi (Val 1.0,Val 1.0),Val 2.0)

*)