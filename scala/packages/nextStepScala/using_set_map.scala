// this script will demonstrate the use of set and Map in Scala
// on par with (as with) List in using_list.scala, there is a mutable and immutable set


var jetSet = Set("Boeing" , "Airbus")
jetSet += "Lear"                    // it is quite interesting to note that immutable Set do NOT have a '+=' operator
                                    // the mutable set do have one, the '+=' with Immutable Set is a shorthand for 
                                    // jetSet = jetSet + "Lear"

println(jetSet.contains("Cessna"))


// below will show how to program against the mutable set

import scala.collection.mutable.Set

val movieSet = Set("Hitch", "Poltergeist") // normally 'var' will pick the Mutable one, you can import the type explicitly so val can point to mutable as well?
movieSet += "Shrek"
println(movieSet)



import scala.collection.immutable.HashSet // HashSet is a specialized Set

val hashSet = HashSet("Tomatos", "Chilies")
println(hashSet + "Coriander")


import scala.collection.mutable.Map

val treasureMap = Map[Int, String]()      //  Generic Is bulit-in in Scala
treasureMap += (1 -> "Go to island")
treasureMap += (2-> "Find big on groun")
treasureMap += (3 -> "Dig.")


println(treasureMap)


// you can use the Map constructor 
val romanNumeral = Map(1-> "I", 2 -> "II", 3 -> "III", 4-> "IV", 5 -> "V")

println(romanNumeral(4)) // do a key query on the romanNumeral map 