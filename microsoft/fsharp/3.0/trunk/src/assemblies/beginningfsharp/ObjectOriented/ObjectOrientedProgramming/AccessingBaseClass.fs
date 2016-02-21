module AccessingBaseClass

// what shall be covered in this post include the following.
//  will show you how to access the base class method (overriden) method from the derived class

// syntax of the call is as follow. 
//   override instance_identifier.overriden_method (comma-separated-parameter-list) = 
//       base.overriden_method(comma-separated-parameter-list)
//

open System.Drawing
open System.Windows.Forms

// define a class that inherits from 'Form'
type MySquareForm(color) = 
    inherit Form()
    // override the OnPain method to draw on the form
    override x.OnPaint(e) = 
        e.Graphics.DrawRectangle(color,
            10, 10,
            x.Width - 30,
            x.Height - 50)
        base.OnPaint(e)
    // override the OnResize method to respond to resizing
    override x.OnResize(e) = 
        x.Invalidate()
        base.OnResize(e)

// create a new instance of the form
let form = new MySquareForm(Pens.Blue)
/// show the form
do Application.Run(form)
