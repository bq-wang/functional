module RecordAsObjects

// Records as Objects
// It is possible to use the record types you met in Chapter 3 to simulate object-like behavior.
// This is because records can have fields that are functions, which you can use to simulate an object’s methods.
// does have some limitations compared to using F# classes, it also has some
// advantages. Only the function’s type (or as some prefer, its signature) is given in the record definition, so
// you can easily swap the implementation without having to define a derived class, as you would in objectoriented
// programming. I discuss defining new implementations of objects in greater detail in the
// “Object Expressions” and “Inheritance” section later in this chapter.


open System.Drawing
// a Shape record that will act as our object

type Shape = {
    Reposition : Point -> unit;
    Draw: unit -> unit }


// create a new instance of Shape
let makeShape initPos draw = 
    // currPos is the internal state of the object
    let currPos = ref initPos
    { 
        Reposition = 
            // the Reposition members update the internal state
            (fun newPos -> currPos := newPos);
        Draw = 
            // draw the shaep passing the current position
            // to give draw function
            (fun () -> draw !currPos); }

// "draws" a shape, prints out the shapes anme and position
let draw shape (pos: Point) = 
    printfn "%s, with x = %i and y = %i" 
        shape pos.X pos.Y

// creates a new circle shape
let circle initPos = 
    makeShape initPos (draw "Circle")

// creates a new square shape
let square initPos = 
    makeShape initPos (draw "Square")

// list of shapes in their initial positions
let shapes = 
    [ circle (new Point (10, 10));
      square (new Point (30, 30))]

// draw all the shapes 
let drawShapes() =
    shapes |> List.iter (fun s -> s.Draw())

let main() = 
    drawShapes() // draw the shapes
    // move all the Shapes
    shapes |> List.iter (fun s -> s.Reposition (new Point(40, 40)))
    drawShapes() // draw the shapes

// start the program
// NOTE THE 'do' KEYWORD below.
do main()
