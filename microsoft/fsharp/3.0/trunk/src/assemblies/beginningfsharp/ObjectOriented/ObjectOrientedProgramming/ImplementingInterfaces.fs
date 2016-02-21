module ImplementingInterfaces

//open StrangeLights.Samples.Helpers

// to implement the interface, you might have already seen this in the ObjectExpression section on how to implement an interface.
// you can implement an interface by either a class or by structs (for more details on the struct, please find out more later) 

//type implementing_type_name (contructor_parameters) = 
//    interface interface_to_implement_name with 
//        member self-identifier.member_name (comma-separated-parameter-lists) = 
//            member_definition 
//        other-member-implementation ...
//    interface interface_to_implement_name with 
//        other-member-implementation
//

// special note on the downcast operator.
// :?>
// syntax:
//   instance :?> type_name
// the type_name can be an interface name, a class name or a record name? or struct name?
//
// illustrate by the e.g.
//let user = User("Robert", "AF73C586F66FDC99ABF1EADB2B71C5E46C80C24A")
//// cast to the IUser interface
//let iuser = user :?> IUser

// an Interface "IUser"
type IUser = 
    // hashs the users password and checks it against
    // the known hash
    abstract Authenticate: evidence : string -> bool
    // gets the users logon message
    abstract LogonMessage : unit -> string

// a class that represents a user
// it's constructor takes two parameters, the user's
// name and a hash of their password
type User(name, passwordHash) = 
    interface IUser with 
        // authenticate implementation
        member x.Authenticate(password)  = 
            let hashResult = hash (password, "sha1")
            passwordHash = hashResult
        // logonMessage implementation
        member x.LogonMessage() = 
            Printf.sprintf "Hello, %s" name

// Create a new instance of the user
//let user = User("Robert", "AF73C586F66FDC99ABF1EADB2B71C5E46C80C24A")
let user = User("Robert", 1)
// cast to the IUser interface
let iuser = user :> IUser
// get the logon message
let logonMessage = iuser.LogonMessage()


let logon(isuer : IUser) =
    // authenticate user and print appropriate message
    if iuser.Authenticate("badpass") then
        printfn "%s" logonMessage
    else 
        printfn "Logon failed"

do logon user

// a common tip/technique to avoid is to add the methods to the class as members of the implementing class, to save you from the trouble 
// to cast the instance to the necessary interface
// NOTE:
//   as tested, this does not work .
//

// a class that represents a user
// it's constructor takes two parameters, the user's
// name and a hash of their password
type User2(name, passwordHash) = 
    interface IUser with 
        // authenticate implementation
        member x.Authenticate(password)  = 
            let hashResult = hash (password, "sha1")
            passwordHash = hashResult
        // logonMessage implementation
        member x.LogonMessage() = 
            Printf.sprintf "Hello, %s" name

// NOTE:
// this has been tested not to work !!
    // Expose Authenticate implementation
    member x.Authenticate(password) = x.Authenticate(password)
    // Expose LogonMessage implementation
    member x.LogonMessage() = x.LogonMessage()
// NOTE:
//   this is to show that you can use the F# type TypeA * TypeB rather than the "(TypeA, TypeB)" which is the type type
    member x.Method1 a b  = 
         Printf.printf "a = %s, b = %s" a b// NOTE:
// because you can do this (and it does not compile)
//    member x.Authen(password) = x.Authenticate(password)
//    member x.Logon() = x.LogonMessage()


let user2 = User2("Robert", 1)
user2.Authenticate("badpass")

// get the logon message
let iuser2 = user2 :> IUser
let logonMessage2 = iuser2.LogonMessage()

let logon2(iuser : IUser) =
    // authenticate user and print appropriate message
    if iuser.Authenticate("badpass") then
        printfn "%s" logonMessage2
    else 
        printfn "Logon failed"

do logon2 user2