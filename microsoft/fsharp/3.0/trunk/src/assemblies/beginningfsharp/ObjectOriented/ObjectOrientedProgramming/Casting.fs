module Casting

// in this chapter, we will cover the following
//   upcast
//   downcast

//  Casting is a way of explicitly altering the static type of a value by either throwing
//  information away, which is known as upcasting; or rediscovering it, which is known as downcasting

// syntax
//  up-cast
//    :>
//  down-cast
//    :?>


let myObject = ("This is a string" :> obj) 


open System.Windows.Forms
let myControls = 
    [| (new Button() :> Control); 
        (new TextBox() :> Control);
        (new Label() :> Control) |]
 
// an upcast also has the effect of automatically boxing any value type. 
//  value type are held in memory on the program stack, rather than on the managed heap


let boxedInt = (1 :> obj)


// - downcast


open System.Windows.Forms
let moreControls = 
    [| (new Button() :> Control);
        (new TextBox() :> Control) |]

let control =
    let temp = moreControls.[0]
    temp.Text <- "Click me!"
    temp

let button = 
    let temp = (control :?> Button)
    temp.DoubleClick.Add(fun e -> MessageBox.Show("hello") |> ignore)
    temp


let castForm = 
    let form = new Form () in
    form.Controls.Add(button)
    form