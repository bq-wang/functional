// scala_hierarchy_induction.scala


// introduction: scala_hierarchy_induction.scala - induction to scala hierarchy


// Classs AnyRef has the following method
//final def == (that : Any) : Boolean
//final def != (that : Any) : Boolean 
//def equals(that : Any) : Boolean 
//def hashCode: Int
//def toString : String
//def ## :Int

// value types are all abstract, they inherit from the Any class 
new Int 

// there exists implicit conversion from one value type to another. 

42.toString
42.hashCode
42 equals 42
// there is more , the power of implicit cnversion
42 max 42
42 min 43

1 until 15
1 to 5

// in scala, == is not reference equal, if you want to have reference equal, try this: 

val x = new String("abc")
val y = new String("abc")

x eq y

x == y

x ne y




// Bottom types
// the bottom type in Scala class hierarchy is Nothing types

def error(message :String) : Nothing = 
  throw new RuntimeException(message)

def divide(x :Int, y : Int) = { 
  if (y != 0) x / y 
  else error("can't divide by zero")
}
