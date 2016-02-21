module MutableKeyword


// what will be covered in this chapter include the following
//   1. the syntax to define and update the value of mutable fields
//   2. gotchas on the mutable fields
//     2.1. you cannot change the type of the update fields (you can with rebinding)
//     2.2. rebinding has scope rule, while mutating fields can be visible outside
//     2.3. mutalbe fiels are not allowed to be used in closure, to use closue with updatable fiels, you should use "ref" and "!"

// you can redefine the bindign with the let bindings but you cannot modify these identifiers
// 

// to declare a mutable fields
// 
//  the mutable keyword
//   let mutable phrase = "how can I be sure, "
// and to update the mutable fields, you can use the <- operator
//   phrase <- "In a world that's constantly changing"

// a mutable identifier
let mutable phrase = "How can I be sure,"

// print the phrase
printfn "%s" phrase

// update the phrase
phrase <- "In a word that's constantly changing"
// reprint the phrase 
printfn "%s" phrase


// you are not allowed to change the type of the variable
//let mutable number = "one"
//phrase <- 1


// the ohter major difference is where these changes are visbile. 

// demonstration of redefining X
let redefineX() = 
    let x= "one"
    printfn "Redefining: \r\nx = %s" x
    if true then    
        let x = "two"
        printfn "x = %s" x
    printfn "x = %s" x

// demonstration of mutating X
let mutableX() =
    let mutable x = "One"
    printfn "Mutating:\r\nx = %s" x
    if true then
        x <- "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// run the demos
redefineX()
mutableX()

//mutable fiels cannot be used inside a closure 
//
//let mutableY() = 
//    let mutable y = "One"
//    printfn "Mutating: \r\nx = %s" y
//    let f() = 
//        // this causes an error as 
//        // mutable can't be captured
//        y <- "Two"
//        printfn "x = %s" y 
//    f() 
//    printfn "x = %s" y
