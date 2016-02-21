module WindowsFormsWithServiceBuiltin


#I @"c:\Program Files\Reference Assemblies\Microsoft\Framework\v3.0"
#r "System.ServiceModel.dll"
#r "System.Windows.Forms.dll"
#r "System.Drawing.dll"

open System
open System.IO
open System.Drawing
open System.ServiceModel
open System.Windows.Forms

(*
NOTE :
1. you can use the typeof<Service.ImageService>
2. you can do the following : type Service.ImageService

*)

[<ServiceContract
    (Namespace = "http://strangelights.com/FSharp/Foundations/WCFServices")>]
type IImageService =
    [<OperationContract>]
    abstract Greet : name:string -> string 

let myServiceHost = 
    let baseAddress = new Uri("http://localhost:8080/service")
//    let temp = new ServiceHost((type Service.ImageService), [|baseAddress|])
    let temp = new ServiceHost((type IImageService), [|baseAddress|])

    let binding = 
        let temp = new WSHttpBinding() 
        temp.Name <- "binding1"
        temp.HostNameComparisonMode <- HostNameComparisonMode.StrongWildcard
        temp.Security.Mode <- SecurityMode.Message
        temp.ReliableSession.Enabled <- false
        temp.TransactionFlow <- false
        temp 
    temp.AddServiceEndpoint((type Service.IImageService), binding, baseAddress)
    |> ignore
    temp

myServiceHost.Open()

let form =new Form()
Service.newImgEvent.Add(fun img -> form.BackgroundImage <- img)

[<STAThread>]
do Application.Run(form)
