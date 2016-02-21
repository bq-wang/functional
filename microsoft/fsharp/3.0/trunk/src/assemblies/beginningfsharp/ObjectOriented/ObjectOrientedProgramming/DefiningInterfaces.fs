module DefiningInterfaces

// Interfaces can contain only abstract methods and properties, or members that you declare using the keyword abstract
//

// the syntax is like this: 

//type interface_name =
//    abstract interface_member_name: interface_member_signature
//where the interface_member_signature is defined as 
//  interface_member_signature ::  parameter_type -> result_type
//where parameter_type is defined as 
//  parameter_type:: parameter [* parameter]
//or
//  parameter_type:: (parameter, [parameter])  # this is so-called tuple types.


// an interface "IUser"
type IUser = 
    // hashs the users password and checks it against
    // the known hash
    abstract Authenticate: evidence : string -> bool
    // gets the users logon message
    abstract LogonMessage : unit -> string

let logon(user: IUser) = 
    // authenticate user and print appropriate message
    if user.Authenticate("badpass") then 
        printfn "%s" (user.LogonMessage())
    else 
        printfn "Logon failed"
