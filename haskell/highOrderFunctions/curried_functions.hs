-- curried_functions.hs
--  demonstrate the use of the high-order function and we first start with the curried functions


-- a note from the authro from http://learnyouahaskell.com/higher-order-functions
--   QUOTE:  It turns out that if you want to define computations by defining what stuff is instead of defining steps that change some state and maybe looping them, higher order functions are indispensable. 


-- 
-- :curried functions

-- first by an example.
-- max 4 5
-- (max 4) 5


-- type examination
--   max :: (Ord a) => a -> a -> a   --  
--   max :: (Ord a) => a -> (a -> a) -- a function that takes an a and returns a function that takes an a and returns an a.
-- more examples

multThree :: (Num a) => a -> a -> a -> a
multThree x y z = x * y * z


-- let multTwoWithNine = multThree 9
-- multTwoWithNine 2 3 

-- let multTwoWithEighteen = multThree 9
-- multTwoWithEighteen 10

compareWithHundred :: (Num a, Ord a) => a -> Ordering
compareWithHundred x = compare 100 x


-- and we can re-write this function above with the curried form 
compareWithHundred' :: (Num a, Ord a) => a -> Ordering
compareWithHundred' = compare 100



-- sections
--
-- infix function can also be applied by using sections
-- QUOTE : To section an infix function, simply surround it with parentheses and only supply a parameter on one side. That creates a function that takes one parameter and then applies it to the side that's missing an operand. .

divideByTen :: (Floating a ) => a -> a
divideByTen = (/10) -- the left operand is missing, so if you apply divideByTen 200, then argument '200' will be supplied to the missing left-operand

isUpperAlphanum :: Char -> Bool
isUpperAlphanum = (`elem` ['A'..'Z'])

subtract4 :: (Num a)  => a -> a
subtract4 =  (subtract 4) -- you cannot use (-4), because this means minus 4
-- substract4 10

-- 
-- : Some higher-orderism is in order
applyTwice :: (a -> a) -> a -> a -- two notes: first, '->' operator is right associative, and second, the parenthesis is mandatory, because that means the first argument is an function, and the second argument is of the same type and returns a value of the same type
applyTwice f x = f (f x)
-- applyTwice (+3) 10		   
-- applyTwice (++ " HAHA") "HEY"
-- applyTwice (multThree 2 2) 9
-- applyTwice (3:) [1]

-- impls of the zipWith function
zipWith' :: (a -> b -> c) -> [a] -> [b] -> [c] -- the first argument is an function, which accept two argument of type a and b respectively and returns a value of type 'c', 
zipWith' _ [] _ = []
zipWith' _ _ [] = []
zipWith' f (x:xs) (y:ys) = f x y : zipWith' f xs ys

-- zipWith' (+) [4, 2, 5, 6] [ 2, 6, 2, 3]
-- zipWith' max [6,3,2,1] [7,3,1,5]
-- zipWith' (++) ["foo ", "bar ", "baz "] ["fighters", "hoppers", "aldrin"]  
-- zipWith' (*) (replicate 5 2) [1..] 
-- zipWith' (zipWith' (*)) [[1,2,3],[3,5,6],[2,3,4]] [[3,2,2],[3,4,5],[5,4,3]]  

-- impls of the flip' function, which flip the first two arguments
flip' :: (a -> b -> c) -> (b -> a -> c)
flip' f = g
  where g x y = f y x

--flip' zip [1, 2, 3, 4, 5] "hello"


--
-- :Maps and filters

-- map takes a function and a list and applies that function to every element in the list.   
map' :: (a -> b) -> [a] -> [b]
map' _ [] = []
map' f (x : xs) = f x : map' f xs


-- map (+3) [1, 5, 3, 1, 6]
-- map (++ "!") ["BIFF", "BANG", "POW"]
-- map (replicate 3) [3..6]
-- map (map (^2)) [[1,2],[3,4,5,6],[7,8]]  -- double applied map function to List[List]
-- map fst [(1,2),(3,5),(6,3),(2,6),(2,5)]

-- 
-- :filter
filter' :: (a -> Bool) -> [a] -> [a]
filter' _ [] = []
filter' p (x:xs) 
    | p x = x : filter' p xs
    | otherwise = filter' p xs
