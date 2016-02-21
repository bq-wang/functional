module ClassesAndStaticMethods

// in this post, we will cover the following topic
//   Static methods are like  instance methods, except they are not specific to any instance of a class, so have no access to a class's fields
// syntax of that is like below:
//   static-member-definition:: 
//      static member static-member-name parameter-list = function-body
// to call the static methods,
//    type.Static-methods-name argumuent-list

// you can define operator with the static methods sytnax, here is the syntax
//   static-member-definition:: 
//      static member (operator-name) parameter-list = function-body
// remember the parameter style of the static member is the (tuple style) (rather than the record style)

//open Strangelights.Sample.Helpers

type User(name, passwordHash) = 
    // hashs the users passwod and checks it against
    // the known hash 
    member x.Authenticate(password) = 
        let hashResult = hash(password, "sha1")
        passwordHash = hashResult
    // gets teh user logon message
    member x.LogonMessage() = 
        Printf.printf "Hello, %s" name
    // a static member that provides an alternative way 
    // of creating the object
    static member FromDB id = 
//        let name, ph = getUserFromDB id
        let name, ph = "joe", 1
        new User(name, ph) 


let user = User.FromDB 1


type MyInt(state : int) = class
    member x.State = state
    static member (+) (x:MyInt, y:MyInt) : MyInt = new MyInt(x.State + y.State)
    override x.ToString() = string state
end


let x = new MyInt(1)
let t = new MyInt(1)