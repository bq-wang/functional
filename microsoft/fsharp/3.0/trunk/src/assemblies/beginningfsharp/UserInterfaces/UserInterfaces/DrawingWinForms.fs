module DrawingWinForms

open System.Drawing
open System.Windows.Forms

let form =
    // create a new form settings the minimum size 
    let temp = new Form(MinimumSize = new Size(96, 96))
    // repaint the form when it is resize 
    temp.Resize.Add(fun _ -> temp.Invalidate())

    // a brush to provide the shape color 
    let brush = new SolidBrush(Color.Red)
    temp.Paint.Add(fun e -> 
        // calculate hte width and height of the shape 
        let width, height = temp.Width - 64, temp.Height - 64
        // draw the require shape 
        e.Graphics.FillPie(brush, 32, 32, width, height, 0, 290))
    // return the form to the top level
    temp 



form.Text <- "Drawing Winform"
form.Visible <- true
Application.Run(form) 