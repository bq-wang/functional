module PartialApplicationOfFunctions

// show how to use the Partially application of functions , which a.k.a the "Curried functions"


// partial or curried functions. 


// NOTE: (,) group parameters into a what is called "tuple"... 
// you get error with the following, as (a, b) is a tuple, and it is a singular.
let sub (a, b) = a - b
let subFour = sub 4

// functions takes more than one arguments, when they applied, and if the arguments are not provided at once 
// it returns a value that is a new function waiting for the rest, this is what we referred to as curried 

