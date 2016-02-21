//module HostClrTestModule

// what will be covered in this chatper 
//  1. show how to host CLR and execute code within a module

namespace Strangelights

module TestModule =
    // function will be invoked
    let print s = 
        printfn "%s" s
        0
