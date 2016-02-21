module ControlFlow

// F# has strong notion of control flow 

let result = 
    if System.DateTime.Now.Second % 2 = 0 then 
        "heads"
    else
        "tails"


printfn "%A"  result 

// if ... then .. else is an convenient shorthand for pattern matching over a bolean value. 

let result = 
    match System.DateTime.Now.Second % 2 = 0 with 
    | true -> "heads"
    | false -> "tails"

// F# type systems requires that the value being returned by the if ... then ... else expression must be the same type . 

// this fail, because , type mismatch 

//let result = 
//    match System.DateTime.Now.Second % 2 = 0 with 
//    | true -> "heads"
//    | false -> false

// however, this is valid in if ... then ... else... because it will promote that to the "obj..."
// NOTE: the functional if ... then ... else must have an else parts
let result = 
    if System.DateTime.Now.Second % 2 = 0 then 
        box "heads"
    else
        box false

printfn "%A" result 