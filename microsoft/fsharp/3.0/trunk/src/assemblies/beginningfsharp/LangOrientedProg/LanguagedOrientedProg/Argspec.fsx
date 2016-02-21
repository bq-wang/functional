
// what will be covered in this chapter incldue the following
//  1. an simple example of the argspec, which is a  simple form of the language oriented programming 

#I "C:\\ProgramFiles\\FSharpPowerPack-4.0.0.0\\bin"
#r "FSharp.Powerpack.dll"

open Microsoft.FSharp.Text

let myFlag = ref true 
let myString = ref ""
let myInt = ref 0
let myFloat = ref 0.0
(*
notice the code below it reads as reference to a list of string 
*)
let (myStringList : string list ref) = ref []

(*
changing from the plain 

Arg.Set to the 

ArgType.Set


and yo have to change the operator usage to the more C# functional call syntax.
*)


let argList = 
    [ArgInfo("-set", ArgType.Set myFlag, "Sets the value myFlag");
     ArgInfo("-clear", ArgType.Clear myFlag, "Clears the value myFlag");
     ArgInfo("-str_val", ArgType.String(fun x -> myString := x), "Sets the value myString");
     ArgInfo("-int_val", ArgType.Int(fun x -> myInt := x), "Sets the value myInt");
     ArgInfo("-float_val", ArgType.Float(fun x -> myFloat := x), "Set the value myFloat");]

if System.Environment.GetCommandLineArgs().Length <> 1 then 
    ArgParser.Parse(argList,
        (fun x -> myStringList := x :: !myStringList),
        "Arg module demo")
    else
        ArgParser.Usage(argList, "Arg module demo")
        exit 1
printfn "myFlag: %b" !myFlag
printfn "myString: %s" !myString
printfn "myInt: %i" !myInt
printfn "myFloat: %f" !myFloat
printfn "myStringList: %A" !myStringList


(*
if you run the code without any argument, then you will probably get the following output:

unrecognized argument: --fsi-server-output-codepage:65001
Arg module demo
	-set: Sets the value myFlag
	-clear: Clears the value myFlag
	-str_val <string>: Sets the value myString
	-int_val <int>: Sets the value myInt
	-float_val <float>: Set the value myFloat
	--help: display this list of options
	-help: display this list of options
*)

(*

if you run the very code with some argumment, such as the following 

args.exe -clear -str_val "hello world" -int_val 10 -float_val 3.14 "file1" "file2" "file3"

C:\dev\workspaces\functional\microsoft\fsharp\3.0\trunk\src\assemblies\beginningfsharp\LangOrientedProg\LanguagedOrientedProg>fsi Argspec.fsx -clear -str_val "hello world" -int_val 10 -float_val 3.14 "file1" "file2" "file3"
myFlag: false
myString: hello world
myInt: 10
myFloat: 3.140000
myStringList: ["file3"; "file2"; "file1"; "Argspec.fsx"]


*)

