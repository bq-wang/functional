// this script will demonstrate the use of List (one of hte most basic collection type) in Scala
// SCala has provided a mutable version and an immutable version of Set for you to use 

val oneTwo = List(1, 2)
val threeFour = List(3, 4)
val oneTwoThreeFour = oneTwo :: threeFour  // there is a rule in that method ending with a ':' will be right associative
                                           // which in this case, it is that (threeFour).::oneTwo
                                           // b.t.w: '::' is pronounced as 'con'

println(oneTwo + " and " + threeFour + " were not mutated")
println("Thus, "  + oneTwoThreeFour  +  "is a new List")


// while you can operate on the mutable versions of collection 
val oneTwoThree = 1 :: 2 :: 3 :: Nil      // this shows you how to construct a list from literal


var oneTwo1 = List(1, 2)
var threeFour1 = List(3, 4)
println("oneTwo1 :: threeFour1 " + oneTwo1 :: threeFour1)
threeFour1 = (oneTwo1 ::: threeFour1) // cannot use '::' here, think of WHY?
println("oneTwo1 " + oneTwo1)
println("threeFour1 " + threeFour1)