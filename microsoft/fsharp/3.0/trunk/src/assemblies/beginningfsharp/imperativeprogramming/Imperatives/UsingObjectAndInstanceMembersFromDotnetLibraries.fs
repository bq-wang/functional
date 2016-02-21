module UsingObjectAndInstanceMembersFromDotnetLibraries

// what we willk learn from this chapter include the following
//   1. to instance an object from the non-F# libraries, you use new followed by the class name, followed by the constructor parameter
//   2. non-F# class instance behave most like the record type
//   3. access member with the . operator, and to updtae a member, you use <- 
//   4. methods and function parameter are using parenthesize
//   5. how a fun value converted to delegate (implicitly) with the 'fun' keyword
//   6. how to create object with some kind of "Object initializer" object - set properties at construction time 
//   7. how to instruct the compiler to  infer the type parameter



open System.IO
// crate a fileInfo object

let file = new FileInfo("test.txt")

// test iof thefile exists
// if not create a fiel 
if not file.Exists then 
    use stream = file.CreateText()
    stream.WriteLine("hello world")
    file.Attributes <- FileAttributes.ReadOnly
// print the full file name 
printfn "%s" file.FullName


// to set a property at construction time, you place the property  name inside the constructor, and with a equal sign, assign an initial value to the property 
// this is analogy to the object initialization syntax we found in C#
// -- this is not supported 

open System.IO
// file name to test 
let filename = "test.txt"

// bind file to an option type, depending on whether the4 file exist or not 
let file2 = 
    if File.Exists(filename) then
        Some(new FileInfo(filename, Attributes=FileAttributes.ReadOnly))
    else 
        None

// you can include the <> bracket when you try to construct some type with type parameters, because 
// the compiler cannot always infer the right type parameter

open System

// an integer list 
let intList = 
    let temp = new ResizeArray<int>() in 
        temp.AddRange([|1; 2; 3;|]);
        temp

// print each int using the ForEach member method
intList.ForEach(fun i -> Console.WriteLine(i))


// to infer the type parameter, you can use (_) the wildcard in place of the type parametetr

open System

// how to wrap a method that take a delegate with an F# function 
let findIndex f arr = Array.FindIndex(arr, new Predicate<_>(f))

// define an array literal
let rhyme = [| "The"; "cat"; "sat"; "on"; "the"; "mat"|]

// print index of hte first word ending in 'at'
printfn "First word ending in 'at' in the array : %i" (rhyme |> findIndex (fun w -> w.EndsWith("at")))




//-- REFERENCE

//  Constructors (F#) - http://msdn.microsoft.com/en-us/library/vstudio/dd233192.aspx 