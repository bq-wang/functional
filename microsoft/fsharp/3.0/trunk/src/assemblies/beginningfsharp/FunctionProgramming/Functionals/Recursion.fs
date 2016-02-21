module Recursion

// Recursion , we have the rec keyword, for the recursion 
// Question, why we need the 'rec" keywrod 

let rec fib x = 
    match x with 
    | 1 -> 1
    | 2 -> 1
    | x -> fib (x - 1) + fib (x - 2)

// call the function and print the results 
printfn "(fib 2) = %i" (fib 2)
printfn "(fib 6) = %i" (fib 6)
printfn "(fib1) = %i" (fib 11)


