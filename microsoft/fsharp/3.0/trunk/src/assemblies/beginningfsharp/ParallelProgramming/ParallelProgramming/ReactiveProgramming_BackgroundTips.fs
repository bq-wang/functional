module ReactiveProgramming_BackgroundTips

// what will be covered in this chapter
//      1. how to handle the asynchronous result that might comes back in different order 

//module Strangelights.Extensions
let fibs =
    (1L, 1L) |> Seq.unfold
        (fun (n0, n1) -> 
            Some(n0, (n1, n0 + n1)))

let fib n = Seq.nth n fibs

(* 
we have seen in the previous ReactiveProgramming_Background.fs that we can improve the responsiveness by increasing the background. however, it has another pitfall/thread is that it does not guaranttee the result returns in
are orderd. 
,


we will show in this chapter a common technique where to show multiple result indepednently 
*)

//open Strangelights.Extensions
open System
open System.ComponentModel
open System.Windows.Forms
open System.Numerics

// define a type to hold the results 

(* seems that you cannot directly convert between the biginteger to int 64 *)
//type Result = {
//    Input : int;
//    Fibonnaci : BigInteger;  }

type Result = { 
    Input : int;
    Fibonnaci : int64; } 

let form = 
    let form = new Form()
    // input text box
    let input = new TextBox()
    // button to launch processing
    let button = new Button(Left = input.Right + 10, Text = "Go")
    // list to hold the results (* --- here we have a BindingList to hold the result, and we will use the binding list show the data to the DataGridView --- *)
    let results = new BindingList<Result>()
    // data grid view to display multiple resutls 
    let output = new DataGridView(Top = input.Bottom + 10, Width = form.Width,
                            Height = form.Height - input.Bottom + 10,
                            Anchor = (AnchorStyles.Top ||| AnchorStyles.Left |||
                                    AnchorStyles.Right ||| AnchorStyles.Bottom),
                            DataSource = results)

    // create and run a new Background worker
    let runWorker() = 
        let background = new BackgroundWorker()
        // parse the input to an int
        let input = Int32.Parse(input.Text)
        // add the "work" event handler
        background.DoWork.Add(fun ea ->
            ea.Result <- (input, fib input))
        // add the work completed event handler
        background.RunWorkerCompleted.Add(fun ea ->
//            let input, result = ea.Result :?> (int * BigInteger)
            let input, result = ea.Result :?> (int * int64) 
            results.Add({ Input = input; Fibonnaci = result; } ))
        // start the worker off 
        background.RunWorkerAsync()
       
    // hook up creating and running the worker to the button 
    button.Click.Add(fun _ -> runWorker () )
    // add the control
    let dc c = c :> Control
    form.Controls.AddRange([| dc input; dc button; dc output |])
    // return the form
    form

// show the form
//do Application.Run(form)

form.Visible <- true
//form.Show()