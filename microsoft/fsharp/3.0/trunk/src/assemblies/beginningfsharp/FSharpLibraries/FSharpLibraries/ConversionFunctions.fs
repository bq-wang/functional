module ConversionFunctions

// what we will cover in this chapter include the following 
//  1. conversion operators by an exaple of enum conversion of enum 


(*

the conversion to and from an enum is that a type annotation is required. 

*)

open System

let dayInt = int DateTime.Now.DayOfWeek
let (dayEnum : DayOfWeek) = enum dayInt

printfn "%i" dayInt
printfn "%A" dayEnum