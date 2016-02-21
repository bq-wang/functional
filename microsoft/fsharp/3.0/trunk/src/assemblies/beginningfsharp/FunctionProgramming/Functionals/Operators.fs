module Operators


// we will discuss the infix and the prefix operator 

let thyme = "Jack" + "and" = "Jill"

open System
let oneYearLater = 
    DateTime.Now + new TimeSpan(365, 0, 0, 0, 0)

// operator are not functions, they cannot be passed to other function as parameter
// however, if you need to use an opertor as a value, you can do this (+)

// as a function
let results = (+) 1 1

// As it is a value, it could be returned as the result of a function, passed to another function, or bound to an identifier 
let add = (+)

// user can even redefine some operator (not encouraged) 
let (+) a b = a - b
printfn "%i" (1 + 1)

//User-defined (custom) operators must be nonalphanumeric and can be a single character or a group
// of characters. You can use the following characters in custom operators:
//    !$%&*+-./<=>?@^|~

// syntax e.g. for defining an operator is like the let keyword to define a function 

let (+*) a b = (a + b) * a * b
printfn "(1 +* 2) = %i" (1 +* 2)

