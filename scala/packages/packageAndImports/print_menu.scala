// print_menu.scala

// package object is 
// where you can put common definition to package itself.
// by putting the definition to the package object.
package printmenu 
import bobsdelights.Fruits
import bobsdelights.showFruit

// you need to run 
//  scala printmenu.PrintMenu
object PrintMenu {
  def main(args : Array[String]) {
    for (fruit <- Fruits.menu) {
      showFruit(fruit)
    }
  }  
}
