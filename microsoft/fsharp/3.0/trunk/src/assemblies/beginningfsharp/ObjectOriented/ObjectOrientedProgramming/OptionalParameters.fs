module OptionalParameters

// optiona parameter are allowed in the method mmeber or the function 
// you mark a parameter as optional by prefixing it with a question mark..
// if there are more than one optoinal parameters, but the optional parameter must always appear at the end of the parameter lsit. 
// Also, you must use the tuple style in cases where you have a member method that contains more than one arugument with one or more optional argument.
// Optional parameters are always of the option<'a> type, so you must not include them in the type annotation. (JOE: this means that the compiler has already done some special  handling with it )
// syntax of optional parameter
//
//  method_name(positional_parameter, ?optional_parameter_name: parameter_type)
//   method_body
// 
// where the method_name can be used as the name of the constructor, function, member method.
//
// because of the optional parameter is passed in as a Option, you can deal with it like this:  
//   match optional_parameter_name with 
//   | Some x -> .. 
//   | None -> 
// 

type AClass(?someState : int) = 
    let state = 
        match someState with 
        | Some x -> string x
        | None -> "<no input>"
    member x.PrintState (prefix, ?postfix) = 
        match postfix with 
        | Some x -> printfn "%s %s %s" prefix state x
        | None -> printfn "%s %s" prefix state

let aClass = new AClass()
let aClass' = new AClass(109)

aClass.PrintState("There was ")
aClass.PrintState("INput was:  ", " which is nice. ")



