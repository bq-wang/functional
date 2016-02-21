// working with collections in Scala
//
// description: 
//  this is for working with collections, 
// what will be covered in this source file 
//   
//   Lists
//   Array
//   List Buffers
//   Strings (via StringOps)
//   Set and Maps
//     Default Sets and Maps
//     Sorted Sets and Maps
//   General Multable and immutable Collections.
//   Collection initialization
//   Conversions
//   Tuples


// -- List

val colors = List("red", "blue", "green")
colors.head


// -- Arrays
val fiveInts = new Array[Int](5)

// -- List Buffers
//   like a List builder, which is in the mutable namespace of the scala.collection NS
import scala.collection.mutable.ListBuffer

val buf = new ListBuffer[Int]
buf += 1
buf += 2

3 +=: buf  // add to the front
buf.toList


// -- Array buffers
//   the Array's builder
import scala.collection.mutable.ArrayBuffer
val buf = new ArrayBuffer[Int]()
buf += 12
buf += 15
3 +=: buf
buf.length
buf(0)



// -- Strings (via StringOps)
//   Predef has implicit conversion from String to StringOps, so you can use the 
//   following methods. 
def hasUpperCase(s : String) = s.exists(_.isUpper)
hasUpperCase("Robert Frost")
hasUpperCase("e e cummings")

// -- Sets and maps 
// a NOTE on the Sets and Maps, 
//   by default what you get for "Sets" and "Maps" are immutable ones, 
// which defined in the Predef object
// 
//object Predef { 
//  type Map[A, +B] = collection.immutable.Map[A, B]
//  type Set[A] = collection.immutable.Set[A]
//  val Map = collection.immutable.Map
//  val Set = collection.immutable.Set
//}


// to use the mutable ones, use the following. 
import scala.collection.mutable
val mutaSet = mutable.Set(1, 2, 3)

// -- using Sets
val text = "See SPot run, Run, Spot. Run!"
val wordsArray = text.split("[!,.]+")
val words = mutable.Set.empty[String]
for (word <- wordsArray) 
  words += word.toLowerCase
words


// - using maps
def countWords(text : String) = { 
  val counts = mutable.Map.empty[String, Int]
  for (rawWord <- text.split("[!,.]+")) {
    val word = rawWord.toLowerCase
    val oldCount = 
      if (counts.contains(word)) counts(word)
      else 0
    counts += (word -> (oldCount + 1))
  }
  counts
}

countWords("See SPot run, Run, Spot. Run!")

// - default Set and Maps
//   mutable sets and maps will returns a mutable.HashSet or a mutable.HashSet
// for immutable ones, 
//   1. immutable.EmptySet, 2. immutable.Set1, 3. immutable.Set2, 4. immutable.Set3 or 
//   1. immutable.EmptyMap, 2. immutable.Map1, 3. immutable.Map2, 4. immutable.Map3
// 

// -- Sorted Set and Maps 
//   TreeSet 
//   TreeMap
import scala.collection.immutable.TreeSet
val ts = TreeSet(9, 3, 1, 8, 0, 2, 7, 4, 6, 5)
ts // returns a sorted set 

import scala.collection.immutable.TreeMap
var tm = TreeMap(1 -> 'x', 3 -> 'x', 4 -> 'x')
tm += (2 -> 'x')


// -- immutable vs. mutables
var people = Set("Nancy", "Jane")
people += "Bob"
  
people -= "Jane"
people ++= List("Tom", "Harry")  

// -- Initializing Collections 
List(1, 2, 3)
Set('a', 'b', 'c')
val stuff = mutable.Set[Any](42)
// initialize a collection with anoter colleciton, you may use '++' operator
//val treeSet = TreeSet(colors)
val treeSet = TreeSet[String]() ++ colors

// -- conversion
treeSet.toList
treeSet.toArray

// -- conversion between mutable and immutable
val mutaSet = mutable.Set.empty ++= treeSet
val immutaSet = Set.empty ++ mutaSet


val muta = mutable.Map("i" -> 1, "ii" -> 2)
val immuta = Map.empty ++ muta

// Tuples
def longestWord(words : Array[String]) = {
  var word = words(0)
  var idx = 0
  for (i <- 1 until words.length) { 
    if (words(i).length > word.length)
      word  = words(i)
      idx = i
  }

  (word, idx)
}
val longest = longestWord("The quick brown fox".split(" "))
longest._1
longest._2