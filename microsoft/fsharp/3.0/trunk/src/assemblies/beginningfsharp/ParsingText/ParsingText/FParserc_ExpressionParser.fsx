
module Strangelights.ExpressionParser.Ast

(*

that has been defiend elsewhere : check the Ast.fs file

*)
type Expr = 
    | Ident of string
    | Val of System.Double
    | Multi of Expr * Expr 
    | Div of Expr * Expr 
    | Plus of Expr * Expr
    | Minus of Expr * Expr


// in this chapter we will cover the following
//   1. show you an example on how to implement a algebric language (by example)

#I "C:\\dev\\workspaces\\functional\\microsoft\\fsharp\\3.0\\trunk\\src\\assemblies\\beginningfsharp\\ParsingText\\ParsingText"
#r "FParsec.dll"
#r "FParsecCS.dll"

open Strangelights.ExpressionParser.Ast
open FParsec
open FParsec.Primitives

//open FParsec.OperatorPrecedenceParser  (* for +/-, *// operators with defined precedence *)

// skips any whitespace
let ws = CharParsers.spaces

// skipss a character possibly postfixed with whitespaces
let ch c = CharParsers.skipChar c >>. ws

(* you cannot run just run this single line and hope that type inference system can works out the types of the number *)

// parses a floating point number ignoring any postfixed whitespace
let number = CharParsers.pfloat .>> ws |>> (fun x -> Val x) 


//  parses an identifier made up of letters
let id = 
    CharParsers.many1Satisfy CharParsers.isLetter
    |>>  (fun x -> Ident x)
    .>> ws

(*
check the following file " OperatorPrecedenceParser.cs" from the FParsecCS.dll

public class OperatorPrecedenceParser<TTerm, TAfterString, TUserState> : FSharpFunc<CharStream<TUserState>, Reply<TTerm>> \
*)

// create an new operator precedence parser
//let opp = new OperatorPrecedenceParser<_,_>()
let opp = new OperatorPrecedenceParser<_,_,_>()

// name the expression parser within operator precendence parser
// so it can be used more easily later on
let expr = opp.ExpressionParser
// create a parser to parse everything between the oeperator
let terms = 
    Primitives.choice 
        [id; number; ch '(' >>. expr .>> ch ')']
opp.TermParser <- terms

(*

check on the new operator

public sealed class InfixOperator<TTerm, TAfterString, TUserState> : Operator<TTerm, TAfterString, TUserState> {
    public InfixOperator(string operatorString,
                         FSharpFunc<CharStream<TUserState>, Reply<TAfterString>> afterStringParser,
                         int precedence,
                         Associativity associativity,
                         FSharpFunc<TTerm, FSharpFunc<TTerm, TTerm>> mapping)
           : base(operatorString, afterStringParser, precedence, associativity,
                  mapping == null ? null : new NoAfterStringBinaryMappingAdapter(OptimizedClosures.FSharpFunc<TTerm, TTerm, TTerm>.Adapt(mapping))) {}
    }

*)
// add the operators themselves
//opp.AddOperator(InfixOp("+", ws, 1, Assoc.Left, fun x y -> Plus(x, y)))
(* -- you can either use the following 

opp.AddOperator(InfixOperator("+", ws, 1, Associativity.Left, fun x y -> Plus(x, y)) )
opp.AddOperator(InfixOperator("-", ws, 1, Associativity.Left, fun x y -> Minus(x, y)) )
opp.AddOperator(InfixOperator("*", ws, 2, Associativity.Left, fun x y -> Multi(x, y)) )
opp.AddOperator(InfixOperator("/", ws, 2, Associativity.Left, fun x y -> Div(x, y)) )

or the following 

opp.AddOperator(InfixOperator("+", ws, 1, Associativity.Left, fun x y -> Plus(x, y)) :> Operator<_, _, _>)
opp.AddOperator(InfixOperator("-", ws, 1, Associativity.Left, fun x y -> Minus(x, y)) :> Operator<_, _, _>)
opp.AddOperator(InfixOperator("*", ws, 2, Associativity.Left, fun x y -> Multi(x, y)) :> Operator<_, _, _>)
opp.AddOperator(InfixOperator("/", ws, 2, Associativity.Left, fun x y -> Div(x, y)) :> Operator<_, _, _>)

*)

opp.AddOperator(InfixOperator("+", ws, 1, Associativity.Left, fun x y -> Plus(x, y)) )
opp.AddOperator(InfixOperator("-", ws, 1, Associativity.Left, fun x y -> Minus(x, y)) )
opp.AddOperator(InfixOperator("*", ws, 2, Associativity.Left, fun x y -> Multi(x, y)) )
opp.AddOperator(InfixOperator("/", ws, 2, Associativity.Left, fun x y -> Div(x, y)) )


// the complete expression that can be prefix with prefixed with whitespace
// and post fixed with an end of file character

let completeExpression = ws >>. expr .>> CharParsers.eof 

// define a function for parsing a string
let parse  s = CharParsers.run completeExpression s

// run some tests and print the results
printfn "%A" (parse "1.0 + 2.0 + toto")
printfn "%A" (parse "toto + 1.0 * 2.0")

// will give an error 
printfn "%A" (parse "1.0 +")

(*

Success: Plus (Plus (Val 1.0,Val 2.0),Ident "toto")
Success: Plus (Ident "toto",Multi (Val 1.0,Val 2.0))
Failure:
Error in Ln: 1 Col: 6
1.0 +
     ^
Note: The error occurred at the end of the input stream.
Expecting: floating-point number or '('


val ws : FParsec.Primitives.Parser<unit,'a>
val ch : char -> FParsec.Primitives.Parser<unit,'a>
val number : FParsec.Primitives.Parser<Expr,unit>
val id : FParsec.Primitives.Parser<Expr,unit>
val opp : FParsec.OperatorPrecedenceParser<Expr,unit,unit>
val expr : (FParsec.CharStream<unit> -> FParsec.Reply<Expr>)
val terms : (FParsec.CharStream<unit> -> FParsec.Reply<Expr>)
val completeExpression : FParsec.Primitives.Parser<Expr,unit>
val parse : string -> FParsec.CharParsers.ParserResult<Expr,unit>

*)
