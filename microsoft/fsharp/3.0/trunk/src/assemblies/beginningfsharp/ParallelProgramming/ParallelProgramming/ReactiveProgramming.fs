module ReactiveProgramming

// what will be covered in this chapter include the the follwing contents:
//    1. Reactive prpogramming how to make a program reactive 


(*
As an example that we will use a BackgroundWorker class to handle 
*)

//module Strangelights.Extensions
let fibs =
    (1L, 1L) |> Seq.unfold
        (fun (n0, n1) -> 
            Some(n0, (n1, n0 + n1)))

let fib n = Seq.nth n fibs

// creating a simple GUI for this calculation is straightforward, you can do this using the Winforms GUI toolkit you saw in chapter 8 

//open Stranglights.Extensions
open System
open System.Windows.Forms
(* show how to use the long runnng operation *)


let form = 
    let form = new Form()
    // input the text box
    let input = new TextBox()
    // a button to launch processing
    let button = new Button(Left = input.Right + 10, Text = "Go") 
    // label to display the result 
    let output =  new Label(Top = input.Bottom + 10, Width = form.Width,
                            Height = form.Height - input.Bottom + 10,
                            Anchor = (AnchorStyles.Top ||| AnchorStyles.Left |||
                                    AnchorStyles.Right ||| AnchorStyles.Bottom ))
    // do all the work when the button is clicked
    button.Click.Add(fun _ ->
        output.Text <- Printf.sprintf "%A" (fib (Int32.Parse(input.Text))))
    // add the controls
    let dc c = c :> Control
    form.Controls.AddRange([|dc  input; dc button; dc output |]);
    // returns the form 
    form


// show the form
form.Show()
form.Visible <- true
//do Application.Run(form) 

