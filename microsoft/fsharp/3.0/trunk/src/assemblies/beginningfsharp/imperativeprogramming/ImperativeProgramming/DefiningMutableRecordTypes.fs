module DefiningMutableRecordTypes

// in this chapter, we will cover the following
//     1. how to define record type with mutable fields



// record by default are immutable, and we want to make fields of the record type 
// as mutable, you can do by this 



// a record with mutalbe field
type Couple = { Her: string; mutable Him: string } 

// a create an instance of the record
let theCouple = { Her = "Elizabeth Taylor"; Him = "Nicky Hilton" } 


// a function to cahnge the content of the record over time

let changeCouple() =
    printfn "%A" theCouple
    theCouple.Him <- "Michael Wilding"
    printfn "%A" theCouple
    theCouple.Him <- "Michael Todd"
    printfn "%A" theCouple
    theCouple.Him <- "Eddie Fisher"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "Richard Burton"
    printfn "%A" theCouple
    theCouple.Him <- "John Warner"
    printfn "%A" theCouple
    theCouple.Him <- "Larry Fortensky"
    printfn "%A" theCouple
// call the fucntion
changeCouple()
