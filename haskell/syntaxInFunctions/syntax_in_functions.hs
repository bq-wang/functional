-- author
--   boqwang
-- refernces
--  http://learnyouahaskell.com/syntax-in-functions


-- pattern matching
--  syntac constructs and starts with the pattern matching.

lucky :: (Integral a) => a -> String
lucky 7 = "LUCKY NUMBER SEVEN!"  
lucky x = "Sorry, you're out of luck, pal!"


sayMe :: (Integral a) => a -> String
sayMe 1 = "One!"  
sayMe 2 = "Two!"  
sayMe 3 = "Three!"  
sayMe 4 = "Four!"  
sayMe 5 = "Five!"  
sayMe x = "Not between 1 and 5" 



-- and we will define factorial again
-- however, this time not with number n as produce [1 .. n]
--  NOTE:
--    you would not write the second factorial pattern first
--    because doing that will probablly catch all cases, including 0 
factorial :: (Integral a ) => a -> a
factorial 0 = 1
factorial n = n * factorial (n - 1)


-- non-exhaustive patterns

charName :: Char -> String
charName 'a' = "Albert"
charName 'b' = "Broseph"  
charName 'c' = "Cecil" 

-- and if you call
--  charName 'h'
-- you will get an 
--   "*** Exception: tut.hs:(53,0)-(55,21): Non-exhaustive patterns in function charName 

-- patterns on tuples

-- first a non-pattern matching definition
-- addVectors :: (Num a) => (a, a) -> (a, a) -> (a, a)					   
-- addVectors a b = (fst a + fst b, snd a + snd b) 


-- then a pattern one    

addVectors :: (Num a) => (a, a) -> (a, a) -> (a, a)
addVectors (x1, y1) (x2, y2) = (x1 + x2, y1 + y2) -- we guarantee to have two pairs as parameters 





-- define fst, snd on triples

first :: (a, b, c) -> a
first (x, _, _) = x

second :: (a, b, c) -> b
second (_, y, _) = y

-- and the "third"
third :: (a, b, c) -> c
third (_, _, z) = z


-- postscript/addendum/epilogue/appendix/postlude

-- _ means we don't care
--   we have seen this "length' xs = sum [1 | _ <- xs ]"
-- it means wildcards in general


-- review the list comprehension
--   we are actually using pattern matching in List comprehension
-- let xs = [(1,3), (4,3), (2,4), (5,3), (5,6), (3,1)] 
-- [a + b | (a, b) <- xs]


-- Lists themselves can be used in pattern matching
--  [1,2,3] is just syntactic sugar to 1:2:3:[]
--  and x:xs will bind head of hte list to x and the rest of it to xs


-- the head function
head' :: [a] -> a
head' [] = error "can't call head on an empty list, dummy!"
head' (x:_) = x

-- test if that works
-- head' [4,5,6]
--  head' "hello"


-- pattern matching a trivial case

tell :: (Show a) => [a] -> String  
tell [] = "The list is empty"  
tell (x:[]) = "The list has one element: " ++ show x  
tell (x:y:[]) = "The list has two elements: " ++ show x ++ " and " ++ show y  
tell (x:y:_) = "This list is long. The first two elements are: " ++ show x ++ " and " ++ show y


-- as we said, the length function provided by the built-in function is lame
-- we will provide our own

-- if you mistake (Num b) => [b] -> a, there would be a " Could not deduce (Num a) from the context (Num b)" error!
length' :: (Num b) => [a] -> b
length' [] = 0 
-- since we don't care much about the variable binding below
-- legnth' (x:xs) = 1 + length' xs
length' (_ :xs) = 1 + length' xs


-- and we can re-implements sum function as well 

sum' :: (Num a) => [a] -> a
sum' [] = 0
sum' (x:xs) = x + sum' xs


-- the things called as "pattern"
capital :: String -> String
capital "" = "Empty string, whoops!"  
capital all@(x:xs) = "The first letter of " ++ all ++ " is " ++ [x]

-- capital "Dracula"


-- what you can not do ?
-- (xs ++ [x, y, z] or (xs ++ [x])

