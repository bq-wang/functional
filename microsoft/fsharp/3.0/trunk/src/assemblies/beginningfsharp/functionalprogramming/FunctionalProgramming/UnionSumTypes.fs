module UnionSumTypes

// in this chapter, we will discuss the Union or Sum types

// Union types, sometimes called sum types or discriminated unions
// are a way of bringing together data that may have a different meaning or structure.

// SYntax:
// type type_name = 
//   | constructor
//   | constructor 
//   | ...
// and constructor definition is 
// constructor = Name [ of type [ * type ]]
//            "[]" stands for the optional types.
//
// syntax to create a instance of Union or Sum Types. 
//    let variable = Constructor_Name values
// values can be multiple or single, separated by , and optionally by parenthesis
//    vlaues: [(] value [, value ...] [)]
// 


type Volume = 
    | Liter of float
    | UsPint of float
    | ImperialPint of float

// create instance of those Instances
// 
let vol1 = Liter 2.5
let vol2 = UsPint 2.5
let vol3 = ImperialPint 2.5

// some functions to convert between volumes
let convertVolumeToLiter x = 
    match x with 
    | Liter x -> x
    | UsPint x -> x * 0.473
    | ImperialPint x -> x * 0.568

let convertVolumeUsPint x = 
    match x with 
    | Liter x -> x * 2.113
    | UsPint x -> x 
    | ImperialPint x -> x * 1.201

let convertVolumeToImperialPint x =
    match x with 
    | Liter x -> x * 1.760
    | UsPint x -> x * 0.833
    | ImperialPint x -> x

// a function to print a volume
//let printVolumes x = 
//    printfn "Volume in liters = %f,
//in us pints = %f,
//in imperial pints = %f"
//    (convertVolumeToLiter x)
//    (convertVolumeUsPint x)
//    (convertVolumeToImperialPint x)

// a function to print a volume
let printVolumes x =
    printfn "Volume in liters = %f,
in us pints = %f,
in imperial pints = %f"      
        (convertVolumeToLiter x)
        (convertVolumeUsPint x)
        (convertVolumeToImperialPint x)


// print the results
printVolumes vol1
printVolumes vol2
printVolumes vol3