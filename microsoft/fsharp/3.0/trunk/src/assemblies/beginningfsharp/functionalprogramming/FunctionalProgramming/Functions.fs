module Functions

// function does not necessary need a name..
// to give it a name, with "binding to a identifier"
fun x y -> x + y

let myAdd = fun x y -> x + y

let raisePowerTwo x = x ** 2.0 // the ** operator do the power operation

// function are values, so that 
// value and function are indistinguishable

let n = 10
let add a b = a + b

let result = add n 4

printfn "result = %i" result