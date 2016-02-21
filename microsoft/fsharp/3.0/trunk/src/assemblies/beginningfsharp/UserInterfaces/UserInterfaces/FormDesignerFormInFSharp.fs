//module FormDesignerFormInFSharp

[<AutoOpen>]
module Strangelights.Fibonacci 

// you can use the "#r" directive from the FSharp script or others.
// #r "UserInterfacesCSharpLib"

open Microsoft.FSharp.Control.LazyExtensions
open UserInterfacesCSharpLib

let fibs = 
        (1, 1) |> Seq.unfold
            (fun (n0, n1) ->
                Some(n0, (n1, n0 + n1)))

let getFib n = 
    Seq.nth n fibs


let form = 
    // create a new instance of the form 
    let temp = new UserInterfacesCSharpLib.FibForm()
    // add an event handler to the form's click event
    temp.Calculate.Click.Add
        (fun _ -> 
            // conver input to an integer
            let n = int temp.Input.Text
            // calculate the appropriate fibonacci number
            let n = getFib n
            // display result to user
            temp.Result.Text <- string n)
    temp

form.Visible <- true
//Application.Run(form)