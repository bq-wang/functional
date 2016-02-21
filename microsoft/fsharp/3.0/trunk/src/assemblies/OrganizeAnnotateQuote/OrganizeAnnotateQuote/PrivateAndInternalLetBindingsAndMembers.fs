module PrivateAndInternalLetBindingsAndMembers

// in this chapter, we will examine the following 
// 1. private and internal let bindings and members 
// 2. you can also apply the internal binding to other like union or record 
// 3. you can make members private/internal/public 

let private aPrivateBinding = "Keep this private"
let internal aInternalBinding = "Keep this internal"

// private : current module
// internal: current assembly


// This type will not visible out the current assembly
type internal MyUnion = 
    |String of string 
    | TwoStrings of string * string

// namespace Strangelight.Beginning 
type Thing() = 
    member private x.PrivateThing() =
        ()
    member x.ExternalThing() =
        () 