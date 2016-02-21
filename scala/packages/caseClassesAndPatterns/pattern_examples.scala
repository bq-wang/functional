// pattern_examples.scala
//

// description:
//  will demonstrate the use of the pattern matching.


package org.stairwaybook.expr
import org.stairwaybook.layout.Element.elem // the element library 
import org.stairwaybook.layout.Element

sealed abstract class Expr
case class Number(val n : Double) extends Expr
case class Var(val name : String) extends Expr
case class UnOp(val op : String, arg : Expr) extends Expr
case class BinOp(val op : String, left : Expr, right : Expr) extends Expr

class ExprFormatter {
  // contains operator sin groups of  increasing precedance
  private val opGroups = Array(
    Set("|", "||"),    
    Set("&", "&&"),
    Set("^"),
    Set("==", "!="),
    Set("<", "<=", ">", ">="),
    Set("+", "-"),
    Set("*", "%")
  )
  
  // A mapping from operators to their precedance
  private val precedence = {
    val assocs =  // create the maps from the association to map
      for {
        i <- 0 until opGroups.length
        op <- opGroups(i)
      } yield (op -> i)
      
      assocs.toMap
  }
  
  private val unaryPrecedence = opGroups.length
  private val fractionPrecedence = -1

  
  private def format(e : Expr, enclPrec : Int) : Element = 
    e match { 
    case Var(name) => elem(name)
    case Number(num) => 
      def stripDot(s : String) =
        if (s endsWith ".0") s.substring(0, s.length - 2)
        else s
      elem(stripDot(num.toString))
    case UnOp(op, arg) => 
      elem(op) beside format(arg, unaryPrecedence)
    case BinOp("/", left, right) => 
      val top = format(left, fractionPrecedence)
      val bot = format(right, fractionPrecedence)
      val line = elem('-', top.width max bot.width, 1)
      val frac = top above line above bot
      if (enclPrec != fractionPrecedence) frac
      else elem(" ") beside frac beside elem(" ")
    case BinOp(op, left, right) =>
      val opPrec = precedence(op)
      val l = format(left, opPrec)
      val r = format(right, opPrec + 1)
      val oper = l beside elem(" " + op + " " ) beside r
      if (enclPrec <= opPrec) oper
      else 
        elem("(") beside oper beside elem(")")
  }
  
  // overload method need the return type
  def format(e : Expr)  :Element = format(e, 0)
}

