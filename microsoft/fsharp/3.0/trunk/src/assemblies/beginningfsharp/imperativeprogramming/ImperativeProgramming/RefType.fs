module RefType

// what will be covered in this chapter include the following.
//   1. the ref type 
//   2. ref type as a record that uses type parameterization
//   3. ref type is useful in closure, comparing to the DefininigMutableRecordTypes.

// syntax
//  1. define a ref type variable
//       let identifier = ref identifier-value
//  2. update the ref type
//       ref-variable := expression
//  3. how to get the value of a ref type variable
//       !ref-variable


// the ref type is a simple way for a program to use mutable state
//  or values that change over time 
// the ref type is a record type with a single mutable fields that is defined in the F# libraries.
// in 

let phrase = ref "Inconsistency"

let totalArray () = 
    // define an array literal
    let array = [| 1; 2; 3 |]
    // define a counter
    let total = ref 0
    // loop over the array 
    for x in array do 
        // keep a running total
        total :=  !total + x
    // print the total
    printfn "total: %i" !total

totalArray()
// with ref type, it is very useful to share mutable values between several functions. An identifiers can be bound to a 
// a ref type defined in scope that is common to all functions that want to use the value. 

// capture the inc, dec and show functions
let inc, dec, show = 
    // define the shared state
    let n = ref 0 
    // a function to increment
    let inc() =
        n := !n + 1
    // a function to decrement
    let dec() = 
        n := !n - 1
    // a function to show the current state
    let show () =
        printfn "%i" !n

    // return the functions to the top level
    inc, dec, show

// test the functions 
inc() 
inc()
dec()
show()