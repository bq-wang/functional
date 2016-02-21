// linearization_traits.scala

// linearization_traits.scala show how the linearization works in terms of the scala traits

// case 1 : Rectangular objects

class Point(val x : Int, val y : Int)

class Rectangle (val topLeft : Point , val bottomRight : Point) {
  def left = topLeft.x
  def right = bottomRight.x
  def top = topLeft.y
  def bottom = bottomRight.y
  def width = right - left
  def height = bottom - top
}


// and if you use traits

class Point(val x : Int, val y : Int)

trait Rectangular {
  def topLeft : Point
  def bottomRight : Point
  def left = topLeft.x
  def right = bottomRight.x
  def top = topLeft.y
  def bottom = bottomRight.y
  def width = right - left
  def height = bottom - top
}


class Rectangle(val topLeft : Point, val bottomRight : Point) extends Rectangular {
}


val rect = new Rectangle(new Point(1, 1), new Point(200, 200))

rect.left
rect.right
rect.width
rect.height
rect.top
rect.bottom


// trait in real use-case
// trait Ordered


class Rational(n :Int, d: Int) extends Ordered[Rational] {
  val number = n
  val denom = d
  def compare(that : Rational) = (this.number * that.denom) - (that.number * this.denom)
  override def toString : String = number.toString() + "/" + denom.toString()
}


val half = new Rational(1, 2)
val third = new Rational(1 ,3)

// after extending the trait, you basically get the relational operation for free.
half < third
half > third



// Trait are stackable
// the traits in scala are stackable, meaning that you can plug on Trait on top of another 
// and there is an internal mechanism inside the Scala runtime/compile to take care of 
//their relationship 

abstract class IntQueue { 
  def get() : Int
  def put(x : Int)
}


// let's write a implemenation class 
import scala.collection.mutable.ArrayBuffer

class BasicIntQueue extends IntQueue {
  private val buf = new ArrayBuffer[Int]
  def get() = buf.remove(0)
  def put(x :Int) { buf += x}
  
}

// and we want to define more behaviors (trinket) , expressed in Traits
// trait can inherits on another Trait, 
// you will see the difference when they stacked together when 'super' has  
// has different target depending on the order they are stacked

trait Doubling extends IntQueue {
  // AMAZING: you can OVERRIDE the extended trait with
  abstract override  def put(x: Int) { super.put(2 * x) }
}

class MyQueue extends BasicIntQueue with Doubling {}

val queue = new MyQueue 
queue.put(10)
queue.get()

// trait gives you easily to compose a mix-in
val queue = new BasicIntQueue with Doubling
queue.put(10)
queue.get()



// continue on the stackable modification 
trait Incrementing extends IntQueue { 
  abstract override def put(x  : Int)  { super.put(x + 1 )}
  
}

trait Filtering extends IntQueue { 
  abstract override def put(x : Int) { if (x > 0) super.put(x)}
}

val queue = new BasicIntQueue with Incrementing with Filtering
queue.put(10)
queue.get()

val queue = new BasicIntQueue with Filtering with Incrementing
queue.put(-1)
queue.put(0)
queue.put(1)
queue.get();queue.get();


// the order of linearization 
// 
class Animal 
trait Furry extends Animal
trait HasLegs extends Animal
trait FourLegged extends HasLegs
trait Cat extends Animal with Furry with FourLegged

// animal's linearization is as follow: 
//   Animal -> AnyRef -> Any 
// deduction process is as follow. 
//  second to last part is the linearization of the first mixin, trait Furry 
//    Furry -> AnyRef -> Any
// and it should be preceded by the linearilization of FourLegged
//  FourLegged -> HasLeg ->  Furry -> AnyRef -> Any
// and first linearization is the class itself.
//   Cat -> FourLegged -> HasLeg ->  Furry -> AnyRef -> Any



