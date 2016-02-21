module ReflectionModule_ReflectionOverTypes

// what we wil cover in this chapter 
//  1. with an exaple to demonstrate the use of reflection over a type 

(*

the functions thaw we covers are as follow

1.      FSharpType.IsTuple
2.      FSharpType.GetTupleElements

*)

open Microsoft.FSharp.Reflection

let printTupleTypes (x : obj) = 
    let t = x.GetType()
    if FSharpType.IsTuple t then
        let types = FSharpType.GetTupleElements t 
        printf "(" 
        types 
        |> Seq.iteri 
            (fun i t ->
                if i <> Seq.length types - 1 then 
                    printf " %s * " t.Name
                else 
                    printf "%s " t.Name)
        printfn " )"
    else
        printfn "Not a tuple"


printTupleTypes("Hello world", 1)


(*

( String * Int32  )



*)