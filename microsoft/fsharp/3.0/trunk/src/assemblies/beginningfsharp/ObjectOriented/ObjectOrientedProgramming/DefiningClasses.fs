module DefiningClasses

// demonstrate how to define classes

// syntax of defining classes

// a Class that represents a user
// it's constructor takes two parameters, the user's 
// name and hash of their password

// the syntax to define a class is as folow 
// type class_name (comma-separated

//open StrangeLights.Samples.helpers

type User(name, passwordHash) =
    // hashs that users password and checks it against 
    // the known hash
    member x.Authenticate(password) = 
        let hashResult = hash(password, "sha1")
        passwordHash = hashResult

    // gets the user logon message
    member x.LogonMessage() = 
        Printf.sprintf "Hello, %s" name

// create a new instance of our class
//let user = User("Robert", "AF73C586F66FDC99ABF1EADB2B71C5E46C80C24A")
let user = User("Robert", 1)

let main() = 
    // authenticate user and print appropriate message
    if user.Authenticate("badpass") then
        printfn "%s" (user.LogonMessage())
    else
        printfn "Logon Failed"

do main()