module FunctionApplication

// here we will show you how to use the function application 
let add x y = x + y 
let result = add 4 5

printfn "(add 4 5) = %i" result


// you don't necessary to use parenthesis when calling functions, but F# programmer often use theem to define which 
// function should be applied to which arguments. 

let add x y = x + y 

let result1 = add 4 5
let result2 = add 6 7 

let finalResult = add result1 result2

// use () to group function and their parameters

let add x y = x + y 
let result = add (add 4 5) (add 6 7)


// we have the pipe forward to make the function application natural
// definition as follow 
let (|>) x f = f x 

// e.g.
let result = 0.5 |> System.Math.Cos

// do it again

let add x y = x + y 
let result = add 6 7 |> add 4 |> add 5





