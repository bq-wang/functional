--
-- + moduels.hs
--  module is way to organize the program, haskell also has concept of module


--
-- + Prelude
-- Having code split up into several modules has quite a lot of advantages. If a module is generic enough, the functions it exports can be used in a multitude of different programs. 
-- which is  by default
import Data.List

numUniques :: (Eq a)=> [a] -> Int
numUniques = length . nub 

-- import from the ghci 
--  :m 
-- command
-- import and the output
-- :m + Data.List
-- *Main> :m + Data.List
-- *Main Data.List> :m + Data.List Data.Map Data.Set
-- *Main Data.List Data.Map Data.Set>

-- 
-- + Import selectivly
-- import Data.List (nub, sort)

--
-- + Import with hiding

-- import Data.List hiding (nub)

--
-- + qualified imports.

-- why we need the qualified imports ?
-- The Data.Map module, which offers a data structure for looking up values by key, exports a bunch of functions with the same name as Prelude functions, like filter or null. So when we import Data.Map and then call filter, Haskell won't know which function to use. Here's how we solve this:

-- import qualified Data.Map

--
-- + qualified import with renaming

-- import qualified Data.Map as M

-- NOTE on the qualified import with renaming
--   you will use M.filter to refer to the Data.Map.filter

--
-- + A side note on the available libraries
-- http://www.haskell.org/ghc/docs/latest/html/libraries/


--
-- + Data.List

-- QUOTE:  The Data.List module is all about lists, obviously.
--         You don't have to import Data.List via a qualified import because it doesn't clash with any Prelude names except for those that Prelude already steals from Data.List. 

--
-- + intersperse

intersperse '.' "MONKEY"

intercalate " " ["hey","there","guys"]

intercalate [0,0,0] [[1,2,3],[4,5,6],[7,8,9]]  

--
-- + transpose
transpose [[1, 2, 3], [4, 5, 6], [7, 8, 9]]
transpose ["hey","there","guys"]

-- e.g. try to add together 3*x^2 + 5x + 9 and 10*x^3 + 5 * x^2 + x - 1
map sum $ transpose [[0,3,5,9],[10,0,0,9],[8,5,1,-1]] 


-- foldl' and foldl1'
--  QUOTE:  stricter versions of their respective lazy incarnation
--   the accumulator value isn't actually updated as the folding happens. What actually happens is that the accumulator kind of makes a promise that it will compute its value when asked to actually produce the result (also called a thunk). 
--  the accumulator value isn't actually updated as the folding happens. What actually happens is that the accumulator kind of makes a promise that it will compute its value when asked to actually produce the result (also called a thunk). 

-- concat
concat ["foo", "bar", "car"]
concat [[3, 4, 5], [2,3,4],[2,1,1]]

-- concatMap
concatMap (replicate 4) [1..3]  

-- and
and $ map (>4) [5,6,7,8]
and $ map (==4) [4,4,4,3,4] 

-- or
or $ map (==4) [2,3,4,5,6,1]  
or $ map (>4) [1,2,3] 

-- any 
-- all
any (==4) [2,3,5,6,1,4]  
all (>4) [6,9,10]  
all (`elem` ['A'..'Z']) "HEYGUYSwhatsup"
any (`elem` ['A'..'Z']) "HEYGUYSwhatsup"  

-- iterate
--   applies the function to the starting value, then it applies that function to the result, then it applies the function to that result again
take 10 $ iterate (*2) 1 -- 


-- splitAt
splitAt 3 "heyman"
splitAt 100 "heyman"  
splitAt (-3) "heyman" 
let (a,b) = splitAt 3 "foobar" in b ++ a 


-- takeWhile
takeWhile (>3) [6,5,4,3,2,1,2,3,4,5,4,3,2,1]
takeWhile (/=' ') "This is a sentence"
-- :t (/=)
-- (/=) :: Eq a => a -> a -> Bool


-- span
let (fw, rest) = span (/=' ') "This is a sentence" in "First word:" ++ fw ++ ", the rest:" ++ rest 
break (==4) [1,2,3,4,5,6,7]  

span (/=4) [1,2,3,4,5,6,7]  

-- sort
sort [8,5,3,2,1,6,4,2] 

