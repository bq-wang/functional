module PipeForwardOperator

// in this chapter, we will cover the following 
//  1. the pipe-forward operator 
//  2. the definition of the pipe-forward operator 
//  3. why this function is useful, it is useful because this type can help the compiler to infer types of the operator
//     parameters, without explicit type annotations .

// the definition of the pipe-forward operator
// let (|>) x f = f x 


// pipe the parameter 0.5 to the sin function 
let result = 0.5 |> System.Math.Sin

let intList = [ 1; 2; 3 ] 
// val printInt : int list 

let printInt = printf "%i"
// val printInt : int -> unit 

List.iter printInt intList



// NOTE above, it is the type of the function that helps to determine the type of list that it operates on 
// or we can do the opposite, by using the pipe-forward operator, we can make the type of the list to determine the type of the function 


open System
// a  date list 
let importantDates = [ new DateTime(1066, 10, 14);
                        new DateTime(1999, 01, 01);
                        new DateTime(2999, 12, 31) ] 

// printing function 
let printInt2 = printf "%i"

// case 1: type annotation required 
List.iter (fun (d : DateTime) -> printInt2 d.Year) importantDates

// case 2, no type annotation required 
importantDates |> List.iter (fun d -> printInt2 d.Year)

// another use of this example is that you can use the pipe-forward to chain together the result to the next input, 
// as in the following .

// grab a list of all methods in memory 
let methods  = System.AppDomain.CurrentDomain.GetAssemblies()
                |> List.ofArray
                |> List.map (fun assm -> assm.GetTypes())
                |> Array.concat
                |> List.ofArray
                |> List.map (fun t -> t.GetMethods()) 
                |> Array.concat

// print the list 
printfn "%A" methods 