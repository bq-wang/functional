module QuotedCode



// quotation give you a way to tell the compiler , "Don't generate code 
// for this section of the source file;
// turn it into a data structure, or an expression tree, instead.” You can then interpret this expression tree in
// a number of ways, transform or optimize it, compile it into another language, or even ignore it.

// quote the integer one 
let quotedInt = <@ 1 @>

// print the quoted integer

printfn "%A" quotedInt

(* 

Value (1)

*) 


// define an identifider n 
let n = 1
// quote the identifier

let quotedId = <@ n @>

// print the quoted identifier

(* 

PropGet (None, Int32 n, [])

*)


// define a function 
let inc x = x + 1

// quote the function applied to a value  
let quotedFun = <@ inc 1 @>

// print the quotation 
printfn "%A" quotedFun 

(*

the function has two parts, one is the function itself, and the second represents the value to which it is applied. 


Call (None, Int32 inc(Int32), [Value (1)])

*)




open Microsoft.FSharp.Quotations

// quote an operator applied to two operands 
let quotedOp = <@ 1 + 1 @>
// print the quotation 
printfn "%A" quotedOp


(*

the operator has two parts, one is function that represent the function call.  and the second parts is the function arguments

Call (None, Int32 op_Addition[Int32,Int32,Int32](Int32, Int32),
[Value (1), Value (1)])
*)

open Microsoft.FSharp.Quotations

// quote an operator applied to two operands 
let quotedAnonFun = <@ fun x -> x + 1 @>
// print the quotation 
printfn "%A" quotedAnonFun


(* 

this is how the lambda experssion is translated 

Lambda (x,
        Call (None, Int32 op_Addition[Int32,Int32,Int32](Int32, Int32),
              [x, Value (1)]))

val quotedAnonFun : Expr<(int -> int)> =
  Lambda (x,
        Call (None, Int32 op_Addition[Int32,Int32,Int32](Int32, Int32),
              [x, Value (1)]))
*)



(*
Quotations are simply a discrimination union of Microsoft.FSharp.Quotations.Expr , working with them can do with the 
pattern matching. 

the e.g. we will show below is to test if a quoted expression is a int value. 

*)

open Microsoft.FSharp.Quotations.Patterns

// a function to interpret very simple quotations 
let interpretInt exp = 
    match exp with 
    | Value(x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int) 
    | _ -> printfn "not an int"


// test the function 
interpretInt<@ 1 @>
interpretInt<@ 1 + 1 @>


(*  

Pattern matching
over quotations like this can be a bit tedious, so the F# libraries define a number of active patterns to
help you do this. You can find these active patterns defined in the Microsoft.FSharp.Quotations.
DerivedPatterns namespace


*)

open Microsoft.FSharp.Quotations.Patterns
open Microsoft.FSharp.Quotations.DerivedPatterns

// a function to interpret very simple quotations 
let rec interpret exp = 
    match exp with 
    | Value (x, typ) when typ = typeof<int> -> printfn "%d" (x :?> int) 
    | SpecificCall <@ (+) @> (_, _, [l;r]) -> interpret l
                                              printfn "+"
                                              interpret r
    | _ -> printfn "Not supported"

// test the function 
interpret <@ 1 @>
interpret <@ 1 + 1 @>


(*

1
1
+
1

*)




// this defines a function and quotes it 

[<ReflectedDefinition>]
let inc1 n = n + 1

// fetch the quoted definition 
let incQuote = <@@ inc1 @@>


let incQuote2 = <@ inc1 @>
// print the quotation 
printfn  "%A" incQuote 
printfn  "%A" incQuote2

// use the function 
printfn "inc 1: %i" (inc1 1)

(*

Lambda (n@5, Call (None, Int32 inc(Int32), [n@5]))
inc 1: 2


Lambda (n, Call (None, Int32 inc1(Int32), [n]))
Lambda (n, Call (None, Int32 inc1(Int32), [n]))
inc 1: 2

val inc1 : int -> int
val incQuote : Expr = Lambda (n, Call (None, Int32 inc1(Int32), [n]))
val incQuote2 : Expr<(int -> int)> =
  Lambda (n, Call (None, Int32 inc1(Int32), [n]))

*)