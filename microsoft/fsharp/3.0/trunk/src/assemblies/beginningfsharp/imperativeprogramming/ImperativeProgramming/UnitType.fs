module UnitType

// what we will cover in this chapter
//  the Unit type 

// NOTE:
//  () is the literal for unit type (or you can think it as the void type in other language) 
let aFunction() = 
    ()

// how to call a function 

// three types of function call that you can call a unit type function 
// they are
//  1. let () = aFunction()
//  2. do aFunction()
//  3. aFunction()

// 
let () = aFunction() 
// -- or --
do aFunction()
// -- or --
aFunction() 

// you can chain the function that returns unit together within a function - simply make sure they all
// share the smae indentation 

let poem() = 
    printfn "I wandered lonley as a cloud"
    printfn "That floats on high o'er vales and hills,"
    printfn "when all at once I saw a crowd,"
    printfn "A host, of golden daffodil"
poem()

// how to throw away the values of the rsult of a function, so that the resuling function that reutnrs unit:
// 1. let _ = getShorty() 
// 2. ignore(getShorty())
// 3. getShorty() |> ignore
// NOTE:
//  reason that we don this is because using unit type function inside a type other than unit will generate warning
//  and programmer want to get rid of it


let getShorty() = "shorty"

let _ = getShorty() 
// -- or --
ignore(getShorty())
// --- or -- 
getShorty() |> ignore
