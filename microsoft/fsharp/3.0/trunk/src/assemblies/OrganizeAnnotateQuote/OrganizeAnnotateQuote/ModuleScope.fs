module ModuleScope

// what we will cover in this chapter
//  1. the module that you passed to the compiler is important. 
//  

// - NOTE:
//  why the order of is important, because 
// (1). it affect the scope of the identifiers within the modules
// (2). the order that you execute the modules.


// you compile the modules in this order, that will be fine 

// fsc ModuleOne.fs ModuleTwo.fs -o ModuleScope.exe

// while if you compile the code in this order, 

// fsc ModuleOne.fs ModuleTwo.fs -o ModuleScope.exe