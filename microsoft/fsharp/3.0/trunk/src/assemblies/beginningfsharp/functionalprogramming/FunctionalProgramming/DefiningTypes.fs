module DefiningTypes

// defining types

// the following types are definable.


// Tupes or records.  (similar to structs in C or classes in C#)
// Sum types, sometimes referred to as union types (referred to as union types)


// -- Tuple and Record Types

// NOTE: the _ can be used to denote some fields that you are not interested in .
let pair = true, false
let b1, _ = pair
let _, b2 = pair

// define a type with the "type" keyword
// first define a "record type"
// syntax:
//   type type_name = type_definition
//   type type_name = type_alias
type Name = string
type Fullname = string * string

let fullNameToString (x: Fullname) = 
    let first, second = x in 
        first + " " + second

// -- Record types are similar to the tuples in that they compose multiple types into a single type
// 
// to define a record, with the following syntax
//  type type_name = { field : fiel_type; field : field_type; ... } 
// to create a record, with the following syntax
//  let (variable_name : record_type } = { field = filed_value; filed = field_value; ... } 
//

// definition an organization with unique fields
type Organizion1 = { boss: string; lackeys: string list }
// create an instance of this organization
let rainbow = 
    {boss = "Jeffrey";
        lackeys = ["Zippy"; "George"; "Bungle" ] }

// define two organizations with overlapping fields
type Organization2 = { chief: string; underlines: string list } 
type Organization3 = { chief: string; indians: string list } 

// create an instance of Organization2
let (thePlayers: Organization2) = 
    { chief = "Peter Quine";
        underlines = ["Francis Flute"; "Robin Starveling";
        "Tom Snout"; "Snug"; "Nick Bottom"] }

// create an instance of Organization3
let ( wayneManor : Organization3) = 
    { chief = "Batman"; 
    indians = ["Robin"; "Alfred"] }



// -- accessing the fields in a record is fairly straightfoward. 
// to acces a field in a record, just simply use the '.' notation 

// define an organization type 
type Organization = { chief: string; indians: string list } 

// create an instance of this type 
let wayneManor = 
    { chief = "Batman";
      indians = ["Robin"; "Alfred"] } 

// access a field from this type 
printfn "wayneManor.chief = %s" wayneManor.chief

// -- Records are immmutable
// 


// -- create a copy of a record with updated fields
// syntax:
//   let variable = { record_variable with update_fiels } 
//  update_fields = field = field_value; field = field_value; ...

// define an organization type 
type Organization = { chief: string; indians: string list } 

// create an instance of this type 
let wayneManor = 
    {chief = "Batman";
     indians = ["Robin"; "Alfred"] }

// create a modified instance of this type 
let wayneManor' = 
    { wayneManor with indians = ["Alfred"] }

// print out the two organizations
printfn "wayneManor = %A" wayneManor
printfn "wayneManor' = %A" wayneManor'


// access the fields with pattern matching 

// type representing a couple
type Couple = { him: string; her : string } 

// list of couples 
let couples =  
    [ { him = "Brad"; her = "Angelina" } ;
      { him = "Becks"; her = "Posh" } ;
      { him = "Chris"; her = "Gwyneth" } ;
      { him = "Michael"; her = "Catherine" } ]

// function to find "David" from a list of couples 
let rec findDavid l = 
    match l with 
    | { him = x; her = "Posh" } :: tail -> x
    | _ :: tail -> findDavid tail
    | [] -> failwith "Couldn't find david"

// print the results
printfn "%A" (findDavid couples)

// - NOTE :
// some notes on the pattern matching, to find some variable patterns, you might need to use the 

let rec findPartner soughtHer l = 
    match l with 
    | { him = x; her = her } :: tail when her = soughtHer -> x
    | _ :: tail -> findPartner soughtHer tail
    | [] -> failwith "Couldn't find him"

// - NOTE:
// Field Values can also be functions. Since this technique is mainly used in conjunction with a mutable state to form values similar to objects