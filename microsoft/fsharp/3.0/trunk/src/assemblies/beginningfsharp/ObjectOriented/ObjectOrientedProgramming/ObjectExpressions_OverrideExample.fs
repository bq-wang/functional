module ObjectExpressions_OverrideExample

// show with how to override methods in object expression

open System
open System.Drawing
open System.Windows.Forms

// create a new instance of a number control
let makeNumberControl (n : int) = 
    { new Control(Tag = n, Width = 32, Height = 16) with 
        // override the controls paint methods to draw the number 
        override x.OnPaint(e) = 
            let font = new Font(FontFamily.Families.[2], 12.0F)
            e.Graphics.DrawString(n.ToString(),
                                 font,
                                 Brushes.Black,
                                 new PointF(0.0F, 0.0F))
      // Implement the IComparable interface so the control s
      // can be compared
      interface IComparable with 
          member x.CompareTo(other) = 
              let otherControl = other :?> Control in 
              let n1 = otherControl.Tag :?> int in 
              n.CompareTo(n1) }

// a sorted array of the numbered controls
let numbers = 
    // initialize the collection 
    let temp = new ResizeArray<Control>()
    // initiaze the random number generator
    let rand = new Random()
    // add the controls collection 
    for index = 1 to 10 do 
        temp.Add(makeNumberControl (rand.Next(100)))
    // sort the collection 
    temp.Sort()
    // layout the controls correctly 
    let height = ref 0
    temp |> Seq.iter
        (fun c -> 
            c.Top <- !height
            height := c.Height + !height)
    // return collectoin as an array 
    temp.ToArray()

// create a form to show the number controls
let numbersForm =
    let temp = new Form() in 
    temp.Controls.AddRange(numbers)
    temp

// show the form
//[<STAThread>]
//do Application.Run(numbersForm)