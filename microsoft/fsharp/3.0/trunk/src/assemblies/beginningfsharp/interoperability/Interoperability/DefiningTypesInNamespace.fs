//module DefiningTypesInNamespace

// what will be covered in this chatper include the following 
//  1. defining type in a namespace

(*

defining types inside namespace is a general rule that helps imrpove the compatability of the FSharp ineroperability


*)

namespace Strangelights

open System.Collections.Generic

// this is a counter class 
type TheClass(i) = 
    let mutable theField = i
    member x.TheField 
        with get() = theField
    // increments the counter 
    member x.Increment() = 
        theField <- theField + 1
    // descrement the counter 
    member x.Decrement() = 
        theField <- theField - 1

// this is a module for working with theClass
module TheModule = begin 
    // incremens a list of TheClass
    let incList (theClasses: List<TheClass>) = 
        theClasses |> Seq.iter (fun c -> c.Increment())
    // decrement a list of TheClass
    let decList (theClasses: List<TheClass>) = 
        theClasses |> Seq.iter (fun c -> c.Decrement())
end