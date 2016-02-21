module TheUseBinding

// in this chapter, what we will be covering the following
//  1. the use binding - which implement the Disposing methods
//  


open System.IO

// a function to read first line from a file 
let readFirstLine filename = 
    // open file using a "use" binding 
    use file = File.OpenText filename
    file.ReadLine()

// call function and print the result 
printfn "First line was : %s" (readFirstLine "mytext.txt")

