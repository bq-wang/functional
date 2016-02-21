module ClassesWithExplicitFieldsAndConstructors

// what we will be convered in this chapter is the following
//    explicit syntax

// background:
// the implicit style is better because 1) it means less typing 2) the compiler can do some optimization
// whiel sometime you need to have the explicit style
// the reason is because:
//   implicit style may indicate fields that might be impacted on reflection, that is because the optimization may remove some fields and explicit control is require in this situation.

// the difference is 
//  1. the field declaration with the "val" keyword
//  2. the explict constructor with the "new" keyword

// field-definition::
//   val [mutable] field-name : field-type

// constructor-definition:
//  new (parameter-list) = 
//     { record-style-initialization }
// where 
// record-style-initialization :: field-name = field-value[; field-name = field-value]
//
// NOTE:
// the constructor can be overrided (by # of parameters and by type of arguments)


open System.Web.Security

// give shorte name to password hashing method
//let hash = FormsAuthentication.HashPasswordForStoringInConfigFile

// a class that represents a user 
// it's a constructor takes two paramers, the user's name anda a hash of their password
// a class that represents a user
// it's constructor takes two parameters, the user's
// name and a hash of their password

type User = class
    val name : string 
    val passwordHash : int
    // hashs the users passwod and checks it against
    // the known hash 
    // the class' constructor
    new (name, passwordHash) =
        { name = name; passwordHash = passwordHash }
    // hashs the users password and checks it against
    // the known hash
    member x.Authenticate(password) =
        let hashResult = hash (password, "sha1")
        x.passwordHash = hashResult
    // gets teh user logon message
    member x.LogonMessage() = 
        Printf.sprintf "Hello, %s" x.name
end
