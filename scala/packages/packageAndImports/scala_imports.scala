
package bobsdelights 

abstract class Fruit (
  val name: String,
  val color: String
)

object Fruit { 
  object Apple extends Fruit("Apple", "red")
  object Orange extends Fruit("Orange", "orange")
  object Pear extends Fruit("Pear", "yellowish")
  val menu  = List (Apple, Orange, Pear)
}