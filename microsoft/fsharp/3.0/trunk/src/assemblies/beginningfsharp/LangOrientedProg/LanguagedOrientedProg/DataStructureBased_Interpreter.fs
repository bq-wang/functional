//module DataStructureBased_Interpreter

// what will be covered in this chapter incldue the following.
//  1. we already have the code on the DataStructureBasedLangaugeImpl.fs and we need an interpreter to interpret the DSL that we havE 

(*


*)


namespace Strangelights.GraphicsDSL

//#r "System.Windows.Forms.dll"

open System.Drawing
open System.Drawing.Drawing2D
open System.Windows.Forms

// a form that can be used to display the scene
type EvalForm(items: List<Element>) as x =
    inherit Form()
    // handle the paint event to draw the scene
    do x.Paint.Add(fun ea ->
        let rec drawShape (shape, (color: Color)) =
            match shape with 
            | Line ((x1, y1), (x2, y2)) ->
                // draw a line 
                let pen =new Pen(color) 
                ea.Graphics.DrawLine(pen, x1, y1, x2, y2)
            | Polygon points ->
                // draw a polygon
                let points = 
                    points 
                    |> List.map(fun (x, y) -> new Point(x,y))
                    |> Array.ofList
                let brush = new SolidBrush(color)
                ea.Graphics.FillPolygon(brush, points)
            | CompositeShape shapes ->
                // recursively draw the other contained elements
                List.iter (fun shape -> drawShape(shape, color)) shapes 
        // draw all the itemn we have been passed 
        items |> List.iter drawShape)
