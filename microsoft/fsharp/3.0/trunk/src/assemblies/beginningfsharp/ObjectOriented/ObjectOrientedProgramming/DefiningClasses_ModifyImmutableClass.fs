module DefiningClasses_ModifyImmutableClass

// in this post, we will examine how to modify an immutable class, some common technique is to 
// create a new immutable object as a result of the modifying/update methods

type User(name, passwordHash) =
    // hashs that users password and checks it against 
    // the known hash
    member x.Authenticate(password) = 
        let hashResult = hash(password, "sha1")
        passwordHash = hashResult

    // gets the user logon message
    member x.LogonMessage() = 
        Printf.sprintf "Hello, %s" name
    // create a copy of the user with the password changed
    member x.ChangePassword(password) = 
        new User(name, hash password)