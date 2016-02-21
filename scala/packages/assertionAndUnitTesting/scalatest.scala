//scalatest.scala

// description: scala test is the class that test ScalaTest

import org.scalatest.Suite // scalatest is not available

import Element.elem

class ElementSuite extends Suite { 
  def testUniformEleemnt ()  {
    val elem = elem('x', 2, 3)
    assert(elem.width == 2)
  }
}