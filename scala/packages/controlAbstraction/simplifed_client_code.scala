// simplified_client_code.scala

// description
//  in this file we will examine how can we leverage the advanced control abstraction to write less code while accomplish more
// 
// the contrsuct for the control abstraction includes the following 
//  foreach
//  last
//  firt
//  any
//  all
//  exists
//  ...

def containsNeg(nums : List[Int]) = {
  var exist = false
  for (num <- nums) {
    if  (num < 0)
      exist  = true 
  }
  exist
}


// 

def containsOdd(nums: List[Int]) = {
  nums.exists(_ % 2 == 1)
}

containsOdd(List(1,2 ,3, 5))
containsNeg(List(1, 2, -3, 8))