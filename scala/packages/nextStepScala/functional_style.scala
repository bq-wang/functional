// transference from procedural style to functional style
def printArgs(args: Array[String]) : Unit =  {
  var i = 0
  while (i < args.length) 
    println(args(i)) // do not use args[i]: .. 
  i += 1
}
  
// step 1 : functional for ..  
def printArgs2(args : Array[String]) :Unit = {
    for (arg <- args) 
      println(arg)
}
  
  
// step 2: Functional (monad) - a method to apply one method to another method  (or in another meaning , combinig methods)??
def printArgs3(args : Array[String]) :Unit =  {
    args.foreach(println)
}

// step 3 : remove side -effect
// println is not purely functiona, because it has side-effect. thet telltale sign is the return type "Unit"
// to strive for better functional style, you 
def formatArgs4(args: Array[String])  = args.mkString("\n")

// and you can separate the functional part from those non-functional part which has side-affect
println(formatArgs4(args)) 

// the good side about the funtion style is the testability , where you can 
// check the data that is returned by check the datat in/out. 
val res = formatArgs4(Array("zero", "one", "two"))
assert(res, "zero\none\ntwo")