module Array_Comprehensions

// comprehension for array, we introduced the comprehension list and comprehension sequence before 

// an array of characters 
let chars = [| '1' .. '9' |]

// an array of tuples of number, square
let squares = 
    [| for x in 1 .. 9 -> x, x * x |]

// print out both arrays 
printfn "%A" chars
printfn "%A" squares


