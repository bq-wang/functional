module SomeNamespace.Lib
// what we will learn from this chapter
//   1. what is a signature file 
//   2. how to use the signature3 file 

// - NOTE:
//  Signature files give you a way of making function and value definitions private to a module

// define a function to be exposed 
let funkyFunction x = 
    x + ": keep it funky!"

// define a function that will be hidden 
let notSoFunkyFunction x = x + 1

// NOTE - how to create signature file 
// you can use the following command to use as follow 
//         fsc -i SignatureFiles.fs

// and you can use the following command to feed in the .fsi file (the signature files) 

// fsc -a Lib.fsi Lib.fs