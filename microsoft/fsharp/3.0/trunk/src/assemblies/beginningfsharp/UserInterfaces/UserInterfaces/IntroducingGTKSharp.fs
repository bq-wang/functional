module IntroducingGTKSharp

// what will be covered in this chapter include the following 
//   1. how to work with the Mono libraies and display GTK#


(*
in order to run this, you will first launch the shell of the Mono console.
*) 

#I "C:\ProgramFiles\Mono-3.2.3\lib\mono\gtk-sharp-2.0"
#r "atk-sharp.dll"
#r "glib-sharp.dll"
#r "gdk-sharp.dll"
#r "gtk-sharp.dll"



open Gtk
let main() = 
    // initialize the GTK environment 
    Application.Init()
    // create the window
    let win = new Window("GTK# and F# application")
    //set the window size
    win.Resize(400, 400)
    
    // create a label
    let label = new Label()
    // create a button and subscribe to 
    // its clicked event
    let button = new Button(Label = "Press Me!")
    button.Clicked.Add(fun _ -> 
                        label.Text <- "Hello world.")
    // create a new vbox and add the sub controls
    let vbox = new VBox()
    vbox.Add(label)
    vbox.Add(button) 

    // add the vbox t the window 
    win.Add(vbox)

    // show the window 
    win.ShowAll()

    // close the event loop and the window closes
    win.Destroyed.Add(fun _ -> Application.Quit())

    // start the event loop 
    Application.Run()

do main()
