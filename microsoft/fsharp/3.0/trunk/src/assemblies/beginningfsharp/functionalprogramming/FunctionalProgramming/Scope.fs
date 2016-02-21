module Scope

// the scope of F# identfiers


// in function, you never have to return a value, the result of the computation is automatically bound to its associated identifier.

// scope: 
// An indentation creates a new scope, and the end of this scope is signaled by the end of the indentation. 
// Indention means that the let binding is an intermediate value in the computation that is not visible outside this scope
//
// When a scope closes (by the indentation ending), and an identifier is no longer available, it is said to drop out of scope or to be out of scope.

// function to calculate a midpoint
let halfway a b = 
    let dif = b - a
    let mid = dif / 2
    mid + a

// A note on the coding style:
//  You cannot use tabs instead of spaces for indenting, because these can look different in different text
//  editors, which causes problems when whitespace is significant.

printf "(halfway 5 11) = %i" (halfway 5 11)
printf "(halfway 11 5) = %i" (halfway 11 5)

let printMessage() =
    let message = "help me"
    printfn "%s" message
// you wlll get into trouble with the below
//   value or constructor 'message' is not defined
//printfn "%s" message

// Identifiers within functions behave a little differently from identifiers at the top level, because they  can be redefined using the let keyword.

// an mathematical puzzle
