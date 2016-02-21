//module ExposingFunctionsTakesFunctionsAsParams

// what will be covered in this chapter 
//  1. if you want to expose function shtat take other functions as parameters, the best way to do this is using delegates

module Strangelights.FuncsTakesFuncs
open System

/// a function that provides filtering 
let filterStringList f ra = 
    ra |> Seq.filter f

// another function that provides filtering 
let filterStringListDelegate(pred : Predicate<string>) ra = 
    let f x = pred.Invoke(x)
    new ResizeArray<string>(ra |> Seq.filter f)