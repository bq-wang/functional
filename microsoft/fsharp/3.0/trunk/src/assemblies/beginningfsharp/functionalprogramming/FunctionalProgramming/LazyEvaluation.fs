module LazyEvaluation

// Lazy evaluation goes hand in hand with functional programming
// the principles is that if there is no side effect in the language, the compiler or the runtime is free to choose the evaluation order of expressions.
//
// F# allows functions to have side effects, so it is not possible for the compiler or runtime to have free hand in function evaluation; 
// there , F# is said to have a strict evaluation order, or to be a strict language. 


// due to changes in F# a working version of the code might rather like you will call the Value property of the lazy property 
// please check this page: http://weblogs.asp.net/podwysocki/archive/2008/03/21/adventures-in-f-f-101-part-6-lazy-evaluation.aspx


// lazy is a keyword
let lazyValue = lazy( 2 + 2)

// Lazy.force has been changed. 
//let actualValue = Lazy.force lazyValue
let actualValue =  lazyValue.Value

printfn "%i" actualValue


let lazySideEffect = 
    lazy (let temp = 2 + 2
          printfn "%i" temp
          temp)

printfn "Force value the first time: "
let actualValue1 = lazySideEffect.Value
printfn "Force value the second time: "
//let actualValue2 = Lazy.force lazySideEffect
let actualValue2 = lazySideEffect.Value

// laziness working with Collections. 
// the idea of a lazy collection is that elements in the collection are calculated on demand
// there is no need to recaculate elements, the collection most commonly used for lazy programming in F# in the seq type.



// the lazy list definition
// the Possibly the most important function for creating lazy collections, and probably the most difficult to understand, is unfold,
// the function allow you to create a lazy list. What makes it complicated is that you must provide a function that will be repeatedly evaluated to provide 
// the elemtn of the list.
// 
let lazyList= 
    Seq.unfold ( fun x -> 
        if x < 13 then 
            // if smaller than the limit return 
            // the current and next value 
            Some(x, x + 1)
        else
            // if great than the limit
            // terminate the sequence 
            None) 10
// print the results

printfn "%A" lazyList

// sequences are useful to represent lists that don't terminate, A nonterminating list can't be represented by a classic list.
//
// create an infinite list of Fibonacci numbers
let fibs = 
    Seq.unfold(
        fun (n0, n1) -> 
            Some(n0, (n1, n0 + n1)))
            (1I, 1I)

// take the first twenty items from the list 
let first20 = Seq.take 20 fibs

// print the finite list 
printfn "%A" first20

