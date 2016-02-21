//module UsingUnionType

// what will be covered in this chapter 
//   1. how to use the union types 

module Strangelights.UseUnionType 

open System

// type that can represent a discrete  or continuous quantity 
type Quantity = 
| Discrete of int
| Continuous of float 

// initialize random number generator 
let mutable rand = new Random()

// create a random quantity 
let getRandomQuantity() = 
    rand <- new Random()
    match rand.Next(1) with 
    | 0 -> Quantity.Discrete (rand.Next())
    | _ -> Quantity.Continuous (rand.NextDouble() * float  (rand.Next()))
