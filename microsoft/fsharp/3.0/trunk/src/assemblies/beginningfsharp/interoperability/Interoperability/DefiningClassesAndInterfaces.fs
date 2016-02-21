//module DefiningClassesAndInterfaces

// what will be covered in this chapter 
//  1. how to define classes and interfaces that makes it easier to interop with C# programmer

(*
general rule, 
tuple style are easier to use in the C# clients 
*)

namespace Strangelights

type DemoClasses(z : int) = 
    // method in the curried style 
    member this.CurriedStyle x y = x + y + z
    // method in the tuple style  
    member this.TupleStyle (x, y) = x + y + z

(*

when viewed from the C#, the member curriedStyle has the following signature 
public FastFuc<int , int> CurriedStyle (int x) ;


whereas the TupleStyle will have the following signature:
public int TupleStyle(int x, int y);

*)


type IDemoInterface = 
    // method in the curried style 
    abstract CurriedStyle: int -> int -> int 
    // method in the tuple style
    abstract TupleStyle : (int * int) -> int 
    // method in the C# style 
    abstract CSharpStyle: int * int -> int 
    // method in the C# style with named arguments 
    abstract CSharpNamedStyle: x : int * y : int -> int 

(*
the first is the curried style 

the second is the tuple style, you will find the implemenation of this style in C# someting like this 

    int TupleStyle(Tuple<int, int>);

the third is tuple style, but with multiple argument , if  you try to implement the method , you will find it as follow 
    int CSharpStyle(int, int);

the last (fourth) is no different from the third one in the eyes of C#, except that from F# aspect, it should named arguments. 



*)