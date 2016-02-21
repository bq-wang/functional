module Scope_InnerScope

// we will discuss Inner Scope 
// when local identifier redefined in inner scope, the value stays the same when the inner scope exits.

let printMessages() =
    // define message and print it
    let message = "Important"
    printfn "%s" message;
    // define an inner function that redefines values of message
    let innerFun () = 
        let message = "Very Important"
        printfn "%s" message
    // call the inner function 
    innerFun()
    // finally print the first message again
    printfn "%s" message