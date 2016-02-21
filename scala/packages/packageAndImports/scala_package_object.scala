// scala_package_object.scala

// define a package object is
package object bobsdelights {
  import bobsdelights.Fruit
  def showFruit(fruit : Fruit) { 
    import fruit._
    print(name + "s are" + color)
  }
  
}
