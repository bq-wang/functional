module ReactiveProgramming_Background

// what will be covered in the following chapter include the following 
//    1. convert Reactive programming to async reactive programming

//module Strangelights.Extensions
let fibs =
    (1L, 1L) |> Seq.unfold
        (fun (n0, n1) -> 
            Some(n0, (n1, n0 + n1)))

let fib n = Seq.nth n fibs

//open Strangelights.Extensions
open System
open System.ComponentModel
open System.Windows.Forms

let form = 
    let form = new Form()
    // input text box
    let input = new TextBox()
    // button to launch processing
    let button = new Button(Left = input.Right + 10, Text = "Go")
    // label to display the result
    let output = new Label(Top = input.Bottom + 10, Width = form.Width,
                            Height = form.Height - input.Bottom + 10,
                            Anchor = (AnchorStyles.Top ||| AnchorStyles.Left |||
                                    AnchorStyles.Right ||| AnchorStyles.Bottom))
    // create and run a new background worker  (* why it does not count in the effort to  dispatch the result back, seems that it passes the value in band with the AsyncResult arguments  *)
    let runWorker() = 
        let background = new BackgroundWorker() 
        // parse the input to an int 
        let input = Int32.Parse(input.Text)
        // add the "work" event handler
        background.DoWork.Add(fun ea ->
            ea.Result <- fib input) 
        // add the work completed event handler
        background.RunWorkerCompleted.Add(fun ea ->
            output.Text <- Printf.sprintf "%A" ea.Result)
        // start the worker off 
        background.RunWorkerAsync()
    // hook up creating and running the worker to the button
    button.Click.Add(fun _ -> runWorker())

    // add the controls
    let dc c = c :> Control
    form.Controls.AddRange([| dc input; dc button; dc output |])
    // return the form 
    form 

// show the form 
form.Show()
form.Visible <- true 
//do Application.Run(form) 