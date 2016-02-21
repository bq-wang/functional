module TypeAnnotationsForSubtyping

// in this chapter, the following will be covered. 
//   rigid type (static typing on the type annotation)
//   derived type annotation, in whichthe type name is prefixed with a hash sign.  (#)
//   a tip which is called "repeated casting"

// NOTE:
//  actually as it turns out that the rigid typing is not an issue in the FSharp 3.0

open System.Windows.Forms

let showForm (form: Form) = 
    form.Show()

// printPreviewDialog is defined in a BCL and is 
// derived directly the Form class
let myForm = new PrintPreviewDialog()

showForm myForm 




open System
open System.Windows.Forms

let showFormRevised(form: #Form) = 
    form.Show()


// ThreadException dialog is defined in the BCL and is 
// directly dervied type of the Form class
let anotherForm = new ThreadExceptionDialog(new Exception())
showFormRevised anotherForm


// the casting which is required in many a place cause bulkier code, 
// the "repeated casting" is a technique that create a function that does the casting 
// as with any commonly repeated section of code

let myControls = 
    [| (new Button() :> Control); 
        (new TextBox() :> Control);
        (new Label() :> Control) |]

let uc (c : #Control) = c :> Control
let myConciseControls = 
    [| uc (new Button()); uc(new TextBox()); uc (new Label()) |]


// the following is not acceptable.
//let myControls2 = 
//    [| new Button(); new TextBox(); new Label() |]
