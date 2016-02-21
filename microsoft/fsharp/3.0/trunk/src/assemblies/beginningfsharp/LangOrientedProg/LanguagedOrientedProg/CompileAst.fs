//module CompileAst

// what will be include in this chapter incldue the following 
//  1. compiling the AST

(*

what will actually be covered in this chapter include how to use the AST and compile the code into
IL code and then try to execute the compiled AST in terms of Machine code 

the following assemblies might be needed in order to performs such operations

Microsoft.CSharp.CSharpCodeProvider.dll
System.CodeDom.dll
FSharp.Compiler.CodeDom.dll - CodeDome provider to build up assemblies using IL. IL offers more features than either F#, C# or System.CodeDom.
System.Reflection.Emit.dll  - allows you to build up assemblies using IL.
Mono.Cecil.dll  - htis is a library that used in the Mono framework for both parsing assemblies and dynamically creating them


*)

module Strangelights.Expression

open System
open System.Collections.Generic
open System.Reflection
open System.Reflection.Emit

open Strangelights.Expression

module Compile = 

// get a list of parameter names
let rec getParamList e = 
    let rec getParamListInner e names = 
        match e with 
        | Ident name ->
            if not (List.exists (fun s -> s = name) names) then 
                name :: names
            else
                names
        | Multi (e1, e2) ->
            names 
            |> getParamListInner e1
            |> getParamListInner e2
        | Div (e1, e2) -> // becareful not to write something as Div(e1, e2), which means more like a  function call
            names 
            |> getParamListInner e1
            |> getParamListInner e2
        | Plus (e1, e2) ->
            names
            |> getParamListInner e1
            |> getParamListInner e2
        | Minus (e1, e2) ->
            names 
            |> getParamListInner e1
            |> getParamListInner e2
        | _ -> names
    getParamListInner e []

// create the dynamic methods 
let createDynamicMethod e (paramNames : string list) =
    let generateIL e (il : ILGenerator) =
        let rec generateILInner e =
            match e with 
            | Ident name ->
                let index = List.findIndex (fun s -> s = name) paramNames
                il.Emit (OpCodes.Ldarg, index)
            | Val x -> il.Emit(OpCodes.Ldc_R8, x)
            | Multi (e1, e2) ->
                generateILInner e1
                generateILInner e2
                il.Emit(OpCodes.Mul)
            | Div (e1, e2) ->
                generateILInner e1
                generateILInner e2
                il.Emit(OpCodes.Div)
            | Plus (e1, e2) ->
                generateILInner e1
                generateILInner e2
            | Minus (e1, e2) ->
                generateILInner e1
                generateILInner e2
                il.Emit(OpCodes.Sub)
        generateILInner e
        il.Emit(OpCodes.Ret)
    let paramsTypes = Array.create paramNames.Length (typeof<int>)
    let meth = MethodInfo.GetCurrentMethod()
    let temp = new DynamicMethod("", (typeof<float>), paramsTypes, meth.Module)
    let il = temp.GetILGenerator()
    generateIL e il
    temp

// function to read the arguments from the command line 
let collectArgs (paramNames: string list) = 
    paramNames
    |> Seq.map 
        (fun n ->
            printf "%s: " n
            box (float(Console.ReadLine())))
    |> Array.ofSeq

// the expression to be interpreted
let e = Multi(Val 2., Plus(Val 2., Ident "a"))

// get a list of all the parameters from the expression
let paramNames = getParamList e 

// compile the tree to a dynamic method 
let dm = createDynamicMethod e paramNames

// print collect arguments from the user 
let args = collectArgs paramNames

// execute and print out the final result 
printfn "result: %O" (dm.Invoke(null, args))


