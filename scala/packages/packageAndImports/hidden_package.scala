// hidden_package.scala


// pacakge is only for the compiled code 
package launch { 
  class Booster3
}

package bobsrockets {
  package navigation { 
    package launch { 
      class Booster2
    }
  }
  class MissionControl { 
    val booster1 = new launch.Booster1
    val booster2 = new bobsrockets.navigation.launch.Booster2
    val booster3 = new _root_.launch.Booster3
  }
  
  
  package launch { 
    class Booster1
  }
}

