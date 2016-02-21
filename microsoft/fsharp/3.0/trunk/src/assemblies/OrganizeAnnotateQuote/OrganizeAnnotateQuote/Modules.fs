//F# code is organized into modules, which are basically a way of grouping values and types under a
//common name

// in this chapter, we will cover the following 
//    1. how to create nested modules 
//    2. how to access variables from each modules


// to create nested module, 
//   module outermodule = 
//   module innermodule ....


// create a top level modle 

module ModuleDemo 

// create a first module 

module FirstModule = 
    let n = 1

// create a second module
module SecondModule =  
    let n = 2 
    // create a third moduel 
    //  nested inside the second 
    module ThirdModule = 
        let n = 3

