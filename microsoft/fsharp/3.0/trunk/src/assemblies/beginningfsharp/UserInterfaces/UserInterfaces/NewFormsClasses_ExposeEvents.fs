module NewFormsClasses_ExposeEvents

// what will be covered in this chapter 
//  1. how to expose the Event from the form that is created from the custom form in FSharp 


(*

the event type is 

Microsoft.FSharp.Control.Event 

*)


open System.Windows.Forms

// a form with addation LeftMouseClick event 
type LeftClickForm() as x = 
    inherit Form() 
        // create the new event 
        let event = new Event<MouseEventArgs>()

        // wire the new event up so it fires when the left 
        // mouse button is clicked 
        do x.MouseClick 
            |> Event.filter (fun e -> e.Button = MouseButtons.Left)
            |> Event.add (fun e -> event.Trigger e)
    // expose the event as property 
    [<CLIEvent>]
    member x.LeftMouseClick = event.Publish


let form = 
    let temp = new LeftClickForm()
    temp.LeftMouseClick.Add(fun _ -> printfn "Function called")
    temp

form.Visible <- true 
form.TopMost <- true 
form.Show()
