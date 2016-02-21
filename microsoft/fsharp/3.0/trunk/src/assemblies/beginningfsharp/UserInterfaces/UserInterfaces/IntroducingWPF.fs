module IntroducingWPF

// what will be covered in this chapter 
//  1. intoducing the Windows presentation foundation

(*

you will need the following reference in order to work the code

*)


#r "System.Xaml.dll"
#r "PresentationFramework.dll"
#r "PresentationCore.dll"
#r "WindowsBase.dll"
#r "System.Xml.dll"

open System
open System.Collections.Generic
open System.Windows
open System.Windows.Controls
open System.Windows.Markup
open System.Xml


//#r "System.Xaml.dll"

// creates the window and loads the given XAML file into it
let createWindow(file : string) = 
    using (XmlReader.Create(file)) 
        (fun stream ->
        (XamlReader.Load(stream) :?> Window))

// create the window object and add event handler
// to the button control
let window = 
    let temp = createWindow "Window1.xaml"
    let press = temp.FindName("press") :?> Button
    let textbox = temp.FindName("input") :?> TextBox
    let label = temp.FindName("output") :?> Label
    press.Click.Add(fun _ -> label.Content <- textbox.Text)
    temp

// run the application 
let main() = 
    let app = new Application()
    app.Run(window) |> ignore 

[<STAThread>]
do main()

window.Visibility <- Visibility.Visible

//[<STAThread>]
//do main()