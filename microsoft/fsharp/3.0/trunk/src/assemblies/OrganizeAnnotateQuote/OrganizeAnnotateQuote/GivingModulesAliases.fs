module GivingModulesAliases

// what we will learn from this modules 
//  1. how to give an alias to a module 

// give an alias to the Array3 module 
module ArrayThreeD = Microsoft.FSharp.Collections.Array3D

// create an matrix using the module alias 
let matrix = 
    ArrayThreeD.create 3 3 3 1

