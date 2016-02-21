// working with lists.sclaa
//
// description: 
//  this is for working with lists


// - list literals
val fruit = List("apples", "oranges", "pears")
val nums =  List (1, 2, 3, 4)
val diag3 = 
  List(
    List(1, 0, 0),
    List(0, 1, 0),
    List(0, 0, 1)
  )
val empty = List()


// - list are homogeneous
//

val xs : List[String] = List()

// :: - List constructing . 
val fruit : List[String] = "apples" :: ("oranges" :: ("pears" :: (Nil))) // -- Nil is a speical form of List , stand for the Empty -elementes lists
val nums = 1 :: (2 :: (3 :: (4 :: Nil)))

val empty = Nil // you can create an alias name for the Nil list. 


// head, tail, isEmpty 

Nil.head

// - the above show the following results. 
// java.util.NoSuchElementException: head of empty list

// -- implements the isort algorithms.
def isort(xs : List[Int]) : List[Int] = 
  if (xs.isEmpty) Nil
  else insert(xs.head, isort(xs.tail))

def insert(x :Int, xs : List[Int]) : List[Int] = 
  if (xs.isEmpty || x <= xs.head) x :: xs
  else xs.head :: insert(x, xs.tail)


// -- a fore-introduction to the extractor pattern and the constructor pattern such as a :: b
  
val fruit = List("apples", "oranges", "pears")  
// extractor pattern
val List(a, b, c) = fruits
// the constructor pattern,  x :: xs is treated as ::(x, xs), and indeed there is such an classes called 
//   '::'
// this is a pattern in scala, where 
// there is a '::" class in pacakge scala, and there is a '::' operator inside the list operator
val a :: b :: rest = fruits

// isort with the pattern matching
def isort(xs :List[Int]) : List[Int] = xs match {
    case List() => List() // List() , or the Nil
    case x :: xs1 => insert(x, isort(xs1))
  }

def insert(x : Int, xs : List[Int]) : List[Int] = xs match {
  case List() => List(x) // you can NOT write as follow 
  //case head :: xs1 if x <= head => x :: xs
  //case head :: xs1 if x > head => head :: insert(x, xs.tail)
  case head :: xs1 => if (x <= head) x :: xs 
                       else xs.head :: insert(x, xs1)
  
} 

isort(List(2, 5, 1, 7, 4, 0))


// next we will examine some first order method of the List operation

// ::: takes two list as operands
// -- list concatenation 
List(1,2 )  ::: List(3,4,5)

List() ::: List(1,2,3)

List(1,2,3,4) ::: List(1)


// divide and conquer methods


