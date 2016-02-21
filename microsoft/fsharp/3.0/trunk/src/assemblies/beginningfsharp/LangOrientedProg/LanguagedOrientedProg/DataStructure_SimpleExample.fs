// what will be covered in this chapter include the following
//  1. witha an example to show how you can leverage the combinator libarries that you have just invented 

open System.Drawing
open System.Windows.Forms
open Strangelights.GraphicsDSL

// two test squares

let square1 = Combinators.square true (100, 500) 50
let square2 = Combinators.square false (50, 100) 50 

// a test triangle
let triangle1 = 
//    Combinators.triangle false (150, 200), (150, 150), (250, 200) (*you cannot use the ',' to separate the parameters to triangle because that would otherwise means you are creating a tuple *)
    Combinators.triangle false (150, 200) (150, 150) (250, 200)

// compose the basic elements intoa  picture
let scene = Combinators.compose [square1; square2; triangle1]

// create the display form
let form = new EvalForm([scene, Color.Red]) // this actually means the following ([scene, Color.Red])

form.Show()
form.Visible <- true 
// show the form 
//Application.Run form