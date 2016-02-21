//module InterpretAST

// what will be covered in this chapter include the following 
//   1. some introduction on the compiler front-end and the compiler's back-end
//   2. we will in this chapter explore how to interpret it (the AST) - walking the tree and performing actions as you go 
//   3. we will later introduce how you can go compile the code and make it some executable piece and then let the machine to execute the code.


(*

below is the data structure that we might be using to do the Abstract syntax tree

type Ast =
| Ident of string
| Val of System.Double
| Multi of Ast * Ast
| Div of Ast * Ast
| Plus of Ast * Ast
| Minus of Ast * Ast


why F# is good representing the AST? it is bacause the union tpye in FSharp makes it good to represetn items that are related yet do not share the same structure 
*)
namespace Strangelights.Expression

open System
open System.Collections.Generic
open Strangelights.Expression

module Interpret = 

// requesting a value for variable from the user
let getVariableValues e = 
    let rec getVariableValuesInner input (variables: Map<string, float>) = 
        match input with 
            | Ident (s) ->
                match variables.TryFind(s) with  
                | Some _ -> variables
                | None -> 
                    printf "%s: " s
                    let v = float(Console.ReadLine())
                    variables.Add(s, v)
            | Multi (e1, e2) ->
                variables
                |>  getVariableValuesInner e1
                |>  getVariableValuesInner e2
            | Div (e1, e2) ->
                variables
                |>  getVariableValuesInner e1
                |>  getVariableValuesInner e2
            | Plus (e1, e2) ->
                variables
                |>  getVariableValuesInner e1
                |>  getVariableValuesInner e2
            | Minus (e1, e2) ->
                variables
                |>  getVariableValuesInner e1
                |>  getVariableValuesInner e2
            | _ -> variables
    getVariableValuesInner e (Map.empty)

// function to handle the interpretation
let interpret input (variableDict : Map<string, float>) = (* you cannot just do Map <string, float> which may have some  other interpretation which is very badly *)
    let rec interpretInner input = 
        match input with 
        | Ident (s) -> variableDict.[s]
        | Val (v) -> v
        | Multi (e1, e2) -> (interpretInner e1) * (interpretInner e2) 
        | Div (e1, e2) -> (interpretInner e2) / (interpretInner e2) 
        | Plus (e1, e2) -> (interpretInner e2) + (interpretInner e2) 
        | Minus (e1, e2) -> (interpretInner e2) - (interpretInner e2) 
    interpretInner input

// the expression to be interpreted
let e = Multi(Val 2., Plus (Val 2., Ident "a"))

// collect the arguments from the user 
let args = getVariableValues e
// interpret the expression 
let v = interpret e args

// printf the results 
printf "result: %f" v

