module IntroducingWinform

// what will be covered in this chapter 
//  1. introducing the Winforms

open System.Drawing
open System.Windows.Forms

// create a new form 
let form = new Form(BackColor = Color.Purple, Text= "Introducing Winforms")

// show the form 
Application.Run(form) 


// to work with the FSI, you an do the following 
//   1. 
// 


open System.Drawing
open System.Windows.Forms
let form = new Form(BackColor=Color.Purple,
    Text="Introducing WinForms",
    Visible=true);;

form.Text <- "Dynamic !!!"