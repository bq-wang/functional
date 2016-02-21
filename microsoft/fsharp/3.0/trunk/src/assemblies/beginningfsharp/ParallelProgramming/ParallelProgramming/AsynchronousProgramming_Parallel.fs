module AsynchronousProgramming_Parallel

// what will be covered in this chapter include the following 
//   1. moidfy the program in the AsynchronousProgramming and show how you can leverage the power of the Asynchronous programming 


open System
open System.IO
open System.Threading

let print s = 
    let tid = Thread.CurrentThread.ManagedThreadId
    Console.WriteLine(sprintf "Thread %i; %s" tid s) 

let readFileSync file = 
    print (sprintf "Beginning file %s" file)
    let stream = File.OpenText(file)
    let fileContents = stream.ReadToEnd()
    print (sprintf "Ending file %s" file)
    fileContents

// invoke the workflow and get the contents
let filesContents =
    [| readFileSync "text1.txt";
        readFileSync "text2.txt";
        readFileSync "text3.txt"; |]

// this program is fairly straightforward, we rewrite that in asynchronous programmin g

open System
open System.IO
open System.Threading

//let print s =
//    let tid = Thread.CurrentThread.ManagedThreadId
//    Console.WriteLine(sprintf "Thread %i: %s" tid s)


// a function to read text file asynchronously 
let readFileAsync file =
    async {  
        do print (sprintf "Beginning file %s" file)
        let! stream = File.AsyncOpenText(file)
        let! fileContents = stream.AsyncReadToEnd()
        print (sprintf "Ending file %s" file)
        return fileContents
    }

let fileContentsAsync = 
    Async.RunSynchronously
        (Async.Parallel [ readFileAsync "text1.txt";
                          readFileAsync "text2.txt";
                          readFileAsync "text3.txt"; ])