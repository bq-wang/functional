-- recursions.hs
--  we take a close look at the recursion 

maximum' :: (Ord a) => [a] -> a
maximum' [] = error "maximum of empty list"
maximum' [x] = x
maximum' (x : xs) 
   | x > maxTail = x
   | otherwise  = maxTail 
   where maxTail = maximum' xs

-- a few more recursive functions 

-- a side note is that , guard will allow you to write condition, while 
-- pattern match do not allow condition 
replicate' :: (Num i, Ord i) => i -> a -> [a] -- i should be both a Num and a Ord 
replicate' n x 
  | n <= 0 = []
  | otherwise = x : replicate' (n - 1) x 


-- it does not mean that you cannot mix 
--  guard and pattern matching!
take' :: (Num i, Ord i) => i -> [a] -> [a]
take' n _ 
  | n <= 0 = [] -- without the otherwise, the guard will fall through to pattern match
take' _ [] = []
take' n (x :xs) = x : take' (n - 1) xs



-- reverse

reverse' :: [a] -> [a]
reverse' [] = []
reverse' (x : xs) = reverse' xs ++ [x]

-- infinite list?
--  repeat'
repeat' :: a -> [a]
repeat' x = x : repeat' x


-- zip'
-- take two lists and zips them together. zip [1,2,3] [2,3]

zip' :: [a] -> [b] -> [(a, b)]
zip' _ [] = []
zip' [] _ = []
zip' (x : xs) (y : ys) = (x, y): zip' xs ys

-- elem'
-- tell if an element exists on a list
elem' :: (Eq a) => a -> [a] -> Bool
elem' a [] = False
elem' a (x:xs)
  | a == x = True
  | otherwise = a `elem'` xs


-- quicksort
-- an quick sort implemnentation with recursion

quicksort :: (Ord a) => [a] -> [a]
quicksort [] = []
quicksort (x :xs) =
  let smallerSorted = quicksort [a | a <- xs, a <= x]
      biggerSorted = quicksort [a | a <- xs, a > x]
  in smallerSorted ++ [x] ++ biggerSorted

-- here is guideline on the quick sort, which we called is the quick sort mentality 
--   We did quite a bit of recursion so far and as you've probably noticed, there's a pattern here. Usually you define an edge case and then you define a function that does something between some element and the function applied to the rest. It doesn't matter if it's a list, a tree or any other data structure. A sum is the first element of a list plus the sum of the rest of the list. A product of a list is the first element of the list times the product of the rest of the list. The length of a list is one plus the length of the tail of the list. Ekcetera, ekcetera ...
