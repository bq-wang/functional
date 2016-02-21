//module WorkingWithASPNetWebForms

// what will be covered in this chapter include the following. 
//  1.  introduce you how to program with the ASP.NET Web forms with F#


namespace Strangelights.HttpHandlers

open System
open System.Web.UI
open System.Web.UI.WebControls
// class to handle to provide the code behind for the .aspx page
type HelloUser =
    inherit Page 
    // fields that will hold the controls references
    val mutable OutputControl : Label
    val mutable InputControl : TextBox

    // the class must have a parameterless constructor 
    new() = 
        { OutputControl =null 
          InputControl = null } 

    // method to handle the on click event 
    member x.SayHelloButton_Click((sender :obj), (e: EventArgs)) = 
        x.OutputControl.Text <- ("Hello ...." + x.InputControl.Text) 