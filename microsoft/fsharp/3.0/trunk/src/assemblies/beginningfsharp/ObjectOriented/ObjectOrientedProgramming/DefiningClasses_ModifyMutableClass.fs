module DefiningClasses_ModifyMutableClass

// in this post, we will examine how to modify an mutable class, some common technique is to 
// this is common in non-functional programming language, while it is not considered not safe with 
// functional programming, however, the gain is that sometimes this is considere more effecient.

type User(name, passwordHash) =
    // store the password hash in a mutalbe let
    // binding , so it can be changed later
    let mutable passwordHash = passwordHash

    // hashs that users password and checks it against 
    // the known hash
    member x.Authenticate(password) = 
        let hashResult = hash(password, "sha1")
        passwordHash = hashResult

    // gets the user logon message
    member x.LogonMessage() = 
        Printf.sprintf "Hello, %s" name
    // change the users password
    member x.ChangePassword(password) = 
        passwordHash <- hash password