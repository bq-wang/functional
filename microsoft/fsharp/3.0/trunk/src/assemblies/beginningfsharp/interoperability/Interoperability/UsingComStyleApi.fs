module UsingComStyleApi

// what will be covered in this chapter include the following 
//  1. how to use "Primary Interop Assemblies" 
(*

More information about Primary Interop Assemblies can be found on MSDN: http://msdn.microsoft.com/en-us/library/aax7sdch.aspx

*)

(*

This is because many vendors now distribute their applications with Primary Interop
Assemblies. These are pre-created COM wrappers, so generally you won’t need to bother creating
wrappers with TlbImp.exe yourself

*)

(*

Although Primary Interop Assemblies are just ordinary .NET assemblies, there are typically a few quirks you have to watch out for, which the following outlines:
• Some arrays and collections often start at one rather than zero.
• There are often methods that are composed of large numbers of optional arguments. Fortunately, F# supports optional and named arguments to make interacting with these more natural and easier to understand.
• Many properties and methods have a return type of object. The resulting object needs to be cast to its true type.
• COM classes contain unmanaged resources that need to be disposed of. However, these classes do not implement the standard .NET IDisposable interface, meaning they cannot be used in an F# use binding. Fortunately, you can use F# object expressions to easily implement IDisposable.

*)

(*

A key difference from C# when interacting with COM in F# is you must always create instances of
objects not interfaces. This may sound strange, but in COM libraries each object typically has an
interface and a class that implements it. In C# if you try and create an instance of a COM interface using
the new keyword in C#, the compiler will automatically redirect the call to appropriate class, but this is
not the case in F#.
*)
(*

Office Primary Interop Assemblies http://msdn.microsoft.com/en-us/library/15s06t57.aspx

Office application or component                  Primary interop assembly name

Microsoft Excel 14.0 Object Library         Microsoft.Office.Interop.Excel.dll
Microsoft Excel 15.0 Object Library
*)
// you will need to add a reference to the COM object "Microsoft.Office.Interop.Excel.dll" , 
open System
open Microsoft.Office.Interop.Excel

let main() = 
    // initialize an excel application 
    let app = new ApplicationClass()

    // load a excel work book 
//    let workBook = app.WorkBooks.Open(@"Book1.xls", ReadOnly = true)
    let workBook = app.Workbooks.Open(@"C:\\Users\\Administrator\\AppData\\Local\\Temp\\Book1.xls", ReadOnly = true)

    (*
     this is is so called anonymous implementation of a interface, you may check back the use of this anonymous implementor
     

     author's notes:
       You implement IDisposable and bind it to bookCloser to ensure the work book is closed, even in the case of an error.
    *)

    // ensure work bok is closed correctly 
    use bookCloser = { new IDisposable with 
                        member x.Dispose() = workBook.Close() }
    
    // open the first worksheet
    let worksheet = workBook.Worksheets.[1] :?> _Worksheet

    // get the A1 ceel and all surround cells
    let a1Cell = worksheet.Range("A1")

    let allCells = a1Cell.CurrentRegion
    // load all cells into a list of lists 
    let matrix = 
        [for row in allCells.Rows ->
            let  row = row :?> Range
            [ for cell in row.Columns -> 
                let cell = cell :?> Range
                cell.Value2 ] ]
    // close the workbook
    workBook.Close()

    // print the matrix 
    printfn "%A" matrix

do main()