-- filter (>3) [1,5,3,2,1,6,4,3,2,1]      
-- filter (==3) [1,2,3,4,5]
-- filter (==3) [1,2,3,4,5]
-- let notNull x = not (null x) in filter notNull [[1,2,3],[],[3,4,5],[2,2],[],[],[]] 
-- filter (`elem` ['a' .. 'z'] "u LaUgH aT mE BeCaUsE I aM diFfeRent"  
-- filter (`elem` ['A'..'Z']) "i lauGh At You BecAuse u r aLL the Same"  	   
-- now let's redefine the quick sort function
quicksort :: (Ord a ) => [a] -> [a]
quicksort [] = []
quicksort (x : xs) = 
  let smallerSorted = quicksort (filter (<=x) xs)
      biggerSorted = quicksort (filter (>x) xs)
  in smallerSorted ++ [x] ++ biggerSorted
-- some performance NOTE: Thanks to Haskell's laziness, even if you map something over a list several times and filter it several times, it will only pass over the list once.  


-- e.g by case :  find the largest number under 10,000 that is divisible by 3829
largestDivisible :: (Integral a) => a
largestDivisible = head (filter p [10000, 9999..])
  where p x = x `mod` 3829 == 0

-- sum of of all odd squares that are smaller than 10,000.
-- sum (takeWhile (<10000) (filter odd (map (^2) [1..])))
-- sum (takeWhile (<10000) [n^2 | n <- [1..], odd (n^2)]) -- it is a matter of taste

-- chain
chain :: (Integral a) => a -> [a]
chain 1 = [1]
chain n 
  | even n = n : chain(n `div` 2)
  | odd n = n : chain(n * 3 + 1)

numLongChains :: Int
numLongChains = length (filter isLong (map chain[1..100]))
  where isLong xs = length xs > 15

-- map to get a list of functions
-- let listOfFuns = map (*) [0..]
-- (listOfFuns !! 4) 5 -- !! is index operator


--
-- : Lambdas
-- lambdas are basically anonymous functions that are used because we need some functions only once.
-- QUOTE: we write a \ (because it kind of looks like the greek letter lambda if you squint hard enough) and then we write the parameters, separated by spaces. After that comes a -> and then the function body. We usually surround them by parentheses, because otherwise they extend all the way to the right. 

numLongChains' :: Int
numLongChains' = length (filter (\xs -> length xs > 15) (map chain [1..100]))

-- guideline of partially applied function vs. lambda expressions
-- use this
-- map (+3) [1, 6, 3, 2]
-- do NOT use this
-- map (\x -> x + 3) [1, 6, 3, 2]
-- e.g. of lambda expression 
-- zipWith (\a b -> (a * 30 + 3) / b) [5,4,3,2,1] [1,2,3,4,5]  

-- careful with pattern matching in lambda, because 
-- ONCE a pattern matching fails in a lambda, a runtime error occurs. 
-- map (\(a, b) -> a + b ) [(1,2),(3,5),(6,3),(2,6),(2,5)] 

-- normally by parenthesis, unless we mean for them to extend all the way to the right.
addThree :: (Num a) => a -> a -> a -> a
addThree x y z = x + y + z

addThree' :: (Num a) => a -> a -> a -> a
addThree' =  \x -> \y -> \z -> x + y + z -- not a perfect style of writing the fun

-- but depends on the times
flip'' :: (a -> b -> c) -> b -> a -> c
flip'' f = \x y -> f y x


-- 
-- : only folds and horses (topics on the foldLeft, foldRight?)
-- fold1, leftFold

sum' :: (Num a) => [a] -> a
sum' xs = foldl (\acc x -> acc + x) 0 xs

-- sum' [3, 5, 2, 1]

-- re-impl of the `elem` operator again, but again with the fold1 funtion
elem' :: (Eq a) => a -> [a] -> Bool
elem' y ys = foldl (\acc x -> if x == y then True else acc) False ys

--
-- :: foldr
-- re-impl of the map' with foldr
map'r :: (a -> b) -> [a] -> [b]
map'r f xs = foldr (\x acc -> f x : acc) [] xs
-- a foldl impls is as follow, however, much more expensive. 
-- map'l :: (Num a) => [a] -> a
-- map'l f xs = foldl (\accx -> acc ++ [f x]) [] xs -- ++ operator is too expensive.

-- a review point of Folds is as follow 
-- QUOTE : Folds can be used to implement any function where you traverse a list once, element by element, and then return something based on that. Whenever you want to traverse a list to return something, chances are you want a fold. 

-- foldl1, and foldr1

maximum'' :: (Ord a) => [a] -> a  
maximum'' = foldr1 (\x acc -> if x > acc then x else acc)  
  
reverse'' :: [a] -> [a]  
reverse'' = foldl (\acc x -> x : acc) []  
  
product'' :: (Num a) => [a] -> a  
product'' = foldr1 (*)  
  
filter'' :: (a -> Bool) -> [a] -> [a]  
filter'' p = foldr (\x acc -> if p x then x : acc else acc) []  
  
head'' :: [a] -> a  
head'' = foldr1 (\x _ -> x)  
  
last'' :: [a] -> a  
last'' = foldl1 (\_ x -> x)  

-- scanl, scanr
-- like foldl, and foldr, but only report all the intermediate accumulator state in the form of a list. 
-- scanl (+) 0 [3, 5, 2, 1]
-- scanr (+) 0 [3, 5, 2, 1]
-- scanl1 (\acc x -> if x acc then x else acc) [3,4,5,3,7,9,2,1]
-- scanl (flip (:)) [] [3,2,1]
-- e.g. How many elements does it take for the sum of the roots of all natural numbers to exceed 1000? 

sqrtSums :: Int
sqrtSums = length (takeWhile (<1000) (scanl1 (+) (map sqrt [1..]))) + 1
-- verify that your code is right

-- sum (map sqrt [1..131])
-- sum (map sqrt [1..130])

-- 
-- : Function application with $
--   QUOTE : 
--     Alright, next up, we'll take a look at the $ function, also called function application. First of all, let's check out how it's defined:

-- the definition of the ($) operator
-- ($) :: (a -> b) -> a -> b
-- f $ x = f x

-- some facts about the '$' operator
--  1. normal function application (putting a space between two things) has a really high precedence, the $ function has the lowest precedence. 
--  2. Function application with a space is left-associative (so f a b c is the same as ((f a) b) c)), function application with $ is right-associative.

