﻿module PaserInAction

// in this chapter we will cover the following
//   1. how to use the Parser that are generated by the fsyacc.exe 


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

let lexbuf2 = 
    LexBuffer<byte>.FromBytes(Encoding.ASCII.GetBytes("(1 * 1) + 2"))
while not lexbuf2.IsPastEndOfStream do
    let token = Lexer.token lexbuf2 
    printfn "%A" token

printfn "Done"

(*

the output is as follow 

LPAREN
FLOAT 1.0
MULTI
FLOAT 1.0
RPAREN
PLUS
FLOAT 2.0
EOF

*)