module ControlEventModule_CreatingAndHandling

// what will be covered in this chapter
//  1. how the event is creating and handled

(* you can create an Event<TypeArgument> and then you will have a trigger method that will trigger the function *)

let event = new Event<string>()
event.Publish.Add(fun x -> printfn "%s" x)
event.Trigger "Hello"
