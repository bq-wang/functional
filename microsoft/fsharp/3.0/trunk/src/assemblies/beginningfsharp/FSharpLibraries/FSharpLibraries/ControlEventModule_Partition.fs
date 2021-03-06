﻿module ControlEventModule_Partition

// what will be covered in this chapter include the folloiwng 
//  1. the partition function 

let event = new Event<string>()
let hData, nonHData = event.Publish |> Event.partition(fun x -> x.StartsWith("H"))
let x  = Event.partition

hData.Add(fun x -> printfn "H data: %s" x)
nonHData.Add(fun x -> printfn "Non H data: %s" x)

event.Trigger "Harry"
event.Trigger "Jane"
event.Trigger "Hillary"
event.Trigger "John"
event.Trigger "Henry"
