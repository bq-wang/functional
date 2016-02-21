// in this script, we will discuss the topic of file processing
//


import scala.io.Source

// a note on the types, all types are Camel cased by convention. 
//
def widthOfLength(s : String) : Int =  {
    s.length().toString().length
}




//if (args.length > 0)
//  for (line <- Source.fromFile(args(0)).getLines())
//    println(line.length +  "  " + line)
//else 
//  Console.err.println("Please enter filename")
 
// and there is some changes to the requirement, now we will ask the pretty print the lines

if (args.length > 0) {

    println("you should be able to see here")
    // think of why?
    //   toList
    // not of 
    // toList()
    // this is yet another functinoal style of Scala, where you can omit elements (parenthesis) without cause
    // ambiguity, then you can omit 
    //
    // and in this case, you have to omit the () because 
    // there is an overload of the toList call which accept a length parameter. 
    //
    //val lines = Source.fromFile(args(0)).getLines().toList
    //  you can check this link: http://docs.scala-lang.org/style/method-invocation.html 
    // for the special syntax that has been enabled for arity-0 and arity-1 suffix notation 
    
    // or given the special support from the Scala language syntax, you can do this: 
    // 
    val lines =  Source.fromFile(args(0)).getLines() toList
    
    //this is the procedural style of retrieving the maxWidth of the lines. 
    //var maxWidth = 0
    //for (line <- lines)
    //  maxWidth = maxWidth.max(widthOfLength(line))
    
    // and get the maxLengthWidth in the functional style way 
    // as you may find out, there is a '=>' lambda expression  
    // as with C#, it is notation to start a lambda literal
    val longestLine = lines.reduceLeft((a, b) => if (a.length > b.length) a else b )
    val maxWidth = widthOfLength(longestLine)
    
    // reduceLeft call has already done one pass on the List 
    //lines.rewind()
    // you can 
    for (line <- lines) {
      val numOfSpaces = maxWidth - widthOfLength(line)
      val padding = " " * numOfSpaces
      println(padding + line.length + " | " + line)
    } 
   
    println("Can you see here")      
} else 
  Console.err.println("Please enter name")

  
  