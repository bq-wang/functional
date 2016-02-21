module WinformsEventAndEventModule

// what will be covered in ths chapter include the following 
//   1. Working with WinForms Events and the Event Module


(*

to get a feel how to work with the FSharp event module, you may do some filtering and which is quite different from the normal CSharp handling of events. 
*)


open System.Windows.Forms


let form =
    // create a new form
    let temp = new Form()
    // subscribe the mouse click event filtering so it only
    // reacts to the left button
    temp.MouseClick 
    |> Event.filter (fun e -> e.Button = MouseButtons.Left)
    |> Event.add (fun _ -> MessageBox.Show("Left button") |> ignore) 
    // return the form
    temp

//Application.Run(form)
form.Visible <- true



open System
open System.Drawing
open System.Windows.Forms


let form2 = 
    // create the form
    let temp = new Form(Text = "Scribble !!")
    // some refrence cells to hold the applications state
    let pointsMasterList = ref []
    let pointsTempList = ref []
    let mouseDown = ref false
    let pen = ref (new Pen(Color.Black))

    // subscribe to the mouse down event
    temp.MouseDown.Add(fun _ -> mouseDown := true)

    // create a left mouse down and right mouse down events
    let leftMouse, rightMouse =
        temp.MouseDown
        |> Event.partition (fun e -> e.Button = MouseButtons.Left)

    // the mouse up event handler
    let mouseUp _ = 
        mouseDown := false
        if List.length !pointsTempList > 1 then 
            let points = List.toArray !pointsTempList
            pointsMasterList :=
                (!pen, points) :: !pointsMasterList
        pointsTempList := []
        temp.Invalidate()

    // the mouse move event handler
    let mouseMove(e: MouseEventArgs) = 
        pointsTempList := e.Location :: !pointsTempList
        temp.Invalidate()

    // the paint event handler
    let paint(e: PaintEventArgs) = 
        if List.length !pointsTempList > 1 then 
            e.Graphics.DrawLines
                (!pen, List.toArray !pointsTempList)
        !pointsMasterList
        |> List.iter
            (fun (pen , points) -> 
                e.Graphics.DrawLines(pen, points))
    // wire up the event handlers
    temp.MouseUp |> Event.add mouseUp

    temp.MouseMove
    |> Event.filter(fun _ -> !mouseDown)
    |> Event.add mouseMove

    temp.Paint |> Event.add paint
    // return the form object
    temp

form2.Visible <- true
//[<STAThread>]
//do Application.Run(form2)

