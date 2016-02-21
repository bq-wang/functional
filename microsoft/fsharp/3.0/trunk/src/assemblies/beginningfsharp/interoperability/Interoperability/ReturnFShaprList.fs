//module ReturnFShaprList

module Strangelights.ReturnFSharpList

(*

how to make things more natural for C# programmer, 

1. convert a list to an array using the List.toArray 
2. System.Collections.Generic.List using the new ResizeArray<_>
3. System.Collections.Generic.IEnumerable using the List.toSeq function 
4. MSDN recommend to use yet Collectoin or ReadOnlyCollection from the System.Collections.ObjectModel namespace namespace to expose collections.


*)


// gets  a preconstructed list 
let getList() =
    [1; 2; 3]
