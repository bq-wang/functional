

package bobsdelights

abstract class Fruit (val name : String, val color : String)

object Fruits { 
  object Apple extends Fruit("Apple", "red")
  object Pear extends Fruit("Pear", "yellowish")
  object Orange extends Fruit("Orange", "orange")
  val menu = List(Apple, Pear, Orange)
}
