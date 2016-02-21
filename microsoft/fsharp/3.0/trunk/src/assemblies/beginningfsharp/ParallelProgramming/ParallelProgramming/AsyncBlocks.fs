module AsyncBlocks

// what will be covered in this chapter include the following .
//   1.  learn what is the so -called Asynchronous workflow 

(*

introduce to the asynchronous workflow

*)

// you will need to get hold of the FSharp.Powerpack.dll
#I "C:\ProgramFiles\FSharpPowerPack-2.0.0.0\bin"
#r "FSharp.Powerpack.dll"

open System.IO

// a function to read a text file asynchronously 
let readFile file = 
    async { let! stream = File.AsyncOpenText(file)
            let! fileContents = stream.AsyncReadToEnd()
            return fileContents } 

// create an instance of the workflow
let readFileWorkflow = readFile "mytextfile.txt"

// invoke the workflow and getst he contents
let fileContents = Async.RunSynchronously readFileWorkflow 

