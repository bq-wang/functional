// scala_traits.scala 

// description: the scala trait description 

trait Philosophical { 
  def philosophize() { 
    println("I consume memory, therefore I am!")
  }
  
}

class Frog extends Philosophical {
  override def toString = "green"
}



val frog = new Frog

frog.philosophize()