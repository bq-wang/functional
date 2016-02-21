//module UsingUnionType_EasyModule

module Strangelights.UseUnionType_EasyQuantity

open System

// type that can represent a discrete or continuous quantity
// with members to improve interoperability

type EasyQuantity = 
    | Discrete of int
    | Continuous of float 
    // convert quantity to a float 
    member x.ToFloat() = 
        match x with 
        | Discrete x -> float x 
        | Continuous x -> x
    // convert quantity to an integer
    member x.ToInt() = 
        match x with 
        | Discrete x -> x
        | Continuous x -> int x

// initialize random number generator 
let rand = new Random() 

// create a random quantity 
let getRandomEasyQuantity() = 
    match rand.Next(1) with 
    | 0 -> EasyQuantity.Discrete (rand.Next())
    | _ ->
        EasyQuantity.Continuous
            (rand.NextDouble() * float (rand.Next()))