// Learn more about F# at http://fsharp.net
module Program
open System
open System.Windows
open System.Windows.Forms

// F# defining/using a type/module in another file inthe same project
//    http://stackoverflow.com/questions/172888/f-defining-using-a-type-module-in-another-file-in-the-same-project
// How to use one module from another 
//    http://stackoverflow.com/questions/4270206/how-to-use-one-module-from-another
//
// so the key here is that you should place the referenced module before the one that referenced it, it sound odd at the fist sight, but after some thoughts, 
// it does make sense.
//
//[<STAThread>]
//do Application.Run(RecordAsObject_Drawing.mainForm)

//[<STAThread>]
//do TypesWithMembers.main()


//[<STAThread>]
//do Application.Run(ObjectExpressions.numbersForm)



//[<STAThread>]
//do Application.Run(ObjectExpressions_OverrideExample.numbersForm)


//[<STAThread>]
//do MethodsAndInheritance.main()

//[<STAThread>]
//do Application.Run(AccessingBaseClass.form)


[<STAThread>]
do Application.Run(Casting.castForm)