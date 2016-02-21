module TypesAndTypeInference

// we will discuss the Types and Type Inference
// In F#, all values have a type , and this includes value that are functions.

// F# is strongly typed language. 
//    static types, e.g. val div1 : int -> int -> int
//    variable types, e.g. val doNothing : 'a -> 'a
//    type constraint,e .g. let doNothingToAnInt( x : int) = x 
// 


// results is as follow 
//
//val makeMessage : int -> string
//val half : int -> int
//
// to interpret the returned value,
//    int -> string :: takes an int and return a string 



let aString = "Spring time in Paris"
let anInt = 42


let makeMessage x = (Printf.sprintf "%i" x ) + " days to sprint time"
let half x = x / 2

// resuls of the following. 
// 
//val div1 : int -> int -> int
//val div2 : int * int -> int
//val divRemainder : int -> int -> int * int
// 
// int * int :: means a tuple 
let div1 x y = x / y
let div2 (x, y) = x /y 
let divRemainder x y = x / y, x % y


// result types:: val doNothing : 'a -> 'a
// this is so-called variable types, (single question mark (') means a variable type). 
//   F# has a type, obj, that maps to System.Object and represents a value of any type
// back to the type, 'a -> 'a means it accept a type and return the same type 
// variable type (type parameterization), is closely related to concept of "generics" 
let doNothing x = x

// NOTE: type constraint.
// you can constraint aparameter x to a specific type 
// you can constrain
//   type parameters
//   identifier
// syntax
//   (identifer : type)
//

// result type:  val doNothingToAnInt int : int -> int 
let doNothingToAnInt (x : int) = x
// result type:  val doNothingToAnInt _int : int -> int 

// the compiler still reports its type as string list when displaying the type, and they mean exactly the same thing. This syntax is supported to make F# types
// with a type parameter look like generic types from other .NET libraries. let intList = [1; 2; 3]

let (stringLlist: List<string>) = ["one"; "two"; "three"]
// THIS IS NOT YET DONE!