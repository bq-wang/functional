// patterns_in_for_expression.scala

// description:
//   patterns in the for expression.

// pattern in for - simpler forms
val capitals = Map("France" -> "Paris", "Britain" -> "London")

for ((country, city) <- capitals )  // tuple patterns in for expression 
  println("The capital of " + country + " is " + city )

  
val results = List(Some("apple"), None, Some("Orange"))
  
for (Some(fruit) <- results) println(fruit) // partial functions, those does not match is filtered out   