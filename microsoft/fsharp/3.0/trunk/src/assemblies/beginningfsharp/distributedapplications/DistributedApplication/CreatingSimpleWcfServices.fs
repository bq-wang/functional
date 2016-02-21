//module CreatingSimpleWcfServices

namespace Strangelights.Services

(*


you will need to add the refernced to the System.ServiceModel class 

*)

open System.ServiceModel

// the service contract
[<ServiceContract
    (Namespace = "http://strangelights.com/FSharp/Foundations/WCFServices")>]

// this is like to create the service contract (you create the interface first)
type IGreetingService = 
    [<OperationContract>]
    abstract Greet : name : string -> string 

// the service implementation
type GreetingService () = 
    interface IGreetingService with 
        member x.Greet(name) = "Hello: " + name

