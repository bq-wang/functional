module TypesWithMembers

// F# types with Members

// it is possible to add functions to both F#'s record and union types. You can call a function added to a record or union type using dot notation, just as you can a member of a class from a library not written in F#
// this can be very useful when you wan to expose types you defined in F# to other .NET languages.

// syntax to define F# record or union type with members is the same as the synatx you learned in Chapter 3
// type record|union_type = 
//    { record_definition | union_type_definition } 
//    with 
//        member identifier.member_name(parameter_list) = 
//            member_definition
//NOTE:
// Some OO language use a specific keyword for this, such as "this" or "Me" or even sometime called "self", but F# lets  you choose the name of this parameter by specifying a name for it after the keyword member - x, for .e.g
//

// A point type 
type Point = 
    { Top : int;
      Left : int } 
    with 
        // the swap member creates a new point 
        // with the left/top coords reversed 
        member x.Swap() =
            { Top = x.Left;
              Left = x.Top } 

// create a new point
let myPoint = 
    { Top = 3;
      Left = 7 } 


let main() = 
    // print the initial point
    printfn "%A" myPoint
    // create a new point with the coords swapped
    let nextPoint = myPoint.Swap()
    // print the new point
    printfn "%A" nextPoint

// start the app
do main()

// the union type can as well provide the member functions with the similar syntax.
// 
// a type representing the amount of a specific drink
type DrinkAmount = 
    | Coffee of int
    | Tea of int
    | Water of int
    with 
        // get a string representation of the value 
        override x.ToString() = 
            match x with 
            | Coffee x -> Printf.sprintf "Coffee:%i" x
            | Tea x -> Printf.sprintf "Tea:%i" x
            | Water x -> Printf.sprintf "Water:%i" x
// create a new instance of DrinkAmount
let t = Tea 2

// print out the string 
printfn "%s" (t.ToString())