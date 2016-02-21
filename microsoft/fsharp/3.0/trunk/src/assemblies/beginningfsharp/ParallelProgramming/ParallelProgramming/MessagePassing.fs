module MessagePassing

// what will be covered in this chapter incldue the following 
//   1. how to do message passing 

#I "C:\ProgramFiles(x86)\FSharpPowerPack-4.0.0.0\bin"
#r "FSharp.PowerPack"

(*

it is often useful to think of a parallel program as a series of independent component that send and receive messages. 


we often referred to as the Actor model .- you can find more formal description of the actor model on the Wikipedia as follow. 
    http://en.wikipedia.org/wiki/Actor_model

The basic idea behind message passing is that a system is composed of agents, or actors. These can
both send and receive messages. ...


some notes here :
1. you will need the asynchronous workflow because it is typically a good practise to keep scalability because if you using a lots of mailboxs
2. you will need a tail recursive calls because otherwise it will cause overflow. 
3. the last console.ReadLine is needed because other processig regarding mail box is running ina  separate threads. 
*)

open System
let mailbox =  
    MailboxProcessor.Start(fun mb -> 
        let rec loop x = 
            async { let! msg = mb.Receive()
                    let x = x + msg
                    printfn "Running total : %i - new value %i" x msg
                    return! loop x } 
        loop 0)

mailbox.Post(1)
mailbox.Post(2)
mailbox.Post(3)

Console.ReadLine() |> ignore 

(*
the running results of the MessagePassing is as follow


Running total : 1 - new value 1
Running total : 3 - new value 2
Running total : 6 - new value 3

*)

(*

note below there is a 

return! methods 


*)


#I "C:\ProgramFiles(x86)\FSharpPowerPack-4.0.0.0\bin"
#r "FSharp.PowerPack"

open System
open System.Threading
open System.Windows.Forms
open System.Drawing.Imaging
open System.Drawing


// the width & Height for the simulation  
let width , height = 500, 600

/// the bitmap that will hold the output data 
let bitmap  = new Bitmap(width, height, PixelFormat.Format24bppRgb)

// a form to display the bitmap 
let form = new Form(Width =  width, Height = height, BackgroundImage = bitmap) 

// the function which receives that points to be plotted 
// marshalls to the GUI threads to plot them 

let printPoints points = 
    form.Invoke(new Action(fun () ->
        List.iter bitmap.SetPixel points
        form.Invalidate()))
    |> ignore 

// the mailbox that will be used to collect data 
let mailbox = 
    MailboxProcessor.Start(fun mb ->
        // main loop to read from the message queue 
        // the parameters "points" hold the working data
        let rec loop points = 
            async { 
                // read a message
                let! msg = mb.Receive()
                // if we have over 100 messages write 
                // message to the GUI 
                if List.length points > 100 then 
                    printPoints points
                    return! loop (msg :: points) } 
        loop [])

// start a worker thread running our fake simulation 
let startWorkerThread() = 
    // function that loops infinitely generating random
    // "simulation" data 
    let fakeSimulation() = 
        let rand = new Random()
        let colors = [| Color.Red; Color.Green; Color.Blue |]
        while true do 
            // post the random data to the mail box 
            // the sleep to simulate working being done 
            mailbox.Post(rand.Next(width),
                rand.Next(height),
                colors.[rand.Next(colors.Length)])
            Thread.Sleep(rand.Next(100))
    // start the thread as a background thread, so it won't stop 
    // the program exiting 
    let thread = new Thread(fakeSimulation, IsBackground = true) 
    thread.Start()


// start 5 instance of our simulation 
for _ in 0 .. 5 do startWorkerThread()


form.Visible <- true 
form.Show()

// run the form 
Application.Run form 



