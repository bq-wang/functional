// abstract_class.scala

// description:
//  abstract_class.scala is the file that demonstrate how to define and use the abstract class

abstract class Element { 
  def contents : Array[String]
  
  // you can define parameterless methods
  
  
  def height: Int = contents.length
  def width : Int = if (height == 0) 0 else  contents(0).length
  
  // one note on the parameter list, instead of the empty parameter notation such as ()
  //  we did not even provide a parameter
  // it was because there is such a convention, in that 
  // if the function does not have side effect and it takes no parameter, we default provide non-parameter list
  // otherwise, we provide a void (empty ) parameter
  // we shall see that later there are some other benefit later. 
  
}

 

abstract class ElementAlternative { 
  def contents : Array[String]
  
  // we can also use val, instead of def
  // the good side is that it is faster, but we may require some additional memory spaces
  // another thing is that if you have a 'pure' def function, it is generally 
  // safe to change that to a val declaration, (because val is generally pure ) 
  val  height : Int = contents.length
  
  val  width : Int = if (height == 0) 0 else  contents(0).length
}


// Extending class
class ArrayElement_pre1(conts: Array[String]) extends Element  {
  def contents : Array[String]  = conts;
}

// however, we have to first come up with a dummy parameter in the constructor, and we only used that parameter
// for initialize the contens property, is there any better way ? 

val ae = new ArrayElement_pre1(Array("Hello", "World"))

ae.width

// that is so typical, that, you may get what the meaning of the following.
val e : Element = new ArrayElement_pre1(Array("Hello", "World"))
e.width

// overriding methods and field
// you can change the def implementation from val definition in the 
// extended class wihtout having to modify the abstract method definition below 
class ArrayElement_pre2(conts : Array[String]) extends Element { 
  val contents : Array[String] = conts
}


// said before that we dislike the idea that 
// the sole purpose of the parameter used to initilalize the contents function
// in fact, "parametric field" such as below will combine  the parameter and the field
// in one definition
// NOTE: there is a "val" before the 'contents" parameter
class ArrayElement_pre3(val contents: Array[String]) extends Element

// it has the same meaning as below 
// class ArrayElement_pre3(x123 : Array[String]) extends  Element  {
//   val contents = Array[String] = x123
// }

class ArrayElement (val contents : Array[String]) extends Element

// with the parametric field, you can do more (override, public, private, var) , as follow 

class Cat {
  val dangerous  = false
}

class Tiger (
  override val dangerous : Boolean,
  private var age : Int

) extends Cat

val tiger = new Tiger(true, 10)
tiger.dangerous

// invoke super
// just place the parameter in the super class after the Extends keyword
class LineElement (s: String) extends ArrayElement(Array(s)) {
  override def width = s.length
  override def height = 1
}

class UniformedElement (
  ch : Char,
  override val width  : Int,
  override val height : Int
    ) extends Element {
  private val line = ch.toString * width
  def contents = Array.fill[String](height)(line)
  
  // be careful that the two calls are indeed different
//  Array.fill[String](height)(line)
//  Array.fill(height)(line)
}

// how to declare a final member
// or a final class
abstract class Element_pre1 {
  def demo() = { println( "Element's implementation invoked")}
}

class ArrayElement_pre4 extends Element_pre1 {
  final override def demo() = { println( "ArrayElement_pre4 implementation invoked")}
}

class LineArrayElement_pre1 extends ArrayElement_pre4 { 
  override def demo() { println("LineArrayElement_pre's implementation invoked")}
}

// you can even make the class final itself 
final class ArrayElement_pre5 extends Element_pre1 {
  override def demo() {
    println("ArrayElement_pre5's implementation inovked")
  }
}

class LineArayElement_pre2 extends ArrayElement_pre5 {
  override def demo() {
    println("LineArayElement_pre2's implementation inovked")
  }
}

// A note on the coding style and convention

// good 
Array(1, 2, 3).toString
"abc".length


Array(1, 2, 3).toString()
"abc".length()

// bad
println
// good
println()
