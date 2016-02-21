module Scope_UseBinding

// this is equivalent to the using in C#, where the IDisposable will be called on scope dropped out of scope

open System.IO

// function to read first line from a file
let readFirstLine filename = 
    // open file using a "use" binding 
    use file = File.OpenText filename
    file.ReadLine()

// call function and print the result
printfn "First line was: %s" (readFirstLine "mytext.txt")