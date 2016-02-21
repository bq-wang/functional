module ControlEventModule_Map

// what will be covered in this chapter include the following 
//   1. the map function 

(*
it is possible to transform the data before it reaches the event handler. you do this using the map function provided in the Event module. The following examples demonstrate the how to use it .
*)

let event = new Event<string>()
let newEvent = event.Publish |> Event.map(fun x -> "Mapped data:" + x)

newEvent.Add(fun x -> printfn "%s" x)

event.Trigger "Harry"
event.Trigger "Sally"

