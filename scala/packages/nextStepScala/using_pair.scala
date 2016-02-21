// this file will demonstrate the simple use of Pair in Scala
val pair = (99, "Luftballons")
println(pair._1)
println(pair._2)

// and there is a shorthand that you can use to create pairs. that on every object in Scala, you can apply a '->' operator 
// to create two element tuple 
val pair2 = 1 -> "Treasure Island"

println(pair2._1)
println(pair2._2)