def append[T](xs : List[T], ys : List[T]) : List[T] = 
  xs match { 
  case List() => ys
  case x :: xs1 => x :: append(xs1, ys
}

// -- length of a list
List(1, 2, 3).length



// acccess the list in the reverse order
// -- init, last
val abcde  = List('a', 'b', 'c', 'd', 'e')

abcde.init
abcde.last


// -- reverse of a list

abcde.reverse

// -- write your own reverse function
def rev[T] (xs : List[T]) : List[T] = xs match { 
  case List() => xs
  case x :: xs1 => rev(xs1) ::: List(x)
}


//-- prefixes and suffixes
// the function that I will cover in this section include the following..

val abcde  = List('a', 'b', 'c', 'd', 'e')

abcde take  2

abcde drop 2
abcde splitAt 2


//-- elements selection
// the commands that will be covered in this section includ e
//   apply and indices
// NOTE:  rare in SCALA
// 
abcde apply 2
// is the same as 
abcde(2)

abcde.indices

// -- flatten of a list
List(List(1, 2), List(3), List(), List(4, 5)).flatten

val fruit = List("apple", "organge", "pear")
fruit.map(_.toCharArray).flatten
// you cannot apply "flatten" on a list whose element is not an list
List(1, 2, 3).flatten

//-- Zipping list, zip and unzip
//   zip
//   zipWithIndex
abcde.indices zip abcde

abcde.zipWithIndex

//-- toString and mkString
//   toString
//   mkString
//   addString (special form of mkString) , a method on the StrinbBuilder class
abcde.toString

abcde mkString ("[", ",", "]")
abcde mkString ("List(", ",", ")")

val buf = new StringBuilder
abcde addString (buf, "(", ",", ")")

//-- converting list
//   iterator
//   toArray
//   copyToArray
val arr = abcde.toArray
arr.toList


//-- copyToArray
val arr2 = new Array[Int](10)
List(1, 2, 3) copyToArray(arr2, 3)


val it = abcde.iterator
it.next
it.next // calling next to yield next result.


// List operator by example
//  MergeSort

def msort[T](less: (T, T) => Boolean) (xs : List[T]) : List[T] = {
  def merge (xs :List[T], ys : List[T]) : List[T] = 
    (xs, ys) match {
    case (Nil, _) => ys
    case (_, Nil) => xs
    case (x :: xs1, y :: ys1) => 
      if (less(x, y)) x :: merge(xs1, ys)
      else y :: merge(xs, ys1)
  }
  
  val n = xs.length / 2
  if (n == 0) xs
  else {
    val (ys, zs) = xs splitAt n
    merge(msort(less)(ys), msort(less)(zs))
  }
}
// call with the following methods
//    msort((x : Int, y : Int) => if (x > y) true else false)( List(1, 5, 2, 3, 4,8,6))
// or 
//  msort((x : Int, y : Int) => x < y)( List(1, 5, 2, 3, 4,8,6))

// -- high order method on List
//   map
//   flatMap
//   foreach
// e.g.
// 
List(1, 2, 3) map (_ + 1)

val words = List("the", "quick", "brown", "fox")
words map(_.length)

// map vs. flatMap
words map(_.toList)
words flatMap(_.toList)

List.range(1, 5) flatMap(i => List.range(1, i) map (j => (i , j)))

var sum = 0
List(1, 2, 3, 4, 5) foreach (sum += _)

sum


// filtering lists
//  filter, partition, find, takeWhile, dropWhile, and span
//  filter
//  partition,
//  find,
//  takeWhile
//  dropWhile,
//  span

List(1, 2, 3, 4, 5) filter (_ % 2 == 0)
words filter (_.length == 3)
List(1, 2,3, 4, 5) partition (_ % 2 == 0) // partition equals (xs filter p, xs filter (!p(_))
List(1, 2,3, 4, 5) find (_ % 2 == 0) // returns an Option, or Some(...)
List(1, 2,3, -4, 5) takeWhile (_ > 0)
words dropWhile (_ startsWith "t")
List(1, 2,3, -4, 5) span (_ > 0) // xs span p equals (xs takeWhile p, xs dropWhile p)

// predicate over lists : forall and exists
def hasZeroRow(m : List[List[Int]]) = 
  m exists (row => row forall (_ == 0))

val diag3 = List[List[Int]](List(1, 2, 3), List(0, 0, 0), List(4, 5, 6))
hasZeroRow(diag3) // you cannot do hasZeroRow diag3, because this will be translated to "hasZero.diag3"

// folding lists: /: and :\
//  /:
//  :\
//  and an e.g.
//   sum(List(a, b, c)) equals 0 + a + b + c
def sum(xs : List[Int]) : Int = (0 /: xs) (_ + _) // check on how the "/:" operator is defined?? 
def product(xs : List[Int]) : Int = (1 /: xs) (_ * _) // looks like that, it has defined some object, or funciton on the primitive
                                                      // type such as "Int, Float"

// e.g.
// def reverseLeft[T](xs : List[T]) = (startvalue /: xs) (operation)
def reverseLeft[T](xs : List[T]) = (List[T]() /: xs) { (ys, y) => y :: ys }

// sorting List
//   sortWith
List(1, -3, 4, 2, 6) sortWith (_ < _)
words sortWith (_.length > _.length)

// -- Method of the List object
//  as We all know that List has a List class and List also has a 
//  List object
// 
List(1, 2, 3) // equivalent to the following.
List.apply(1, 2, 3) // which is a method of the List companion object

// List.Range
List.range(1, 5) // as 1 to 5
List.range(1, 9, 2)
List.range(9, 1, -3)


// List.fill
List.fill(5)('a')
List.fill(2, 3)('b') // and you can have multiple dimension with 'fill' method

// List.Tabulate
val squares = List.tabulate(5)( n => n * n)
val multiplication = List.tabulate(5, 5)(_ * _) // two dimension , i<- 0 to 5, j <- 0 to 5, i * j

//-- Processing multiple list together.
(List(10, 20), List(3, 4, 5)).zipped.map(_ * _) // longer elements are truncated.
(List("abc", "de"), List(3, 2)).zipped forall (_.length == _)
(List("abc", "de"), List(3, 2)).zipped exists(_.length != _)

//-- understanding the type inference system in Scala
// considering the following e.g.
msort((x : Char, y : Char) => x > y ) (abcde)
abcde sortWith(_ > _)

msort(_ > _)(abcde) // <console>:10: error: missing parameter type for expanded function ((x$1, x$2) => x$1.$greater(x$2))
// type system in Scala is flow-based


// however, if we swap the argument of the two, then we will ends up having this.
def msortSwapped[T](xs : List[T])(less: (T, T) => Boolean) : List[T] = {
  def merge (xs :List[T], ys : List[T]) : List[T] = 
    (xs, ys) match {
    case (Nil, _) => ys
    case (_, Nil) => xs
    case (x :: xs1, y :: ys1) => 
      if (less(x, y)) x :: merge(xs1, ys)
      else y :: merge(xs, ys1)
  }
  
  val n = xs.length / 2
  if (n == 0) xs
  else {
    val (ys, zs) = xs splitAt n
    merge(msort(less)(ys), msort(less)(zs))
  }
}

msortSwapped(abcde)(_ > _) // why this works?, this is because, with the msort(abcde), we know it return a partially applied 
                    // function which accepts (T, T) => Boolean and return a type of List[T], and abcde has type 
                    // List[T], with the flow deduction, it can map to the real argument type, which is Char (because
                    // abcde is of type List[Char])


// NOTE: a rule of thumb
//   when designing a polymorphic method that takes some non-function arguments and a function arguments, place the function argument last in a curried 
// parameter by its own


