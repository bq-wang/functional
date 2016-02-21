import java.math.BigInteger;

object Main {
  
  def hello() = { 
    println("Hello world")
  }
  // Use of Java from Scala
  def factorial(x : BigInteger) : BigInteger = 
    if (x == BigInteger.ZERO)
      BigInteger.ONE
    else
      x.multiply(factorial(x.subtract(BigInteger.ONE)))  
      
  def collectionOperation_Exist(name : String) : Boolean =  {
      val nameHasUpperCase = name.exists(_.isUpper)
      nameHasUpperCase
    }
}