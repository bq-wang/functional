module AbstractClasses

// AbstractClasses.fs

// in this post, we will cover the following topic
//   abstract class is the class that has abstract members

// [<AbstractClass>]
// abstract-class-with-abstract-member

// an abstract class that represetnt a user
// it's a constructor takes one parameters.
// the user's name
[<AbstractClass>]
type User(name) = 
    // the implementation of this mehtod should hashs the 
    // users password and checks it against the known hash
    abstract Authenticate: evidence : string -> bool
    // gets the user logon message
    member x.LogonMessage() = 
        Printf.sprintf "Hello, %s" name