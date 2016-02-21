//module ModuleExecution

// in this chapter, we will cover 
//   1. the Module exectuion 


// the order of module execution will determine the observed behaviour of the Module .

// roughly speaking. 
// (1). F# starts at the top of a module and works its way down to the bottom.
// (2). Any value that are not function are calculated
// (3).  and any statement at the top-level or any top-level do statement are executed. 

(*module ModuleExecution =*)
    module ModuleExecution
    //module ModuleOne

    // statements at the top-level 
    printfn "This is the first line"
    printfn "This is the second"


    // a value defined at the top-level 
    let file =
        let temp = new System.IO.FileInfo("test.txt") in 
        printfn "File exists: %b" temp.Exists
        temp 

// there are some special rules about the module execution. they are  :
// (1). When a source file is compiled into an assembly, none of the code in it will execute until a value from it is used by a currently executing function. 
// (2) when the first value in the file is touched, all the let expressions and do statements in the module will execute in their lexical  order. 
// (3) When you split a program over more than one module, the last module passed to the compiler is
// special. All the items in this module will execute, and the other items will behave as they were in an assembly. 
// (4). Items in other modules will execute only when a value from that module is used by the module currently executing. Suppose you create a program with two modules.


// compile the code as follow 
//  fsc ModuleExecution_ModuleOne.fs ModuleExecution_ModuleTwo.fs -o ModuleExecution.exe