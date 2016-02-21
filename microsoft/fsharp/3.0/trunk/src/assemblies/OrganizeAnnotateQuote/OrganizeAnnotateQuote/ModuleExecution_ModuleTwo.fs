module ModuleExecution_ModuleTwo

// these two lines should be printed first 
printfn "This is the first line"
printfn "This is the second"

// - directive: uncomment the following 
// function to access ModuleOne 
let func() = 
    printfn "%i" ModuleExecution_ModuleOne.n

func()