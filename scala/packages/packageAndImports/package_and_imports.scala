// package_and_imports.scala

// description: package and imports 


// the Java style package declaration

package bobsrockets.navigation

class Navigator

// the C# style 
package bobsrockets.navigation {
  class Navigator
}


// Scala's style can be extremely flexible 
package bobsrockets {
  package navigation { 
    class Navigator { 
      
    }
    
    package tests {
      class NavigatorSuite
    }
  }
}


//

package bobsrockets { 
  package navigation{ 
    class Color {}
  }
}

package bobsrockets {
  
  package navigation { 
    class Navigator {
      val map = new StarMap 
    }
    class StarMap
  }
  
  class Ship {
    // No need to say bobsrockets.navigatoin.Navigator
    val nav = new navigation.Navigator
  }
  
  package fleets { 
    class Fleet { 
      // no need to say bobsrockets.Ship
      def addShip() { new Ship}
    }
  }
}

// while types in enclosing scope not automatically visible

package bobsrockets {
  class Ship
}

package bobsrockets.fleets {
  class Fleet { 
    // Doesn't compile ! Ship is not in scope
    def addShip( new Ship)
  }
}
