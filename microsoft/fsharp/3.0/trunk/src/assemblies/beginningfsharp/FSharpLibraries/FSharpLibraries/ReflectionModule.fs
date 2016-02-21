module ReflectionModule

// what we will cover in this chapter
//  1. a summary of the F# reflection system 


(*


F# has some types that are 100 percent compatible with CLR type system
some of the F# types canot be understand by teh .NET reflection 
F# blends with the BCL's System.Reflection namespace
Reflectoin over types are like using the Type, EventInfo FieldInfo, MethodInfo, and PropertyInfo types adn reflection ovre values as calling their members. 
Reflection over values arre like GetProperty, InvokeMember to get values dynamically 


• Reflection over types: Lets you examine the types that make up a particular value or type.
• Reflection over values: Let you examine the values that make up a particular composite value.

*)

