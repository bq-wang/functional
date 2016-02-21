module ThreadsMemoryLockingAndBlocking

// what will be covered in this chapter 
//   1. how to manually create a thread from a delegate and start the thread in question

open System.Threading

let main() = 
    // create a new thread passing it a lambda function  
    let thread =  new Thread(fun () ->
        // print a message to the newly created thread 
        printfn "Created thread: %i " Thread.CurrentThread.ManagedThreadId)
    // starts the new thread
    thread.Start()

    // print an message on the original thread
    printfn "Original thread: %i" Thread.CurrentThread.ManagedThreadId
    // wait of the created thread to exit
    thread.Join()

do main()


(*

the output of this methods is as folllow 

Original thread: 1
Created thread: 4 

*)