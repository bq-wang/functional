-- :t command to display the type of a operands
:t 'a'

:t "HELLO!"

:t 4 == 5

:t (True, 'a')



-- rewrite the removeNonUppercase with type declaration
removeNonUppercase :: [Char] -> [Char]
removeNonUppercase st = [c | c <- st, c `elem` ['A'..'Z']]


-- type of a function that takes serveral parameters

addThree :: Int -> Int -> Int -> Int
addThree x y z = x + y + z

-- do this on the ghci command line 
-- let addThree :: Int -> Int -> Int -> Int; addThree x y z = x + y + z


-- Integer stands for really big integer, while Int has bound, 7 is Int, but 7.2 is not Int
-- below show that you can define a factorial that takes in 
-- integer and returns integer, rather than Int returns Int

factorial :: Integer -> Integer

factorial n = product [1..n]

factorial 50

-- type variables

:t head

-- it produce [a] -> a
-- in haskell, type are in capitcal cases, so a is not a type, instead it is 
-- type variable
--
-- much like generic types in other language.
-- 
-- functions that has type variables are called polymorphic functions. 
:t fst 



-- Typeclasses 101 
-- a typeclass is a sort of interface that defines some behavior, 

:t (==)    
-- produce 
--  (==) :: Eq a => a -> a -> Bool

--  If a type is a part of a typeclass, that means that it supports and implements the behavior the typeclass describes.


-- how is the before output read?
-- the equality function takes any two values that are of the same type and returns a Bool. The type of those two values must be a member of the Eq class (this was the class constraint).


-- read : http://learnyouahaskell.com/types-and-typeclasses
--  for details


-- import typeclasses
-- Eq

-- Ord

:t (>)

"Abrakadabra" < "Zebra"

-- function compare takes two Ord and return an ordering 
--  ordering is a type that can be GT, LT or EQ..

"Abrakadabra" `compare` "Zebra"  

5 >= 2

5 `compare` 3


-- Show typeclass and show function
show 3
show 5.334
show True

-- Read typeclass is opposite of Show, takes a string and returns a type which is a member of Read

:t read
-- it will produce
--   read :: (Read a) => String -> a

-- this will fail
-- read "5"
-- because ghci do not know what type you want read function to produce

-- but  you can use explicit
--  type annotation
read "5" :: Int
read "5" :: Float
read "[1,2,3,4]" :: [Int]
read "(3, 'a')" :: (Int, Char)


-- Enum 
--  members are sequentially ordered types . they can be enumerated. The main advantage of the Enum typeclass is that we can use its types in list ranges. 
['a' .. 'e']
[LT .. GT]
succ 'B'


-- Bounded 

minBound :: Int
maxBound :: Char

maxBound :: Bool
minBound :: Bool

:t minBound
-- produce 
--     minBound :: Bounded a => a



-- Num
--   Its members have the property of being able to act like numbers, let's examine the type of a number
:t 20
-- it produce 
--   20 :: Num a => a

-- type 
--    Int
--    Float
--    Integer
--    Double
--
-- are all types that are in the Num typeclass
:t (*)

-- produces 
--   (*) :: Num a => a -> a -> a    

-- Integral
-- include only integral (whole) numbers.

-- Floating 
-- inlcude only floating numbers, so Float and Double

-- author's opinion 
:t length
-- length :: [a] -> Int
-- the author believes that it should be 
--   (Num b) => length :: [a] -> b

fromIntegral (length([1,2,3,4]) + 3.2


