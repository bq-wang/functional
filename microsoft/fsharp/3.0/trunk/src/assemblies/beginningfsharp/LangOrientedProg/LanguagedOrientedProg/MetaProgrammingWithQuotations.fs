module MetaProgrammingWithQuotations

// what will be covered in this chapter include the following.
//  1. in chapter 6, we have seen the use of the Quoatation , so we will first do a review on the quotation
//  2. we then explore the use of the Quotation to do some metaprogramming
//  3. we will then use an example of the stack based arithemetic calculation as the means of conveying our meanings.
(*

First let's examine the quotation code. 

you used quotations; these are quoted sections of F# code where the quote operator
instructs the compiler to generate data structures representing the code, rather than IL representing the
code. This means you have a data structure that represents the code that was coded, rather than code
you can execute, and you’re free to do what you want with it. You can either interpret it, performing the
actions you require as you go along, or you can compile it into another language. Or you can simply
ignore it if you want. You could, for example, take a section of quoted code and compile it for another
runtime, such as the Java virtual machine (JVM). Or, as in the LINQ example in Chapter 9, you could turn
it into SQL and execute it against a database.


*)

(*
syntax wise, you may find the you might need to use F#'s pattern matching and active patterns


| Value (x,ty) when ty = typeof<int> ->
    let i = x :?> int
    printfn "Push %i" i
    operandsStack.Push(x :?> int)

and you may need to deal not only the value type of Active pattern, then you might need to do the following .


| SpecificCall <@ (+) @> (_,_, [l;r]) -> interpretInner l
    interpretInner r
    preformOp (+) "Add"

the SpecificCall can accept some type parameterized active patterns that you might find useful, for example, specificCall accepts a quotations
that is a function expression and allows you to query whether the quotaiton being matched over is a call to that function. You use this to determine whether a call to an operation
is made; for example, this example checks whether a call to the plus operator is made: 

*)

(*
notice below the typeof operator that get the type of the int and you might be tell when it can come useful 

*)

open System.Collections.Generic
open Microsoft.FSharp.Quotations
open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations.DerivedPatterns

let interpret exp = 
    let operandsStack = new Stack<int>()
    let performOp f name = 
        (* the original implementation has flaw, where you should abey the last in, first out structure to do the work   *)
        let y, x = operandsStack.Pop(), operandsStack.Pop()
        printfn "%s %i, %i" name x y 
        let results = f x y 
        operandsStack.Push(results)
    let rec interpretInner exp = 
        match exp with 
            | SpecificCall <@ (*) @> (_, _, [l;r]) -> interpretInner l 
                                                      interpretInner r
                                                      performOp (*) "Mult"
            | SpecificCall <@ (+) @> (_, _, [l;r]) -> interpretInner l 
                                                      interpretInner r
                                                      performOp (+) "Add"
            | SpecificCall <@ (-) @> (_, _, [l;r]) -> interpretInner l
                                                      interpretInner r
                                                      performOp (-) "Sub"
            | SpecificCall <@ (/) @> (_, _, [l;r]) -> interpretInner l
                                                      interpretInner r
                                                      performOp (/) "Div"
            | Value (x, ty) when ty = typeof<int> ->  let i = x :?> int 
                                                      printfn "Push: %i" i
                                                      operandsStack.Push(x :?> int)
            | _ -> failwith "Not a vlaid op"
    interpretInner exp 
    printfn "Result: %i" (operandsStack.Pop())



interpret <@ (2 * (2 - 1)) / 2 @>
