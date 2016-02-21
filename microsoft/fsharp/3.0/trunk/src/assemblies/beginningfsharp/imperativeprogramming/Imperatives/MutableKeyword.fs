module MutableKeyword

// 

// a mutable identifier

let mutable phrase = "how can I be sure ,"

// print the phrase
printfn "%s" phrase

// update the phrase
phrase <- "In a world that's constantly changing"

// reprint the phrase
printfn "%s" phrase

// first glance it does not look quite difference, but you can  use
// `left arrow ` to update a mutable identifiers. 
let mutable number = "one"

// you can change value but not type 
//phrase <- 1



// the other major difference when it is combined with the scope rule (when changes are visible)

// demonstarte of redefining X
let redefineX() = 
    let x = "One"
    printfn "Redefining: \r\nx = %s" x
    if true then 
        let x = "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// demonstarte of mutating X
let mutableX() = 
    let mutable x = "One"
    printfn "Mutating: \r\nx = %s" x
    if true then
        // compare the 
        //  let x = "Two"
        x <- "Two"
        printfn "x = %s" x
    printfn "x = %s" x

// run the demos

redefineX()
mutableX()


// identifiers defined as mutable are somewhare limited because you can't use them within a subfunciton. as the below 

let mutableY() =
    let mutable y = "One"
    printfn "Mutating: \r\nx = %s" y 
    let f () = 
        // this causes an error as 
        // mutable can't be capture
//        y <- "Two" 
//        printfn "x = %s" y
        ()
    f()
    printfn "x = %s" y
