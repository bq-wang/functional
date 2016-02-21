module ReflectionModule_ReflectionOverValues

// what we will be covered in this chaper 
//   1. with an exaple to demonstrate the use of reflection over a value  

open Microsoft.FSharp.Reflection
let printTupleValues (x : obj)  = 
    if FSharpType.IsTuple(x.GetType()) then 
        let vals = FSharpValue.GetTupleFields x 
        printf "("
        vals 
        |> Seq.iteri
            (fun i v -> 
                if i <> Seq.length vals - 1 then 
                    printf " %A, " v
                else 
                    printf " %A" v)
        printfn " )"
    else 

        printfn "not a tuple"


printTupleValues("hello world", 1)

(*
the reflection of use example can be found in 
    1). printf function 
    2). fsi interactive command-line 


available in the distribution in the files

\source\fsharp\printf.fs and \source\fsharp\layout.ml.

*)