module UnitType

// Unit type

// indentation is important

// System.Void, 
// a function that doesn’t accept or return a value might not seem interesting because a function that doesn’t accept or return a value doesn’t do 
// anything. In the imperative paradigm, you know that side effects exist, so even if a function accepts or returns nothing, you know it can still have its uses.
// The unit type is represented as a literal value, or a pair of parentheses (())
// 
// don't every write as 
//let aFunction = 
//    ()
let aFunction() = 
    ()

// call a function that does not return a value 
let () = aFunction()
// -- or --
//    with the keyword dp
do aFunction()

// -- or -- 
//    just simply call
aFunction()


let poem() = 
    printfn "I wandered lonly as a cloud"
    printfn "That floats on high o'er vales and hills,"
    printfn "When all at once I saw a crowd,"
    printfn "A host, of golden daffodils"

do poem()

// it is not quite true that the only functions that return a unit type can be used in this manner

let getShorty() = "shorty"

//The underscore tells the compiler this is a value in which you aren’t interested
let _ = getShorty()

// -- or -- 
// ignore  is available in the F# base libraries
ignore(getShorty())

// -- or -- 
// pass-forward operator, we will see later 
getShorty() |> ignore