sort "This will be sorted soon"

-- group
group [1,1,1,1,2,2,2,2,3,3,2,2,2,5,6,7]

-- the following is read as follow 
--   for a argument l, that matches (x : xs) , yield return (x, length l)
map (\l@(xs : xs) -> (x, length l)) . group . sort $ group [1,1,1,1,2,2,2,2,3,3,2,2,2,5,6,7] 

-- inits, and tails
inits "w00t" 
tails "w00t"

-- e.g. find a needle from a haystack
search :: (Eq a) => [a] -> [a] -> Bool
search needle haystack = 
   let nlen = length needle
   in foldl (\acc x -> if take nlen x == needle then True else acc) False (tails haystack)


-- isInfixOf

"cat" `isInfixOf` "im a cat burglar"
"Cat" `isInfixOf` "im a cat burglar"
"cats" `isInfixOf` "im a cat burglar" 

-- isPrefixOf, isSuffixOf
"hey" `isPrefixOf` "hey there!"
"hey" `isPrefixOf` "oh hey there!"
"there!" `isSuffixOf` "oh hey there!"
"there!" `isSuffixOf` "oh hey there"


-- elem and notElem

-- partition 
partition (`elem` ['A'..'Z']) "BOBsidneyMORGANeddy" 
partition (>3) [1,3,5,6,3,2,1,0,3,7]
-- tell the difference from the `span` and `break` ...


-- find
-- find the first
find (>4) [1,2,3,4,5,6] -- Just 5

find (>9) [1,2,3,4,5,6] -- Nothing  
-- :t find 
-- find :: (a -> Bool) -> [a] -> Maybe a -- what is the so called Maybe?

-- why find?
-- head (dropWhile (\(val,y,m,d) -> val < 1000) stock) -- may err, not safe, (think of Why?)
-- find (\(val,y,m,d) -> val > 1000) stock is safer

-- elemIndex 
-- elem or Nothing

-- :t elemIndex
-- elemIndex :: (Eq a) => a -> [a] -> Maybe Int

4 `elemIndex` [1,2,3,4,5,6] 
10 `elemIndex` [1,2,3,4,5,6]  

-- elemIndices 
' ' `elemIndices` "Where are the spaces?" 

-- findIndex
findIndex (==4) [5,3,2,1,6,4] 
findIndex (==7) [5,3,2,1,6,4]  
findIndices (`elem` ['A'..'Z']) "Where Are The Caps?"

-- zip3, zip4, zipWith3, zipWith4, variant goes up to7
zipWith3 (\x y z -> x + y + z) [1,2,3] [4,5,2,2] [2,2,3]  
zip4 [2,3,3] [2,2,2] [5,5,3] [2,2,2]


-- lines
lines "first line\nsecond line\nthird line" 

-- unlines 
--  reverse of lines
unlines ["first line", "second line", "third line"]

-- words and unwords
words "hey these are the words in this sentence"  
words "hey these           are    the words in this\nsentence" 
unwords  ["hey","there","mate"]  


-- nub
nub [1,2,3,4,3,2,1,2,3,4,3,2,1]

nub "Lots of words and stuff"

-- delete
--  delete the first occurance of something.
delete 'h' "hey there ghang!" 
delete 'h' . delete 'h' $ "hey there ghang!"

-- \\
--    is the list difference function
-- NOTE: the operator '\\' is not found!
[1..10] \\ [2, 5, 9]
"Im a big baby" \\ "big"

-- intersect
--   elements from both list
[1..7] `intersect` [5..10]


-- insert 
--   takes an element and a list of elements that can be sorted and inserts it into the last position where it's still less than or equal to the next element.
insert 4 [3,5,1,2,8,2]
insert 4 [1,3,4,4,1]  

-- genericLength, genericTake, genericDrop, genericSplitAt, genericIndex, genericReplicate
--  why this methods? length, take, and others takes Int as one of their parameters
--   e.g.  length :: [a] -> Int
--  then 
--    let xs = [1 .. 6] in sum xs / lenth xs 
-- get type error, because Int is not usable in (/) operator
--   genericLength :: (Num a) => [b] -> a 
-- because Num can act as a floating point number, getting average is fine 
let xs = [1..6] in sum xs / genericLength xs 


