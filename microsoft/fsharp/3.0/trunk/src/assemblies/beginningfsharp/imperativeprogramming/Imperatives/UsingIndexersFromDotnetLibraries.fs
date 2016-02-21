module UsingIndexersFromDotnetLibraries

// in this chapter, we will cover the following topic 
//  1. explicitly use the Item property
//  2. use an array-like syntax, with brackets instead


open System.Collections.Generic

// create a ResizeArray 

let stringList = 
    let temp =  new ResizeArray<string>() in 
    temp.AddRange([| "one"; "two"; "three" |]);
    temp 

// unpack items from the resize array
let itemOne = stringList.Item(0)
let itemTwo = stringList.[1]


// print the unpacked items 
printfn "%s %s" itemOne itemTwo

