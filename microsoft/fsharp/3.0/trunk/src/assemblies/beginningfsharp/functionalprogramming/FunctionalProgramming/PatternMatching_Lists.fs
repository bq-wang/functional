module PatternMatching_Lists

// 
// list to be concatenated
let listOfList = [[2; 3; 5]; [7; 11; 13]; [17; 19; 23; 29]]

// definition of a concatenation function 
let rec concatList l = 
    match l with 
    | head :: tail -> head @ (concatList tail) 
    | [] -> []


// call the functio 
let primes = concatList listOfList

//print the results 
printfn "%A" primes

// function that attempts to find various sequences

let rec findSequence l = 
    match l with 
    | [x; y; z] -> 
        printfn "Last 3 numbers in the list were %i %i %i"
            x y z
    // match a list of 1, 2, 3 in a row
    | 1 :: 2 :: 3 :: tail -> 
        printfn "Found sequence 1, 2, 3 within the last"
        findSequence tail
    // if neither case matches and items remains 
    // recursively call the function 
    | head :: tail -> findSequence tail
    // if no items remain terminate
    | [] -> ()
// some test data

let testSequence = [1; 2; 3; 4; 5; 6; 7; 8; 9; 8; 7; 6; 5; 4; 3; 2; 1]

// call the function 
findSequence testSequence


// High-order function that helps you to use the pattern matching and others. 

// without the high-order function 
let rec addOneAll list = 
    match list with 
    |head :: rest -> 
        head + 1 :: addOneAll rest
    | [] -> []

printfn "(addOneAll [1; 2; 3]) = %A" (addOneAll [1; 2; 3])

// with a map function 
let rec map func list =
    match list with 
    | head :: rest -> 
        func head :: map func rest
    | [] -> []

// so we can use the map function that we have just developed
// check on the result, it has the following. 
//
// List.map ((+) 1 [1; 2; 3] = [2; 3; 4]
// val result : int list = [2; 3; 4]

let result = List.map ((+) 1) [ 1; 2; 3]

printfn "List.map ((+) 1 [1; 2; 3] = %A" result 
