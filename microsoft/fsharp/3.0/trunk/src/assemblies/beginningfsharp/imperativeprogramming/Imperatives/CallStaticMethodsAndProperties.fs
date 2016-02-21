module CallStaticMethodsAndProperties

// Call Static Methods And Properties from 

open System.IO


//A distinction should be made between calling libraries written in F# and libraries written in any
//other language. This is because libraries written in F# have metadata that describes extra details about
//the library, such as whether a method takes a tuple or whether its parameters can be curried. This
//metadata is specific to F#, and it is stored in a binary format as a resource to the generated assembly.
//This is largely why the Microsoft.FSharp.Reflection API is provided: to bridge the gap between F# and
//.NET metadata.


// Method calls to a non-F# library must have their arguments ** separated by commas and surrounded by parentheses. **

// test wehther a file "test.txt" exist
if File.Exists("test.txt") then 
    printfn "Text file \"test.txt\" is present "
else 
    printfn "Text file \"test.txt\" does not exist"

// You can treat static methods from other .NET libraries as values in the same way that you can treat
// F# functions as values and pass them to other function as parameters.

// list of files to test
let files1 = [ "test1.txt"; "test2.txt"; "test3.txt"]

// test if each file exists
let results1 = List.map File.Exists files1

// print the results
printfn "%A" results1

// Because .NET methods behave as if they take tuples as arguments, you can also treat a method that
// has more than one argument as a value.

open System.IO
// list of files names and desired conents 

// that menas the [] creates the tuples, and the [| creates the array 
// 
let file2 = ["test1.bin", [| 0uy|]; 
             "test2.bin", [| 1uy|]; 
             "test2.bin", [| 1uy; 2uy|] ]

// it is like you were calling 
//   File.WriteAllBytes ( "test1.bin", [| 0uy |]));

// Iterator over the list of files creating each one 
List.iter File.WriteAllBytes file2

// to use the functionality from teh exisitng .NET methods, but you also want the ability to 
// curry it, A common pattern in F# to achieve this is to import the .NET method function by writing a thin
// F# wrapper

open System.IO

// Import the File.Create function 
let create size name = File.Create(name, size, FileOptions.Encrypted)

// list of files to be created
let names = ["test1.bin"; "test2.bin"; "test3.bin"]

// you will find that the List.map has been curried to carry the value of 1024 as the default argument for size argument , and that create a new function 
//
// open the files create a list of stream 
let streams = List.map (create 1024) names

// F# let you use the named function, as such 
open System.IO
// open afile using named arguments 

let file = File.Open(path = "test.txt",
                     mode = FileMode.Append,
                     access = FileAccess.Write,
                     share = FileShare.None)
// close it 
file.Close()
