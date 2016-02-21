module ObjectExpressions

// Object Expressions

// Object expressions are at the heart of succinct object-oriented programming in F#. They provide a concise syntax to create an object that inherits from an existing type.
// this is usefulw if you want to provide a short implementation of an abstract class or interface.
// or if you want to tweak an existing class definition, An object expression allows you to provide an implementation of a class or interface while at
// the same time creating a new instance of it.

// syntax of the Object Expressions is as follow.

// {
//    class_name[<type_parameter>]  [( comma-separated-constructor-list )] 
//      with 
//         member|override member_definition 
// or 
//    interface_name[<type_parameter>] 
//      with 
//         member|override member_definition 
// }
// where the member_definition is like this: 
//   member_definition::= 
//     instance_parameter.method_name(common-separated-method-parameter-list) = 
//          method_definition

// it is possible to implement multipalple interfacs or a class and several other interfaces 
// within one object expression. 
// It’s also possible to attach an interface to a pre-existing class without altering any of
// the class methods.
// the syntax is 
// {
//    class_name[<type_parameter>]  [( comma-separated-constructor-list )] with 
//         member|override member_definition 
//      interface interface_name[<type_parameter>] with 
//         member|override member_definition 
//    ...
// or 
//    interface_name[<type_parameter>] with 
//         member|override member_definition 
//    interface interface_name[<type_parameter>] with
//         member|override member_definition
//    ...
// }
//
// please check the ObjectExpressions_OverrideExample.fs for more details.

open System
open System.Collections.Generic
// a comparer 
let comparer = 
    { new IComparer<string>
        with 
            member x.Compare(s1, s2) = 
                // a function to reverse a string
                let rev(s: String) = 
                    new String(Array.rev (s.ToCharArray()))
                let reversed = rev s1
                // compare reversed string to 2nd strings reversed
                reversed.CompareTo(rev s2) } 

// Eurovision winners in a random order
let winners = 
    [| "Sandie Shaw"; "Bucks Fizz"; "Dana International" ; "Abba"; "Lordi"|]

// print the winners
printfn "%A" winners
// sort the winners
Array.Sort(winners, comparer)
// print the winners again
printfn "%A" winners


open System
open System.Drawing
open System.Windows.Forms

// create a new instance of a number control
let makeNumberControl (n : int) = 
    { new TextBox(Tag = n, Width = 32, Height = 16, Text = n.ToString())
        // implement the IComparable interfaces so the controls
        // can be implemented
        interface IComparable with 
            member x.CompareTo(other) = 
                let otherControl = other :?> Control in 
                let n1  = otherControl.Tag :?> int in
                n.CompareTo(n1) } 
// a sorted array of the numbered controls
let numbers = 
    // initialize the collection 
    let temp = new ResizeArray<Control>()
    // initiaze the random number generator
    let rand = new Random()
    // add the controls collection 
    for index = 1 to 10 do 
        temp.Add(makeNumberControl (rand.Next(100)))
    // sort the collection 
    temp.Sort()
    // layout the controls correctly 
    let height = ref 0
    temp |> Seq.iter
        (fun c -> 
            c.Top <- !height
            height := c.Height + !height)
    // return collectoin as an array 
    temp.ToArray()

// create a form to show the number controls
let numbersForm =
    let temp = new Form() in 
    temp.Controls.AddRange(numbers)
    temp

// show the form
//[<STAThread>]
//do Application.Run(numbersForm)