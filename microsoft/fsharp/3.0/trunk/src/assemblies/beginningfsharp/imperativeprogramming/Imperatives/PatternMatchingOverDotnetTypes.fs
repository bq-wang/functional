module PatternMatchingOverDotnetTypes

// what will be covered in this chapter includes the following 
//  1. how to pattern matching on the .NET libraries 
//  2. how to use the pattern matching to handle exceptions 

// the syntax of the pattern matching on the .NET libraries 
//     match variable_name with 
//     | :? type_name [as identifier-name] -> action-body
//     | :? type_name [as identifier-name]  -> action-body
//     | ...

// a list of objects 

// NOTE:
//    the box is a F# function that takes a .NET object and return a boxed object out of it 
let simpleList = [ box 1; box 2.0; box "three"]
// a function that pattern matches over 
// the type oft he object it is passed


let recognizeType (item : obj) = 
    match item with 
    | :? System.Int32 -> printfn "An integer"
    | :? System.Double -> printfn "An double"
    | :? System.String -> printfn "A string "
    | _ -> printfn "unknown type"

// iterate over the list of object 
List.iter recognizeType simpleList

// NOTE: 1. this has explicit type annotation of obj, 
//       2. it has a wild-card catch all to ignore default values
//
// the reason is that without obj annotation, the F# compiler will make assumption that the type is 'a
// but you cannot use pattern matching of this kind over F#'s type. , but only ovre .NET types.


let anotherList = [ box "one"; box 2; box 3.0 ] 

// pattern match and print value 
let recognizeAndPrintType( item : obj) = 
    match item with 
    | :? System.Int32 as x -> printfn "An integer: %i" x 
    | :? System.Double as x -> printfn "An duoble: %f" x 
    | :? System.String as x -> printfn "An string: %s" x 
    | x -> printfn "An object : %A" x 
// iterate over the list pattern matching each item 
List.iter recognizeAndPrintType anotherList 

try
    // look at the current time and raise an exception 
    // based on whether the second is a multiple of 3
    if System.DateTime.Now.Second % 3 = 0 then 
        raise (new System.Exception())
    else 
        raise (new System.ApplicationException())
with 
    | :? System.ApplicationException ->
        // this will handle "ApplicationException" case 
        printfn "A second that was not a multiple of 3"
    | _ -> // this will handle all other exception 
        printfn "A second that was a multiple of 3"
