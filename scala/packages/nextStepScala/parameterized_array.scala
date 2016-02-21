val greetingStrings = new Array[String](3)


greetingStrings(0) = "Hello"
greetingStrings(1) = ","
greetingStrings(2) = "world\n"

for (i <- 0 to 2 ) 
  print(greetingStrings(i))
  
  
  
  
// as well, the List constructor is a apply method on the companion object
val numNames = Array("zero", "one", "two")


// that is equally to the following statement
val numNames2 = Array.apply("zero", "one", "two")

// to prove that numNames2 is indeed constructed with the correct information 
for (i <- numNames2)
  print(i)