-- some e.g.
-- sum (map sqrt [1..130])
-- sum $ map sqrt [1..130]

-- sqrt $ 3 + 4 + 9
-- sqrt (3 + 4 + 9)

-- sum (filter (>10) (map (*2) [2..10]))
-- sum $ filter (>10) $ map (*2) [2..10]    


-- 
-- : Function composition
-- QUOTE: n mathematics, function composition is defined like thisn mathematics, function composition is defined like this : (f . g) (x) = f(g(x))
--  which means that composing two functions produces a new function that 
-- when called with parameter, say x is equivalent of calling g with the parameter x and then calling the f with that result
--
--  the haskell function composition 
--
-- the definition of the 'function composition'
-- (.) :: (b -> c) -> (a -> b) -> a -> c
-- f . g = \x -> f (g x)

-- e.g. of the function composition 
-- k = \x -> negate . (* 3) x
-- k = negate . (* 3) 

-- e.g. of use lambda    
-- map (\x -> negate (abs x)) [5,-3,-6,7,-3,2,-19,24]
-- e.g of use function composition 
-- map (negate . abs) [5,-3,-6,7,-3,2,-19,24] 

-- map (\xs -> negate (sum (tail xs))) [[1..5],[3..6],[1..7]] 
-- map (negate . sum . tail) [[1..5],[3..6],[1..7]]  -- with composition style

-- replicate 100 (product (map (*3) (zipWith max [1,2,3,4,5] [4,5,6,7,8])))
-- replicate 100 . product . map (*3) . zipWith max [1,2,3,4,5] $ [4,5,6,7,8]    
-- because only with 'infix' operator, you can apply 'section' on those
-- infix operator (such as +, -, etc...) but you cannot use 
-- section operator 
-- 
-- map (negate $ sum $ tail)[[1..5],[3..6],[1..7]]

sum'pointer_style :: (Num a) => [a] -> a
sum'pointer_style xs = foldl (+) 0 xs

-- and the point-free styles is written as such 
-- 
sum'pointer_free_style :: (Num a) => [a] -> a
sum'pointer_free_style  = foldl (+) 0

-- the following is as follow. 
--
-- fn x= ceiling (negate (tan (cos (max 50 x))))
-- fn = ceiling . negate . tan . cos . max 50
-- fn = ceiling $ negate $ tan $ cos $ max 50  60
-- fn = ceiling $ negate $ tan $ cos $ max 50 $ 60

-- style of choice
-- which of the following style is more readable
oddSquareSum :: Integer
oddSquareSum = sum (takeWhile (<10000) (filter odd (map (^2) [1..])))

oddSquareSum' :: Integer
oddSquareSum' = sum . takeWhile (<10000) . filter odd . map (^2) $ [1..]

oddSquareSum'' :: Integer
oddSquareSum'' = 
   let oddSquares = filter odd $ map (^ 2) [1..]
       belowLimit = takeWhile (<10000) oddSquares
   in sum belowLimit
