module HostingWcfServicesProxy

open System

let client = new GreetingServiceClient()
while true do 
    printfn "%s" (client.Greet("Rob"))
    Console.ReadLine() |> ignore 
done (* you can do with "while" -> "done" *)