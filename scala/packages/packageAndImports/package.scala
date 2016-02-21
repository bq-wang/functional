// package.scala 
// replicate the content of the scala_pacakge_object.scala

//
package object bobsdelights {
  import bobsdelights.Fruit
  def showFruit(fruit : Fruit) { 
    import fruit._
    println(name + "s are" + color)
  }
  
}

