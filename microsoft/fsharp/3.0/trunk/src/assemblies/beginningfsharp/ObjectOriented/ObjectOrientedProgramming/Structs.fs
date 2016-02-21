module Structs

// in this chapter, you will be able to learn
//   how to define an struct
//   what is the difference between a struct and a class

// syntax:
// the syntax of defining stack is the same as that of defining classes, except that you replace the 'class'
// keyword with the 'struct' keyword

// difference:
//  struct are allocated on the stack (fast allocation/reclaimation and fast acces to the members), but slower when passing as parameter) 
//  struct cannot have inheritance, (so you cannot have polymorphism)..


type IpAddress = struct 

    val first : byte
    val second : byte
    val third : byte
    val fourth : byte
    new (first, second, third, fourth) = 
        { first = first;
          second = second;
          third = third;
          fourth = fourth; } 
    override x.ToString() = 
        Printf.sprintf "%O.%O.%O.%O" x.first x.second x.third x.fourth
    member x.GetBytes() = x.first, x.second, x.third, x.fourth

end