// stairwaybook_elements.scala

// description:
//   a show case on the composition and inheritance

package org.stairwaybook.layout

object Element { 
  
  private class ArrayElement(val contents: Array[String]) extends Element 

  
  private class LineElement(
      s : String) extends Element {
          def contents : Array[String] = Array(s)
          override def height : Int = 1
          override def width : Int = s.length
    }
  
  private class UniformElement(
      chr : Char,
      override val width : Int,
      override val height :Int
      ) extends Element {
    
    // ch * width will fail, 
    // and the error message is not clear - type mismatch (expect String, Int provided) the REPL need to improve 
    // on it error handling.
    private val line : String = chr.toString * width
    override def contents : Array[String] = Array.fill(height)(line)
  }
  
  
  def elem(contents: Array[String]) : Element = new ArrayElement(contents)
  
  def elem(s : String) : Element  = new LineElement(s)
  
  def elem(chr : Char, width : Int, height : Int) : Element= new UniformElement(chr, width, height)
  
}


import Element.elem

// contents: not defined, you need to declare your class as "abstract" 
//  
abstract class Element { 
  def contents : Array[String]
  def height : Int = contents.length
  def width = if (contents.length ==0 ) 0 else contents(0).length
  
  
  def beside(that : Element) : Element = {
    val this1 = this heighten that.height
    val that1 = that heighten this.height
    
    elem (
      for ((line1, line2) <- this1.contents zip that1.contents) yield (line1 + line2)    
    )
    
  }
  
  
  def above(that : Element) : Element = {
    val this1 = this widen that.width
    val that1 = that widen this.width
    
    elem(this1.contents ++ that1.contents)
    
  }
  
  def widen(w : Int) : Element = 
    if (w <= width) this
    else {
      val left = elem(' ', (w - width) /2 , height)
      val right = elem(' ', (w - width  + left.width), height)
      
      left beside this beside right
    }
  
  def heighten(h : Int) : Element = 
    if (h <= height) this 
    else {
      val top = elem(' ', width, (h - height) / 2)
      val bottom = elem(' ', width, (h - height + top.height))
      
      top above this above bottom
    }
    
  
  override def toString = contents mkString "\n"
    
}