module ClassesAndInheritance

// what shall be covered in this post include the following.
//  basics of inheriting from a base class and adding new functionality

// syntax
//  subclass inherits baseclass
//
// type sub_name(comma-separated-parameter-list) = 
//   inherit base_name(comma-separate-parameter-list)
//   class-member-definitions


type Base() =
    member x.GetState() = 0

type Sub() = 
    inherit Base()
    member x.GetOtherState() = 0

let myObject = new Sub()

printfn 
    "myObject.state = %i, myObject.otherState = %i" 
    (myObject.GetState())
    (myObject.GetOtherState())

