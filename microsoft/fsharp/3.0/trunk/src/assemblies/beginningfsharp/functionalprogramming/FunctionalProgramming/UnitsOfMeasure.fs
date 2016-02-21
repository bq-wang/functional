module UnitsOfMeasure

// UnitsOfMeasure
//Units of measure are an interesting addition to the F# type system. They allow you to classify numeric
//values into different units. The idea of this is to prevent you from accidentally using a numeric value
//incorrectly—for example, adding together a value that represents inches with a value that represents
//centimeters without first performing the proper conversion.

// e.g. 
// define a unit of measure, do the following.
// to define a unit of measure, 
[<Measure>]type m


// By default, units of measure work with floating-point values—that is, System.Double
//
let meters = 1.0<m>


[<Measure>]type liter

[<Measure>]type pint

let vol1 = 2.5<liter>
let vol2 = 2.5<pint>

// you will get an error indicating the following error:
// 
// UnitsOfMeasure.fs(27,21): error FS0001: The unit of measure 'pint' does not match the unit of measure 'liter'
// > 
//let newVol = vol1 + vol2


// while the multiply and division of different measures are allowed.

// NOTE:
//  there should be no space in-between the numeric_value and <unit>
// define the ration of the pints to liters
let ratio = 1.0<liter> / 1.76056338<pint>

// a function to convert pints to liters
let convertPintToLiter pints =
    pints * ratio

// perform the conversion and add the values 
let newVol = vol1 + (convertPintToLiter vol2)


