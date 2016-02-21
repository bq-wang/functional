module PropertiesAndIndexers

// what shall be covered in this post include the following.
//  Properties
//  indexers
//
// Properties is a speical type of method that looks like a vlaue to eth code that calls it 
// indexer fulfill a similar purpose. 
//

// syntax of the properties is as follow. 
//   member instance_identifier.property_name 
//      [with get() = get_accessor_definition]
//      [and set set_acessor_parameters = set_accessor_definition
//

// syntax of the abstract proeprties is as follow
//   abstract property_name
///     with comma-separated-get-or-and-set


// a class with Properties
type Properties() =
    let mutable rand = new System.Random()
    // a property definition 
    member x.MyProp 
        with get() = rand.Next()
        and set y = rand <- new System.Random(y)

// create a new instance of our class
let prop = new Properties()

// run some tests for the class
prop.MyProp <- 12
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp
printfn "%d" prop.MyProp

// an interface with an abstract property 
type IAbstractProperties = 
    abstract MyProp : int 
        with get, set

// a class that implements our interface
type ConcreteProperties() = 
    let mutable rand = new System.Random()
    interface IAbstractProperties with 
        member x.MyProp
            with get() = rand.Next()
            and set(y) = rand <- new System.Random(y)


// a class with indexers
type Indexers(vals : string[]) = 
    // a normal indexer
    // NOTE:
    //  if the programmer choose the speical name "Item"
    //  then there is a special syntax that helps you to access the elment , like "Object.[x]"
    member x.Item 
        with get y = vals.[y]
        and set y z = vals.[y] <- z
    // an indexer with an unusual name
    // NOTE:
    //  you can only use the record type in prperties.
    // if you try to use some tuple style, as below, you will get error compiling.
    member x.MyString 
        with get (y) = vals.[y]
        and set y z = vals.[y] <- z
    // you cannot have tupe-style like member, because the 
    // tuple like mehtod are by default type "unit"
//    member x.MyString2 
//        with get (y) = vals.[y]
//        and set (y, z) = vals.[y] <- z
     // the above is the same as the following.
//    member x.MyString3 
//        with get (y) : string = vals.[y]
//        and set (y, z) : unit = vals.[y] <- z
    // F# can help optimize if you have just one argument 
    // it can automaticlaly unwrap and return a you F# style functional argument
//    member x.MyString4 
//        with get (y) : string = vals.[y]
    // it won't help if you try to return some value from the 
    // side-effect method (the tuple parameter one_ 
//    member x.MyString5 
//        with get(y) : string = vals.[y]
//        and set (y, z) = 
//            vals.[y] <- z
//            let n = vals.[y]
//            n

// create a new instance of the indexer class
let index = new Indexers [| "One"; "Two"; "Three"; "Four"|]

// test the set indexers
index.[0] <- "Five"
index.Item(2) <- "Six"
index.MyString(3) <- "Seven"

printfn "%s" (index.MyString 3)
printfn "%s" (index.MyString (3))

//let b = (2)
//let a = index.MyString4 b
//printfn "%s" (index.MyString2 (2))
