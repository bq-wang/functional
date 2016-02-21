module DefiningClasses_ImplicitConstructorWithSideEffect

//objects can have let bindings that are internal to
//the object, but shared between all members of the object. You place the let bindings at the beginning of
//the class definition, after the equals sign, but before the first member definition. These let bindings
//form an implicit construct that execute when the object is constructed; if the let bindings have any side
//effects, then these too will occur when the object is constructed.
// if you need to call some function that has sideeffect, you must prefix the function call with the "do" keyword.

//open Strangelights.Samples.Helpers

// a class that represent a user 
// it is constructor takes three parameters, the user's 
// first name, last name, and a hash of their password

type User(firstName, lastName, passwordHash) = 
    // calculate the user's full name and store of later user 
    let fullName = Printf.sprintf "%s %s" firstName lastName
    // print users fullname as object is being constructed 
    do printfn "User: %s" fullName

    // hashs that users password and checks it against 
    // the known hash
    member x.Authenticate(password) = 
        let hashResult = hash(password, "sha1")
        passwordHash = hashResult

    // gets the user logon message
    member x.GetFullName() = fullName