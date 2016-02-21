// Namespaces help you organize your code hierarchically. To help keep modules names unique across
//assemblies, you qualify the module name with a namespace name, which is just a character string with
//parts separated by dots

// what we will cover the following in the topic in this chapter
//   1. how to define module inside namesapce 
//   2. how to place submodule inside a namespace 
//   3. namespace can exist without module, such namespace can only have type definitio 
//   4. you cannot define value definition directly inside the namespace  

// put the file ina namespace 
namespace Strangelights.Beginning 

// create a first module 
module FirstModule  =
    let n = 1
    // create a second module 
module SecondModule = 
   let n = 2
   // create a third module 
   // nested inside the second 
   module ThirdModule = 
       let n = 3



// it also possible to place several namespace declaration in the same source file, but you must declare them at the top level 
// not sure if this is what is desired. 
//namespace A
//module FirstModule  =
//    let n  = 1
//
//namespace B
//
//module FirstModule = 
//    let n = 1
//namespace D
//module C = 
//    // create a second module 
//    module SecondModule = 
//        let n = 2 
//        // create a third module 
//// now access the modules with the A.FirstModule, B.SecondModule, and etc..

// which equals to the following 

//namespace Strangelights.Beginning 
//module ModuleDemo





//// a namespace definition 
//namespace Strangelights.Beginning 
//// a record definition 
//type MyRecord = { field : string } 
//
//// a namespace definition 
//namespace Strangelights.Beginning 
//
//// a value definition, which is illegal 
//// directly inside a namespace 
//let value = "val"
