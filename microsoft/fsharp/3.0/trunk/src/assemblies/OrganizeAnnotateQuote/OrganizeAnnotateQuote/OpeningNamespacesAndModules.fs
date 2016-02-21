module OpeningNamespacesAndModules

// in this chapter, we will discuss the following 
//    1. how to open the keyword 
//    2. two types module, one is to be used by directly import, the typical example is to use the operator within, and the other type is to 
//       be used in the qualified way

System.Console.WriteLine("Hello world")

open System

Console.WriteLine("Hello world")


// you don't necessary to fully qualified namespace names
open System.Collections
// create an instance of a dictionary 
let wordCountDict = 
    new Generic.Dictionary<string, int>()

// module of operators 
module MyOps = 
    // check equality via hash code 
    let (===) x y = 
        x.GetHashCode() = 
            y.GetHashCode()

// open the MyOps module 

open MyOps
// use the Triple equal operator 
let equal = 1 === 1
let nEqual = 1 === 2