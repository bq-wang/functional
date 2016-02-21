module CustomAttributes

// what will be covered in this chapter include
//   1. what and how to apply attribute 
//     1.1. use parameterless constructor 
//     1.2. use non-void constructor of attributes 
//     1.3. set extra properties with attributes
//     1.4 how to apply more than one attributes to targets 
//     1.5 you can use attributes with type and members. 
//   2. how to use attribute with reflection 

(* example of using the attribute is as follow .


[<Obsolete>]


*)



open System
[<Obsolete>]
let functionOne() = ()

(* the obsolete can have constructor parameters *)

open System 
[<Obsolete("it is a pointless function always!")>]
let functionTwo () = ()


(*
how to set extra properties *)
open System.Drawing.Printing
open System.Security.Permissions

[<PrintingPermission(SecurityAction.Demand, Unrestricted = true)>]
let functionThree () = ()


open System 
open System.Drawing.Printing
open System.Security.Permissions
[<Obsolete; PrintingPermission(SecurityAction.Demand)>]
let functionFive() = ()

(* you can apply attributes to the following *)

[<Obsolete>]
type OOThing = class 
    [<Obsolete>]
    val stringThing : string
    [<Obsolete>]
    new() = { stringThing = "" }
    [<Obsolete>]
    member x.GetTheString() = x.stringThing
end 
(* another example is the use of the STAThread *)

open System
open System.Windows.Forms
let form = new Form() 

[<STAThread>]
Application.Run(form)

(* how to find all the types that has the Obsolete attribute *)
open System 

// create a list of all obsolete types 
let obsolete = AppDomain.CurrentDomain.GetAssemblies()
                |> List.ofArray
                |> List.map (fun assm -> assm.GetTypes())
                |> Array.concat
                |> List.ofArray
                |> List.filter (fun m-> m.IsDefined (typeof<ObsoleteAttribute>, true))


// print the lists 

printfn "%A" obsolete
