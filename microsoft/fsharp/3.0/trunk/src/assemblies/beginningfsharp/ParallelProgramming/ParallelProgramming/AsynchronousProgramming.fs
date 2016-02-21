module AsynchronousProgramming

// a function to read a text file asynchronously 

#I "C:\ProgramFiles(x86)\FSharpPowerPack-4.0.0.0\bin"
#r "FSharp.PowerPack"

open System.IO


(* 
what is the meaning and use of the let! operator?

The most important thing to notice about this example is the let followed by an explanation mark
(let!), often pronounced * let bang. *

the workflow/monadic syntax allows librar writer to give different meaning to let!. 

It the case of asynchronous workflow, it means that a asynchronous operation will take place.  

the special syntax called "async" , These functions are defined as type augmentations, which are F#’s equivalent of C#’s
**extension methods**, in FSharp.PowerPack.dll.

let's explain the details of the execution 

1. start process of opening the file stream.  callback in placed in thread pool can be used when it is complete. the main thread is now free to continue doing other work.
2. a thread pool will activate when the file stream has been opened, it will start reading the contents of the file and place a callback in thread pool that can be used this complete. 
3. thread pool therads will activate when the files has been completed read , it will return to the thread pool. 
4. Because you have used the Async.RunSynchronously function.  the main thread is wait the results of the workflow, it will receive the file content. 

*)


let readFile file  = 
    async { let! stream = File.AsyncOpenText(file)
            let! fileContents = stream.AsyncReadToEnd()
            return fileContents }

// create a instance of hte workflow 
let readFileWorkflow = readFile "mytextfile.txt"

// invoke the workflow and get the content 
let fileContents = Async.RunSynchronously readFileWorkflow
