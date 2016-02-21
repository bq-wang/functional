module Enums

// in this chapter, we will cover the following.
//    1. what is an enum
//    2. how to define an enum
//    3. flag enums

// what is an enum
//   Enums allow you to define a type made up of a finite set of identifiers, with each identifiers mapping to an integer

// the syntax
// the syntax is very similar to the union(sum) type but 
// it does not have the (union' parameter-list) 
// type enum_type = 
//    | enum_identifier = enum_value
//    | enum_identifier = enum_value
//    | ...

// compares that to the union(sum) type
// type union_type = 
//    | union_idenfier of union-parameter list 
//    | union_idenfier of union-parameter list 
//    | ...



type Scale = 
    | C = 1
    | D = 2
    | E = 3
    | F = 4
    | G = 5
    | A = 6
    | B = 7

// flag unions
[<System.Flags>]
type ChordScale = 
    | C = 0b0000000000000001
    | D = 0b0000000000000010
    | E = 0b0000000000000100
    | F = 0b0000000000001000
    | G = 0b0000000000010000
    | A = 0b0000000000100000
    | B = 0b0000000001000000

// as of how to use the neum values, we will discuss it later on chapter 7 

