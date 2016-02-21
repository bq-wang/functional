module Ref_Type

// The ref type is a simple way for a program to use mutable state, or values that change over time

// F#'s ref type use the what is so called "type parameterization"

// when defined: val phrase = : string ref
let phrase = ref "Inconsistency"

// two operators:
//  ! provides access to the value 
//  := enable you to update it 

// e.g.

let totalArray() = 
    // define an array literal
    let array =[| 1; 2; 3 |]
    // define a counter
    let total = ref 0
    // loop over the array 
    for x in array do 
        // kee[ a running total
        total := !total + x
    // print the total
    printfn "total: %i" !total

totalArray()


// closure and capture of the ref types 

// capture the inc, dec and show functions
let inc, dec, show = 
    // define the shared state 
    let n = ref 0 
    // a function to increment 
    let inc() = 
        n := !n + 1
    let dec () = 
        n := !n - 1
    let show() = 
        printfn "%i" !n
    // return the functions to the top level
    inc, dec, show

inc()
inc()
dec()
show()
