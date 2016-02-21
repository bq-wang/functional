module IntroducingLINQ

//module Strangelights.LingqImports
open System
open System.Linq
open System.Reflection

// define easier access to LINQ methods

let select f s = Enumerable.Select(s , new Func<_, _> (f))
let where f s = Enumerable.Where(s, new Func<_,_>(f))
let groupBy f s = Enumerable.GroupBy(s, new Func<_,_>(f))
let orderBy f s = Enumerable.OrderBy(s, new Func<_,_>(f))
let count s = Enumerable.Count(s)

// once that you have import the functions, you can apply them easily, typically by using hte pipe-forward operator.

open System
//open Strangelights.LinqImports

// query string methods using functions
let namesByFunction = 
    (typeof<string>).GetMethods()
    |> where (fun m -> not m.IsStatic) 
    |> groupBy (fun m -> m.Name)
    |> select (fun m -> m.Key, count m) 
    |> orderBy (fun (_, m) -> m) 

// print out the data we've retrieved from about the string classes
namesByFunction 
    |> Seq.iter (fun (name,  count) -> printfn "%s - %i" name count) 

(*

the output of the program is as follow 
get_Chars - 1
CopyTo - 1
GetHashCode - 1
get_Length - 1
TrimStart - 1
TrimEnd - 1
Contains - 1
ToLowerInvariant - 1
ToUpperInvariant - 1
Clone - 1
Insert - 1
GetTypeCode - 1
GetEnumerator - 1
GetType - 1
ToCharArray - 2
Substring - 2
Trim - 2
IsNormalized - 2
Normalize - 2
CompareTo - 2
PadLeft - 2
PadRight - 2
ToLower - 2
ToUpper - 2
ToString - 2
Replace - 2
Remove - 2
Equals - 3
EndsWith - 3
IndexOfAny - 3
LastIndexOfAny - 3
StartsWith - 3
Split - 6
IndexOf - 9
LastIndexOf - 9

*)