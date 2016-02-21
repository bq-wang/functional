﻿module ThreadsMemoryLockingAndBlocking_Lock

open System
open System.Threading


// function to print to the console character by character
// this increases the chance of there being a context switch
// between threads.
let printSlowly(s : String) =   
    s.ToCharArray() 
    |> Array.iter (printf "%c")
    printfn ""



// create a thread that prints to the console in an unsafe way 
let makeUnsafeThread() = 
    new Thread(fun () ->
        for x in 1 .. 100 do 
            printSlowly "One .. Two.... Three ....")

// the object that will be used as a lock
let lockObj = new Object()

// create a thread tat prints to the console in a safe way 
let makeSafeThread() = 
    new Thread(fun () ->
        // use lock to ensure operation is atomic 
        (* you will get an error when you try to do the following..  lock lockObj(fun () -> printSlowly "one ... two ... three ...") , notice the space in between the lockObj and the left parenthesis *)
        lock lockObj ( fun () -> printSlowly "One ... Two ... Three ...") )

// helper function to run the test to 
let runTest(f : unit -> Thread) message = 
    printfn "%s" message
    let t1 = f() in 
    let t2 = f() in 
    t1.Start()
    t2.Start()
    t1.Join()
    t2.Join()


// runs the demonstations
let main() = 
    runTest 
        makeUnsafeThread
        "Running test without locking ..."
    runTest
        makeSafeThread
        "Running test with locking ...."

do main()