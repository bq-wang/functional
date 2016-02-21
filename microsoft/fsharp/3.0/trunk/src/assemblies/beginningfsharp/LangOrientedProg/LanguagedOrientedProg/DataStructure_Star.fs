module DataStructure_Star

// what will be covered in this chapter incldue the following 
//  1. how to create a advanced example that will draw a star

open System.Drawing
open System.Windows.Forms
open Strangelights.GraphicsDSL

// defien a function that can draw a 6 slides star
let star (x, y) size = 
    let offset = size / 2
    // calculate the first triangle
    let t1 = 
        Combinators.triangle false
            (x, y - size - offset)
            ( x - size, y + size - offset)
            (x + size, y + size - offset)
    // calculate another inverted triangle
    let t2 =
        Combinators.triangle false
            (x, y + size + offset) 
            (x + size, y - size + offset) 
            (x - size, y - size + offset)
    // composet he triangles
    Combinators.compose [t1; t2]
// the points where start should be plotted
let points = [(10, 20); (200, 10);
              (30, 160); (100, 150); (190, 150);
              (20, 300); (200, 300); ]

// compose the stas into a single scene
let scene = 
    Combinators.compose
        (List.map (fun pos -> star pos 5) points)

// show the scene in red on teh EvalForm

let form = new EvalForm([scene, Color.Red],
                        Width = 260, Height = 350)

// show the form
//Application.Run from

form.Show()
form.Visible <- true 
