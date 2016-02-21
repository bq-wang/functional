module Scope_CapturingIdentifiers

// Scope_CapturingIdentifiers.fs
//   this is more like the closure parts in other language.

// function that returns a function to
let calculatePrefixFunction prefix =
    // calculate prefix
    let prefix' = Printf.sprintf "[%s]: " prefix
    // define function to perform prefixing
    let prefixFunction appendee = 
        Printf.sprintf "%s%s" prefix' appendee
    // return function
    prefixFunction

// create the prefix function 
let prefixer = calculatePrefixFunction "DEBUG"

// use the prefix function 
printfn "%s" (prefixer "My Message")