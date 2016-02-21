module PatternMatching
// you can as well check the following 
//  http://msdn.microsoft.com/en-us/library/dd547125.aspx
// Pattern Matching (F#)


// pattern matching can be applied in many a scenario
//  types
//  values 
//  exceptions 

// definition of Lucas members using pattern matching 

// there are 
//   constants rules
//   variable rules (sometimes can be used as the wildcards pattern)
// 
// there are somethings about the pattern rule  
//  a rule can have condition or a filter for the case 
//  a rule have a rule expression, , which is separate from the  pattern (the literals and the variable)  with the -> 


let rec luc x = 
    match x with 
    |   x when x <= 0 -> failwith "value must be greater than 0"
    |   1 -> 1
    |   2 -> 3
    |   x -> luc(x - 1) + luc(x - 2)

// call the function and print the results 

printfn "(luc 2) = %i" (luc 2)
printfn "(luc 6) = %i" (luc 6)
printfn "(luc 11) = %i" (luc 11)
printfn "(luc 12) = %i" (luc 12)

// the first | can be omitted
//   use this when  the pattern is small and you wan to fit it in a single line 

let booleanToString x = 
    match x with false -> "False" | _ -> "True"

// you can combine two patterns into one 
// function for converting a boolean to a string 
// _ is catch all handler
// or we called that the "wildcard pattern"
let stringToBoolean x = 
    match x with 
    | "True" | "true" -> true
    | "False" | "false" -> false
    | _ -> failwith "unexpected input"

// call the functions and print the results 
printfn "booealnStream true) = %s" (booleanToString true)
printfn "booealnStream true) = %s" (booleanToString false)
printfn "booealnStream \"True\") = %b" (stringToBoolean "True")
printfn "booealnStream \"false\") = %b" (stringToBoolean "false")
printfn "booealnStream \"Hello\") = %b" (stringToBoolean "Hello")

// matches on different types 

// pattern matching on tuples. 
let myOr b1 b2 = 
    match b1, b2 with 
    | true, _ -> true 
    | _, true -> true 
    | _ -> false

let myAnd p = 
    match p with 
    | true, true -> true 
    | _ -> false

printfn "(myOr true false) = %b" (myOr true false)
printfn "(myOr false false) = %b" (myOr false false)
printfn "(myAnd (true, false)) = %b" (myAnd (true, false))
printfn "(myAnd (true, true)) = %b" (myAnd (true, true))

// the keyword function...

// check on http://msdn.microsoft.com/en-us/library/dd233242.aspx
//  Match expression syntax: 

//match test-expression with
//    | pattern1 [ when condition ] -> result-expression1
//    | pattern2 [ when condition ] -> result-expression2
//    | ...
//
//// Pattern matching function.
//function
//    | pattern1 [ when condition ] -> result-expression1
//    | pattern2 [ when condition ] -> result-expression2
//    | ...

// as above, the leading '|' cannot be omitted . 
let rec concatStringList lis = 
    match lis with
    | [] -> ""
    | head :: tail -> head + concatStringList tail


// concatenate a list of strings into single string
let rec conactStringList =
    function 
    | head :: tail -> head + conactStringList tail
    | [] -> ""

// test data 
let jabber = ["'Twas "; "brillig, "; "and "; "the "; "slithy "; "toves "; "..."]
// call the function 
let compleJabber = conactStringList jabber
// print the result 
printfn "%s" compleJabber