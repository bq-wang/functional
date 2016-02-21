module MethodsAndInheritance

// what shall be covered in this post include the following.
//  will show you how to implement methods to make full use of inheritance

// syntax how to define methods
//
//   class-member--methods-definitions
//  class-member--methods-definitions:: 
//      member new_member_method_definiiton
//      override override_method_definition
//      abstract abstract_memton_declaration
//      default abstract_method_definition
//

//a base class
type Base() =
    // some internal state for the class
    let mutable state = 0
    // an ordinary member methods
    member x.JiggleState y = state <- y
    // an abstract method
    abstract WiggleState : int -> unit
    // a default implementation for the abstract method
    default x.WiggleState y = state <- y + state
    member x.GetState() = state


// a sub class
// what is the operator &&&
type Sub() = 
    inherit Base()
    // override the abstract method 
    default x.WiggleState y = x.JiggleState ( x.GetState() &&& y)

// create instance of both methods
let myBase = new Base()
let mySub = new Sub()

// NOTE:
// what is the use of the "#" symbol here ?
//

// a small test for our classes
let testBehaviour (c : #Base) = 
    c.JiggleState 1
    printfn "%i" (c.GetState())
    c.WiggleState 3
    printfn "%i" (c.GetState())

// run the test 
let main() = 
    printfn "base classes:"
    testBehaviour myBase
    printfn "Sub classes:"
    testBehaviour mySub
// do main
//do main()