-- nub, delete, union, intersect, and group
-- has variant of 
-- nubBy, deleteBy, unionBy, intersectBy, and groupBy

let values = [-4.3, -2.4, -1.2, 0.4, 2.3, 5.9, 10.5, 29.1, 5.3, -2.4, -14.5, 2.9, 2.3] 
groupBy (\x y -> (x > 0) == (y > 0)) values

-- on 
-- the on methods
-- do the import as such 
--   import Data.Functoin (on)
-- on :: (b -> b -> c) -> (a -> b) -> a -> b -> c -- (b -> b -> c) : f, (a -> b) : g
-- f `on` g = \x y -> f (g x) (g y)

-- rewrite with the `on` operator

groupBy ((==) `on` (> 0)) values


--  sortBy, insertBy, maximumBy and minimumBy take a function that determine if one element is greater, smaller or equal to the other.

let xs = [[5,4,5,4,4],[1,2,3],[3,5,4,3],[],[2],[2,2]]
sortBy (compare `on` length) xs


-- Data.Char
-- the Data.Char module does what its name suggests.
-- deal with Chars
--  isUpper
--  isAlpha
--  isAlphaNum
--  isPrint
--  isDigit
--  isOctDigit
--  isHexDigit
--  isLetter
--  isMark
--  isNumber
--  isPunctuation
--  isSymbol
--  isSeparator
--  isAscii
--  isLatin1
--  isAsciiUpper 
--  isAsciiLower
--  
import Data.Char (isUpper, isAlpha, isAlphaNum, isPrint, isDigit, isOctDigit, isHexDigit, isLetter, isMark, isNumber, isPunctuation, isSymbol, isSeparator, isAscii, isLatin1, isAsciiUpper, isAsciiLower)

all isAlphanum "bobby283"  
all isAlphaNum "eddy the fish!" 

groupBy ((==) `on` isSpace) "hey guys its me"
filter (not . any isSpace) . groupBy ((==) `on` isSpace) $ "hey guys its me" 
-- generalCategory :: Char -> GeneralCategory

generalCategory ' '
generalCategory 'A'  
generalCategory 'a'
generalCategory '.'  
generalCategory '9'  
map generalCategory " \t\nA9?|"

-- 
-- toUpper
-- toLower
-- toTitle
-- digitToInt
map digitToInt "34538"
map digitToInt "FF85AB"

intToDigit 15  


-- ord and chr 
-- convert characters and their numbers and vice versa
ord 'a'
chr 97


-- encode
--  deal with encode
encode :: Int -> String -> String
encode shift msg = 
  let ords = map ord msg
      shifted = map (+shift) ords
  in map chr shifted


-- decode
--   reverse of the encode method 
decode :: Int -> String -> String
decode shift msg = encdoe (negate shift) msg


-- 
-- + Data.Map
phoneBook = 
  [("betty","555-2938")  
    ,("bonnie","452-2928")  
    ,("patsy","493-2928")  
    ,("lucille","205-2928")  
    ,("wendy","939-8282")  
    ,("penny","853-2492")  
    ]  

-- findKey

-- this version may throw erorr, guess when it return a Nothing
findKey :: (Eq k) => k -> [(k, v)] -> v
findKey key xs = snd . head . filter (\(k, v) -> key == k) $ xs

-- findKey 
-- with the Maybe data type
--  what is maybe?
findKey :: (Eq k) => k -> ([k, v)] -> Maybe v
findKey key [] = Nothing
findKey key ((k, v) : xs) = if key == k 
		              then Just v -- Just something, what is Just ?? which turns something into a Maybe type?
		              else findKey key xs


-- findKey with foldr
findKey :: (Eq k) => k -> [(k, v)] -> Maybe v  
findKey key = foldr (\(k,v) acc -> if key == k then Just v else acc) Nothing


findKey "penny" phoneBook
findKey "betty" phoneBook
findKey "wilma" phoneBook



-- associative List, which we called Data.Map
import qualified Data.Map as Map

-- 
Map.fromList [("betty","555-2938"),("bonnie","452-2928"),("lucille","205-2928")]

