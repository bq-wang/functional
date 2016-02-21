// this script will show that some thing list operation like indexer is translated to a method call 
// so everything in Scala is essentially a method call

val greetingStrings = new Array[String](3)


greetingStrings(0) = "Hello"
greetingStrings.update(0, "Hello")
greetingStrings(1) = ","
greetingStrings.update(1, ",")
greetingStrings(2) = "world\n"
greetingStrings.update(2, "world\n")

for (i <- 0 to 2 ) 
  print(greetingStrings(i))
  