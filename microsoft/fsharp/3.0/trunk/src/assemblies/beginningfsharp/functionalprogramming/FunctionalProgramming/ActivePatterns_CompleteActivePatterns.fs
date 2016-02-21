module ActivePatterns_CompleteActivePatterns

// Active patterns provide a flexible new way to use F#’s pattern-matching constructs
// 

//All active patterns take an input and then perform some computation with that input to determine
//whether a match has occurred. There are two sorts of active patterns:
//  • Complete active patterns allow you to break a match down into a finite number of cases.
//  • Partial active patterns can either match or fail.


// "banana brackets", 
// let (| binana_bracket | ) parameters = { active_pattern_definition }
// binana_bracket::= | case_name | case_name | ... |


open System
// definition of the active pattern
let (|Bool|Int|Float|String|) input = 
    // attempt to parse a tool
    let success, res = Boolean.TryParse input
    if success then Bool(res)
    else
        // attempt to parse an int
        let success, res = Int32.TryParse input
        if success then Int(res)
        else
            // attempt to parse a float (Double)
            let success, res = Double.TryParse input
            if success then Float(res)
            else String (input)


// How to use the Active pattern
// it is just like as if it is were a union type.
//
// function to print the results by pattern
// matching over the active pattern
let printInputWithType input = 
    match input with 
    | Bool b -> printfn "Boolean: %b" b
    | Int i -> printfn "Integer: %i" i
    | Float f -> printfn "Floating piont: %f" f
    | String s -> printfn "String: %s" s

// print the results
printInputWithType "true"
printInputWithType "12"
printInputWithType "-12.1"