Map.fromList [(1,2),(3,4),(3,2),(5,5)]  
-- how it is implemented

-- map.fromList :: (Ord k) => [(k, v)] -> Map.Map k v


-- an empty list
Map.empty


-- insert
Map.empty 
Map.insert 3 100 Map.empty
Map.insert 5 600 (Map.insert 4 200 ( Map.insert 3 100  Map.empty))
Map.insert 5 600 . Map.insert 4 200 . Map.insert 3 100 $ Map.empty

-- Map.null

Map.null Map.empty
Map.null $ Map.fromList [(2, 3), (5, 5)]

-- Map.size
Map.size Map.empty
Map.size $ Map.fromList[(2,4),(3,3),(4,2),(5,4),(6,4)]

-- Map.singleton
Map.singleton 3 9 
Map.insert 5 9 $ Map.singleton 3 9

-- lookup
--   ...

-- member

Map.member 3 $ Map .fromList [(3,6),(4,3),(6,9)]

Map.member 3 $ $ Map.fromList [(2,5),(4,5)]  

-- map and filter

Map.map (*100) $ Map.fromList [(1,1),(2,4),(3,9)]
Map.filter isUpper $ Map.fromList [(1,'a'),(2,'A'),(3,'b'),(4,'B')]  

-- toList
--   inverse of the fromList
Map.toList . Map.insert 9 2 $ Map.singleton 4 3  

-- keys and elems
--  map fst . Map.toList
--  map snd . Map.toList

-- fromListWith
-- fromList with predicate
phoneBookToMap :: (Ord k) => [(k, String)] -> Map.Map k String
phoneBookToMap xs = Map.fromListWith (\number1 number2 -> number1 ++ "," ++ number2) xs

-- Map.lookup "patsy" $ phoneBookToMap phoneBook
phoneBookToMap :: (Ord k) => [(k, a)] -> Map.Map k [a]
phoneBookMap xs = Map.fromListWith (++) $ map (\(k, v) -> (k, [v]) xs

-- Map.lookup "patsy" $ phoneBookToMap phoneBook 


-- Map.insertWith 
--  insertWith is to insert what fromListWith is to fromList.

Map.insertWith (+) 3 100 $ Map.fromList [(3, 4), (5, 103), (6, 339)]

-- Data.Set

import qualified Data.Set as Set
-- The Data.Set module offers us, well, sets. Like sets from mathematics. Sets are kind of like a cross between lists and maps
text1 = "I just had an anime dream. Anime... Reality... Are they so different?"  
text2 = "The old man left his garbage can out and now his trash is all over my lawn!"  

let set1 = Set.fromList text1
let set2 = Set.fromList text2

putStrLn set1
putstrLn set2


-- null, size, member, empty ,singleton, insert, delete
Set.null Set.empty
Set.null $ Set.fromList [3,4,5,5,4,3]
Set.size $ Set.fromList [3,4,5,3,4,5]  
Set.singleton 9  
Set.insert 4 $ Set.fromList [9,3,8,1] 
Set.insert 8 $ Set.fromList [5..10]  
Set.delete 4 $ Set.fromList [3,4,5,4,3,4,5]  
-- check for subSet
--  the 'Set.isSubsetOf`

Set.fromList [2,3,4] `Set.isSubsetOf` Set.fromList [1,2,3,4,5]  
Set.fromList [1,2,3,4,5] `Set.isSubsetOf` Set.fromList [1,2,3,4,5] 
Set.fromList [1,2,3,4,5] `Set.isProperSubsetOf` Set.fromList [1,2,3,4,5]
Set.fromList [2,3,4,8] `Set.isSubsetOf` Set.fromList [1,2,3,4,5] 

-- map over sets and filter them
Set.filter odd $ Set.fromList [3,4,5,6,7,2,3,4]
Set.map (+1) $ Set.fromList [3,4,5,6,7,2,3,4]  

-- e..g setNub
let setNub xs = Set.toList $ Set.fromList xs

setNub "HEY WHATS CRACKALACKIN" -- order not preserved
nub  "HEY WHATS CRACKALACKIN"   -- order is preserved


-- Making your own module
--  let you to code up into several files and Haskell is no difference
-- we will starts by looking ohter files, Geometry.hs

