
// what will be covered in this chapter 
//  1. calling FSharp libraries from C# introduction and some rules that helps to make the library as friendly as possible. 

(*

1. always use a signature .fsi file or the private and internal to hide implementation details and documents the API expected by client
2. Avoid public functions that return tuples. 
3. If you want to expose a function that make another fun ction as a value, expose the vlaue as a delegate
4. Do not use union type in the API, but if you absolutely must use these types, add members to make htem easier to use 
5. avoid returning F# lists, and use the array, System.Collections.Generic.IEnumerable or better yet Collectoin or ReadonlyCollection in the System.Collections.ObjectModel namespace instead
6. when possible , place type definition in a namespace, and place nly value definitions within a module 
7. be careful with the signatures you define on classes and interfaces, a small change in the syntax can make a big difference 



*)