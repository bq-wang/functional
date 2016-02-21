// curring.scala 
//

// desription:
//  currying in scala allows you to create new control abstraction
// that " I feel like native language support"


// currying is a functional programming technique 

// let's see how curry, in additonal to other Scala language feature can help you shape your custom control abstration

def plainOldSum(x : Int, y : Int) = x + y



plainOldSum(3, 5)



def curriedSum(x : Int )(y : Int) = x + y

curriedSum(3)(5)

// with the curried function, that you actually get two function invocation back to  back.
// rameter named x, and returns a function value for the second function
def first(x: Int) = (y : Int) => x + y

val second = first(1)

// now you can invoke the second function, by passing a value to parameter named y
second(3)


// to support you to create partially applied curried function, 
// scala has the following syntax (place holder notation), which gives you a reference to the "second"
// function
//

val onePlus = curriedSum(1)_

onePlus(2)

val twoPlus = curriedSum(2)_

twoPlus(2)

// now we have the curried function for our disposal, let's see how we can use that to write new controls.

// the simplest way is to use function as parameter.
def twice(op: Double => Double,  x : Double) = op(op(x))
twice(_ + 1 , 5)

// but we can take a step further by the scala special support of interchaning of 
// {} versus ()
// .e.g we have a function that take a function of PrintWriter to Uint calls as such 


// a side note, this is so called load-pattern
def withPrintWriter(file : java.io.File, op  : java.io.PrintWriter => Unit) = {
  val writer = new java.io.PrintWriter(file)
  try {
    op(writer)
  } finally {
    writer.close()
  }
  
}

withPrintWriter(new java.io.File("data.txt"), writer => writer.println(new java.util.Date))

// and we know because of the () versus {} thing, we can write  as follow, (note: you can only do this if there is 
// only one parameter will be invovled)
println("Hello world")
println { "Hello world"}


// though we said that we cannot do the () to {} things if there are more than one parameter in the parameter list
// but we have currying functions.

// now the new withPrintWriter

def withPrintWirter2(file : java.io.File) (op : java.io.PrintWriter) = {
    val writer = new java.io.PrintWriter(file)
  try {
    op(writer)
  } finally {
    writer.close()
  }
}

// now let's call it
val file = new  java.io.File("data.txt")

withPrintWirter2(file) {
  writer => writer.println(new java.util.Date)
}


// there is all good, so far, but still the content inside the
// block
//   writer => writer.println(new java.util.Date)
//
// still does not feel like a control steps
//
// scala provided a by-name arguments

// below is an by-name parameter use case
var assertionsEnabled = true
def  myAssert(predicate : () => Boolean)  = 
  if (assertionsEnabled && !predicate()) 
    throw new AssertionError

// to call it
 myAssert(() => 5 > 3)

// however,  what you want to is as follow, which does not work 
myAssert(5 > 3)


// to give a by-name parameter, you give the parameter a type starting with => instead of 
// ()=>


def byNamedMyAssertion(predicate : => Boolean) = 
  if (assertionsEnabled && !predicate)
    throw new AssertionError

byNameMyAssertion(5 > 3) 

// note: a by-name parameter ,in which the empty parametet list, (), is left out, is only allowed for 
// parameters.   there is no such a thing such as a by-name variable or a by-name field. 

// you may starting wondering, why do we need the by-name parameter, because we can just pass in a boolean and hope that 
// can work as well.

def boolAssert(predicate : Boolean) = 
  if (assertionsEnabled && !predicate) 
    throw new AssertionError

 // you can do the same such as this
  boolAssert(5 > 3)

// the difference here is the time of evaluation.
// boolAssert - which takes a boolean parameter evaluate before going into the boolAssert()
// while the by-name one is like a inline expansion 
// given our discussion here, if assertionsEnabled is false, then if you pass x /0 
// to the byNamedMyAssertion(...) it won't fail, otherwise, the assertion might failed.
//


// so the final version of the withPrintWriter is as follow
// CAVEAT: actually it is not the best example on the by-named parameter 
def withPrintWriter_newControl(file: java.io.File)(op : => Unit)= {
  val writer = new java.io.PrintWriter(file)
  try {
    op // by named parameter do not take parameter??
  } finally {
    writer.close()
  }
}

val file2 = new java.io.File("data.txt")

withPrintWriter_newControl(file2) {
  val writer = new java.io.PrintWriter(file2)
  writer.println(new java.util.Date)
  writer.close()
}
    