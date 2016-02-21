module List_Comprehensions

// Sounds familiar , we used to have the List Comprehensions in Python 
// now python is more proclivity to the generator syntax

// 
// list comprehension 
//   range_expr : start .. step .. end
//   [ list_comprehension ] creates a list 
//   { list_comprehension } create a sequence 
//   { collections_with_loops} create a collection 
//NOTE:
// seq { list_comprehension } :: create a seq object with sequence


// create some list comprehensions

// take notice of the '..' inside the notation. 
let numericList = [0 .. 9]


// seq is a function or a keyword ??
let alpherSeq = seq { 'A' .. 'Z'}

// result type:: val it : seq<char> = seq ['A'; 'B'; 'C'; 'D'; ...]
{ 'A' .. 'Z'}


// print them
printfn "%A" numericList
printfn "%A" alpherSeq


// create some list comprehensions
//  start .. step .. end
let multiplesOfThree = [0 .. 3 .. 30]
// can walk downward
let revNumbericSeq = [9 .. -1 .. 0]


// print them 
printfn "%A" multiplesOfThree
printfn "%A" revNumbericSeq


// Loops is allowed 
// a sequence of squares 
let squares = 
    seq { for x in 1 .. 10 -> x * x} 

// print the message
printfn "%A" squares


// but yield (the a.k.a) is more flexile, (we called that the generator expression or the generator)

// a sequence of even numbers
let evens n = 
    seq { for x in 1 .. n do 
            if x % 2 = 0 then yield x }

// print the sequence 
printfn "%A" (evens 10) 

// list comprehension in more than one dimensions 
// sequence of tuples representing points 
let squarePoints n = 
    seq { for x in 1 .. n do 
            for y in 1 .. n do 
                yield x, y  } 

// print the sequence 
printfn "%A" (squarePoints 3) 