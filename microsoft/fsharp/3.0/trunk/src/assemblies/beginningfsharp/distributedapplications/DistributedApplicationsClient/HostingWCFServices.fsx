
// what will be covered in this chapter include the following 
//  1. host WCF Services 

(* 

the matter of fact is that 

the most exciting aspect of WCF is the ability to host a service in any program without the need for a web server. 

one possibility this open up,  you can create services where the implementation can be changed dynamically because y ouhost the services  in fsi.exe

*)

#I @"c:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0"
#r "System.ServiceModel.dll"

open System
open System.ServiceModel
open System.Runtime.Serialization

// a range of greeting that could be used
let mutable f = (fun x -> "Hello: " + x) 
f <- (fun x -> "Bonjour: " + x) 
f <- (fun x -> "Goedendag: " + x) 

// the service contract
[<ServiceContract
    (Namespace = "http://strangelights.com/FSharp/Foundations/WCFServices")>]
type IGreetingService =
    [<OperationContract>]
    abstract Greet : name:string -> string 

// the service implementation 
type GreetingService() = 
    interface IGreetingService with 
        member x.Greet(name) = f name

// creating a service host 
let myServiceHost = 
    let baseAddress = new Uri("http://localhost:8080/service")
    let temp  = new ServiceHost(typeof<GreetingService>, [|baseAddress|])

    let binding = 
        let temp = 
            new WSHttpBinding(Name = "binding1",
                              HostNameComparisonMode = HostNameComparisonMode.StrongWildcard,
                              TransactionFlow = false )
        temp.Security.Mode <- SecurityMode.Message
        temp.ReliableSession.Enabled <- false
        temp
    temp.AddServiceEndpoint(typeof<IGreetingService>, binding, baseAddress)
    |> ignore 
    temp


// open the service host 
myServiceHost.Open()