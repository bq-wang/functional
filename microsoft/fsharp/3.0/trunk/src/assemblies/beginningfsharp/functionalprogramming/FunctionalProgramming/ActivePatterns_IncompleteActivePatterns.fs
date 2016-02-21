module ActivePatterns_IncompleteActivePatterns

// Active Pattern: 
// please check here for details: http://msdn.microsoft.com/en-us/library/dd233248.aspx
//


// Incomplete Active Patterns
// there is a system defined type called "option", and the definition is like below.
// however, do not try to run teh code below. otherwise, you will get an error like this:
// 
//ActivePatterns_IncompleteActivePatterns.fs(30,5): error FS0001: This expression was expected to have type
//    'a option    
//but here has type
//>     option<string>

type option<'a> = 
    | Some of 'a
    | None

open System.Text.RegularExpressions

// the definition of the active pattern
//let (|Regex|_|) regexPattern input = 
//    // create and attemp to match a regular expression 
//    let regex = new Regex(regexPattern)
//    let regexMatch = regex.Match(input)
//    // return either some of None
//    if regexMatch.Success then
//        Some regexMatch.Value
//    else 
//        None

// the definition of the active pattern
let (|Regex|_|) regexPattern input =
    // create and attempt to match a regular expression
    let regex = new Regex(regexPattern)
    let regexMatch = regex.Match(input)
    // return either Some or None
    if regexMatch.Success then
        Some regexMatch.Value
    else
        None

// function to print the results by pattern 
// matching over different instances of the active pattern
let printInputWithType input = 
    match input with 
    | Regex "$true|false^" s -> printfn "Boolean: %s" s
    | Regex @"$$-?\d+^" s -> printfn "Integer: %s" s
    | Regex "$$-?\d+.\d*^" s -> printfn "Floating piont: %s" s
    | _ -> printfn "String: %s" input


// print the results 
printInputWithType "true"
printInputWithType "12"
printInputWithType "12.1"


let (|Integer| _ | ) (str : string) = 
    let mutable intvalue = 0
    if System.Int32.TryParse(str, &intvalue) then Some(intvalue)
    else None

let (|Float| _ |) (str : string) = 
    let mutable floatvalue = 0.0
    if System.Double.TryParse(str, &floatvalue) then Some(floatvalue)
    else None

let parseNumeric str = 
    match str with 
        | Integer i -> printfn "%d : Integer" i
        | Float f -> printfn "%f : floating point" f
        | _ -> printfn "%s : Not Matched" str

parseNumeric "1.1"
parseNumeric "0"
parseNumeric "0.0"
parseNumeric "10"
parseNumeric "Something else"


