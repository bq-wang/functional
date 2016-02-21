module WorkingWithControlsInWinforms_ControlDockingStyle

// what will be learnt from this chapter incldue the following 
//  1. how to control ther docking style 

open System
open System.Windows.Forms

let form = 
    // create a form 
    let temp = new Form()
    // create a text box and set its anchors
    let textBox = new TextBox(Top = 8, Left = 8, Width = temp.Width - 24,
                            Anchor = (AnchorStyles.Left |||
                                AnchorStyles.Right |||
                                AnchorStyles.Top))
    // add the text box to the form and return the form 
    temp.Controls.Add(textBox)
    temp

//[<STAThread>]
//do Application.Run(form)

form.Visible <- true 