// case_sequence_as_partial_functions.scala

// define a withDefault function , (a lambda, if you prefer that way)
// the lambda's type is Option[int] => Int
// and the body of the lambda is pattern w/o the match keyword

val withDefault : Option[Int] => Int =  {
  
  case Some(x) => x
  case None => 0
}


withDefault(Some(10))
withDefault(None)

// why ?


// e.g. the reactor code
//  the code below shows an example reactive code, which is not exhausted. 

react  {
  
  case (name : String, actor : Actor) => { 
    actor ! getip(name)
    act()
  }
  case msg => { 
    println("Unhandled message : " + msg)
    act()
  }
}


// partial function  
//  - a sequence of cases give you a partial function
// e.g. 
val second : List[Int] => Int = { 
  case x :: y :: _ => y // there would be compile warning 
  
}
second(List(4,5,6))

second(List()) // this will throw error 

// - partial function's type PartialFunction.. 

val second : PartialFunction[List[Int], Int] = { 
  case x :: y :: _ => y // there would be compile warning 
}


second.isDefinedAt(List(4,5,6)) // true
second.isDefinedAt(List()) // false

// - partial function internal
//   the translation happened twice
// for 
//   { case x :: y :: _ => y  }
// once for the function itself
// once for the test of valued defined
new PartialFunction[List[Int], Int] {
  def apply(xs : List[Int]) = xs match {
    case x :: y :: _ => y  
  }
  
  def isDefinedAt (xs : List[Int]) = xs match { 
    case x :: y :: _ => true 
    case _ => false
  }
}


