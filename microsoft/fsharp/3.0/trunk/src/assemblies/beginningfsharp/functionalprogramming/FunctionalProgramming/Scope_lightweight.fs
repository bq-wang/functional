module Scope_lightweight

// actually we are demonstrating with the heavyweight syntax 

// you will get an warning with the code below... sounds like you are encouraged to create an .ml file for such directive 

#light "off"

// In OCaml, scope is controlled though the use of the in keyword.
let halfWay a b = 
    let dif = a - b in
    let mid = dif / 2 in
    mid + a

