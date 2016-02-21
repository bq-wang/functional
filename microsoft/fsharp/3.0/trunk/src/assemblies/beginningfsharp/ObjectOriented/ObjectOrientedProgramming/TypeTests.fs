module TypeTests

// in this chapter we will cover the following 
//  closely related to casting is the the idea of type tests, you can bind an identifier to an object of a derived type, as you did ealier when you boudn a string to an identifier of type obj:

// syntax
// the operator that is used to test if 

let myObjct = ("this is a string" :> obj)

let anotherObject = ("this is a string" :> obj)


if (anotherObject :? string) then  
    printfn "This object is a string"
else 
    printfn "This object is not a string"

if (anotherObject :? string[]) then 
    printfn "this object is a string array"
else 
    printfn "This object is not a string array"

