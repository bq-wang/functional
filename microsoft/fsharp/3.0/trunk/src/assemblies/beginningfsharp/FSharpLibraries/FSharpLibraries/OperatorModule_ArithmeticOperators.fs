module OperatorModule_ArithmeticOperators

// what will be covered in this chapter 
//  1.the arithmetic operations that are supported in F#


(*

the operators in FSharp is not built-in in the language, but rather it is built-in inside a libraries

*)

let x1 = 1 + 1

let x2 = 1 - 1


(*
by default, the arithemtic operator do not have checked exception, but you can enable the 
checked operation;

to enable checked operation, you can use open the Microsoft.FSharp.Core.Operators.Checked.


*)
open Microsoft.FSharp.Core.Operators.Checked
let x = System.Int32.MaxValue + 1

(*

> 
System.OverflowException: 算术运算导致溢出。
   在 <StartupCode$FSI_0010>.$FSI_0010.main@() 位置 C:\dev\functional\microsoft\fsharp\3.0\trunk\src\assemblies\BeginningFSharp\FSharpLibraries\FSharpLibraries\OperatorModule_ArithmeticOperators.fs:行号 27
已因出错而停止

*)



(*

=: structural equal (content equal) 
obj.ReferenceEquals: referential equality - PhysicalEqual comparison
<>: structrual unequal

*)

type person = { name : string; favoriteColor : string } 

let robert1 = { name = "Robert"; favoriteColor = "Red" }
let robert2 = { name = "Robert"; favoriteColor = "Red" }
let robert3 = { name = "Robert"; favoriteColor = "Green" }

printfn "(robert1 = robert2): %b" (robert1 = robert2)
printfn "(robert1 <> robert3): %b" (robert1 <> robert3)


(*

(robert1 = robert2): true
(robert1 <> robert3): true

*)




(*
structural comparison is also used to implement the > and < operators, which means they too can be used to compare F# record types, this is demonstrated here: 

*)

//type person = {name : string; favoriteColor : string } 
let robert4 = { name = "Robert"; favoriteColor = "Red" }
let robert5 = { name = "Robert"; favoriteColor = "Red" }

printfn  "(robert2 > robert3): %b" (robert2 > robert3)


(* 

if you need to determine whether two objects physically equal, then you can use the PhysicalEquality function avaiable available in the 
LanguagePrimitives moduole, as in the following examples.
*) 

//type person = {name : string; favoriteColor : string } 
let robert6 = { name = "Robert"; favoriteColor = "Red" }
let robert7 = { name = "Robert"; favoriteColor = "Red" }

printfn "(LanguagePrimitives.PhysicalEquality robert1 robert2): %b" (LanguagePrimitives.PhysicalEquality robert1 robert2)

(*

(LanguagePrimitives.PhysicalEquality robert1 robert2): false

*)

