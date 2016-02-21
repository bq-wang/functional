// 在 http://fsharp.net 网站上了解有关 F# 的更多信息

module Program

(*

two core libraries:


FSHarp.FSharp.Core.dll
FSharp.PowerPack.dll



Core is small, cohesive, has small footprint 

Powerpack: which can have interesting new features. 

*)

(*

the native F# libraries contains alll the classes that you need tomake the compiler work, such asthe definition 
of the type into which F# list literal compiles, I'll cover the following module .


Microsoft.FSharp.Core.Operators: A module containing functions that are mathematical operators.
Microsoft.FSharp.Reflection: A module containing functions that supplement the .NET Framework’s reflection classes to give a more accurate view of F# types and values.
Microsoft.FSharp.Collections.Seq: A module containing functions for any type that supports the IEnumerable interface.
Microsoft.FSharp.Text.Printf: A module for formatting strings. 
Microsoft.FSharp.Control.Event: A module for working with events in F#.

*)