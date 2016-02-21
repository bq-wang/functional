module Scope_ChangeType

// you can change type of the scoped identifiers, the type safety is not breaking


let changeType () = 
    let x = 1
    let x = "chagne me"
    // Error	3	This expression was expected to have type     string     but here has type     int
    let x = x + 1  // attempt to rebind to itself plus an integer
    printfn "%s" x