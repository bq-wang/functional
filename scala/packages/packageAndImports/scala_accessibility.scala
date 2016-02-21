// scala_accessbility.scala

// private members

class Outer {
  class Inner {  
    private def f()  { println("f")} 
    
    class InnerTest {
      
      f(); // OK 
    }
  }
  
  (new Inner).f() // f is not accesible. 
}

// protected members
 
package P { 
  class Super {
    protected def f() { println("f")}
    
  }
  
  class Sub extends Super { 
    f()
  }
  
  class Other {  
    (new Super).f() // f is not accessible 
  }
}


// public members

package bobsrockets 
package navigation {  
  // an earlier example of scope of protection
  private[bobsrockets] class Navigator { 
    protected[navigation] def useStarChart() { 
      
    }
    
    class LegOfJourney { 
      private [Navigator] var distance = 100
    }
    // private[this] , only this object can access the 
    private[this] var speed = 200
  }
  
}
package launch {
  import navigation._
  object Vehicle { 
    private[launch] val guide  = new Navigator
  }
  
}

// scope of protection
//   e.g.  on  LegOfJourney.distance 
//
// no access modifier                             public acceess
//    private[bobsrockets]                           access wihtin outer package
//    private[navigation]                            same as package visibility in Java
//    private[Navigator]                             same as private in java
//    private[LegOfJourney]                          same as private in scala
//   private[this]                                  access only from the same object
//
// there is also 
//   protected[X]
// which means both the extended classes and also within the enclosing scope package, class, or object X

// Companion object
class Rocket {  
  import Rocket.fuel
  // access the companion object
  private def CanGoHomeAgain = fuel > 20 
}


object Rocket {
  private def fuel = 10
  def chooseStrategy(rocket : Rocket ) {
    // access the companion class 
    if (rocket.CanGoHomeAgain)
      goHome()
    else 
      pickAStar()
  }
  def goHome() {}
  def pickAStar() {}
}