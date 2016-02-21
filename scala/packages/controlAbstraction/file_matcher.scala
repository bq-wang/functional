//  file_matcher.scala
//
// based on some file matcher strategy and files that matches to a certain criteria


import scala.io.Source

object FileMatcher { 
  
  private def filesHere = new java.io.File(".").listFiles
  
  private def fileMatching(matcher : String => Boolean) = { 
    for (file <- filesHere; if matcher(file.getName))
      yield file
  }
  
  
  def filesEnding(query: String) = 
    fileMatching(_.endsWith(query))
  
   def filesContaining(query: String) = 
    fileMatching(_.contains(query))
    
   def filesRegex(query: String) = 
    fileMatching(_.matches(query))
}

// but let's see how itr evolvs
// imperative style 

object FileMatcher1 { 
  
  private def filesHere = new java.io.File(".").listFiles
  
  def filesEnding(query: String) = {
    for (file <- filesHere ; if file.getName.endsWith(query)) yield file
  }
  
  def filesContains(query: String) = {
    for (file <- filesHere ; if file.getName.contains(query)) yield file
  }
  
  
  def fileRegex(query: String) = {
    for (file <- filesHere ; if file.getName.matches(query)) yield file
  }
    
}

// now let 'e move it to be more general 

// let 's introduce the lambada expression 
// step 1.  the lambda expression do not use closure. 
//  every parameter is passed via parameter 

object FileMatcher2 { 
  
  private def filesHere = new java.io.File(".").listFiles
  
  private def fileMatching(query: String,  matcher : (String, String) => Boolean) = {
    for (file <- filesHere ; if matcher(file.getName, query))  yield file
  }
  
  def filesEnding(query: String) = fileMatching(query, (fileName : String, queryString : String) => fileName.endsWith(queryString))
  
  def filesContains(query: String) = fileMatching(query, (fileName: String, queryString : String)  => fileName.contains(queryString))
  
  def fileRegex(query: String) = fileMatching(query, (fileName: String, queryString: String) => fileName.matches(queryString))
  
}


// however, that Scala has the same shorthands as the C# language has. 
// but Scala has done even a step further in that it 
//  1. suppport wildcard, so if you have _.endsWith(_), the first _ stands for the first argument, while the second _ stands for the second argument
//  2. suppport type inference, so that in _.endswith(_), and given the context of the fileMatching method which expect the second function type to be
//     (String, String) => Boolean, then it can figures out the firt '_' type is String, and the second '_' 's type is String too, and also the return type is "Boolean"
//
// with all this in-mind, so you can take a step further, by reducing the amount of code that you can type .

object FileMatcher3 {
  
  private def filesHere = new java.io.File(".").listFiles
  
  
  private def fileMatching(query: String,  matcher : (String, String) => Boolean) = {
    for (file <- filesHere ; if matcher(file.getName, query))  yield file
  }
  
  def filesEnding(query : String) = fileMatching(query, _.endsWith(_))
  
  def filesContains(query: String) = fileMatching(query, _.contains(_))
  
  def fileRegex(query: String) = fileMatching(query,  _.matches(_))
}

// now, if you take a closer look matcher usge in the FileMatcher3.fileMatching method
//   if matcher(file.Name, query)
// and each of the call to the FileMatching e.g. 
//   filesEnding(query : String) = fileMatching(query, _.endsWith(_))
// while you know that 
// query : String -> (query, _.endWith(_))
// matcher : (String, String) => Boolean -> matcher(file.getName, query)
// 
//   ==> 
// 
// query -> matcher(({query}), file.getName) # the ({query}) means that you can pass in a bound closure variable in
// 


object FileMatcher4  {
  
  private def  filesHere = new java.io.File(".").listFiles
  
  private def fileMatching(matcher : (String) => Boolean) =  {
    for (file <- filesHere ; if matcher(file.getName))
      yield file
  }
  
  def filesEnding(query : String) = fileMatching((fileName : String) => fileName.endsWith(query))

  def filesContains(query :String) = fileMatching((fileName : String) => fileName.contains(query))
  
  def filesRegex(query : String) = fileMatching((fileName:  String) => fileName.matches(query))
}


// now, we can apply the same 
// type inference && wildcard trqansformation,
// here is the result  of the transformation
object FileMatcher5  {
  
  private def  filesHere = new java.io.File(".").listFiles
  
  private def fileMatching(matcher : (String) => Boolean) =  {
    for (file <- filesHere ; if matcher(file.getName))
      yield file
  }
  
  def filesEnding(query : String) = fileMatching(_.endsWith(query))

  def filesContains(query :String) = fileMatching(_.contains(query))
  
  def filesRegex(query : String) = fileMatching(_.matches(query))
}


