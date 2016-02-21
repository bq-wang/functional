doubleMe x = x + x
doubleUs x y = doubleMe x + doubleMe y
doubleSmallNumber x = if x > 100 then x else x * 2
-- else part is mandatory is Haskell
doubleSmallNumber' x = (if x > 100 then x else x * 2) + 1
--  function cannot begin with uppercase letter
conanO'Brien = "It's a-me, Conan O'Brian!"

-- intro to list
let lostNumbers = [4, 8, 15, 16, 23, 42]

-- list concat
-- [1,2,3,4] ++ [9,10,11,12]
--"hello" ++ "  "+ "world"
--['w', 'o'] ++ ['', 't']

-- putting something at the beginning of one list 
-- 'A' : " SMALL CAT"
-- 5:[1,2,3,4,5]

-- get one element out 
"Steve Buscemi" !! 6 
[9.4,33.2,96.2,11.2,23.25] !! 1 

-- list can be compared if the stuff they contain can be compared.
[3,2,1] > [2, 1, 0]
[3,4,2] == [3,4,2]   

-- takes a list and returns its head 
head [5,4,3,2,1]
-- takes a list and returnsits tail
tail [5,4,3,2,1]
last [5,4,3,2,1]
init [5,4,3,2,1]  

-- exception on empty list
head []


-- check null on a list
null [1, 2, 3]

-- reverse
everse [5,4,3,2,1]

-- take
take 3 [5,4,3,2,1] 

-- drop
drop 3 [8,4,2,1,5,6]

-- maximum 
 maximum [1,9,2,3,4]  

-- mininum 
minimum [8,4,2,1,5,6]

-- sum
sum [5,2,1,6,3,2,5,7]  
-- product
product [6,2,1,2]  

-- elem : tells if a thing is element of the list
4 `elem` [3,4,5,6]
10 `elem` [3,4,5,6]



-- ranges

[1..20
['a'..'z']

-- range with steps 
-- it reads, 2, 4, ... until 20
[2, 4..20]

-- cannot do 
--[20..1]


-- cycle 
-- take finite numbers of elements from a cycled list
take 10 (cycle [1,2,3])
take 12 (cycle "LOL  ")


-- repeat
take 10 (repeat 5)
-- replicate 
replicate 3 10 


-- List comprehension
[x*2 | x <- [1..10]]

-- with condition
[x * 2 | x <- [1..10], x * 2 >= 12]


-- 
[x*2 | x <-[50..100], x `mod` 7 == 3]


-- to a function
boomBangs xs = [ if x < 10 then "BOOM!" else "BANG!" | x <- xs, odd x]   
boomBangs [7..13]

-- chain predicate 
[ x | x <- [10..20], x /= 13, x /= 15, x /= 19]

-- from multiple llsts
[ x*y | x <- [2,5,10], y <- [8,10,11]] 

-- with filter
[ x*y | x <- [2,5,10], y <- [8,10,11], x*y > 50]  

-- length` with wildcards
length' xs = sum [1 | _ <- xs ]

-- list comprehension on list 
removeNonUppercase st = [ c | c <- st, c `elem` ['A'..'Z']]   


-- multiple list comprehension 
let xxs = [[1,3,5,2,3,1,2,4,5],[1,2,3,4,5,6,7,8,9],[1,2,4,2,1,6,3,1,3,2,3,6]] 
[ [ x | x <- xs, even x ] | xs <- xxs]  

-- tuples
--
-- not allowed
-- [(1,2),(8,11,5),(4,5)]

-- fst
fst (8, 11)
fst ("Wow", False)  

-- snd
snd (8, 11)
snd ("Wow", False)

-- zip
zip[1,2,3,4,5] [5,5,5,5,5]

-- zip : loger get cut 
zip [5,3,2,6,2,7,2,5,4,6,6] ["im","a","turtle"]  

-- zip : finite with infinite
zip [1..] ["apple", "orange", "cherry", "mango"] 

-- a mind numbing techiniques

let triangles = [ (a,b,c) | c <- [1..10], b <- [1..10], a <- [1..10] ]  

let rightTriangles = [ (a,b,c) | c <- [1..10], b <- [1..c], a <- [1..b], a^2 + b^2 == c^2]   

let rightTriangles' = [ (a,b,c) | c <- [1..10], b <- [1..c], a <- [1..b], a^2 + b^2 == c^2, a+b+c == 24]  

