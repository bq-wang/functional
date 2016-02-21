module ControlEventModule_Filter

// what will be covered in this chapter will incldue the following . 
//  1. the filter function 

(*

you can us the filter function to create new eventy which can filter data before firingf to teh client.

*)

let event = new Event<string>()

let newEvent = event.Publish |> Event.filter (fun x -> x.StartsWith("H")) 


newEvent.Add(fun x -> printfn "new event: %s" x) 
event.Trigger "Harry"
event.Trigger "Jane"
event.Trigger "Hillary"
event.Trigger "John"
event.Trigger "Henry"
