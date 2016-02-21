-- file
--  newtype_keyword.hs
-- description:
--  study the newtype_keyword
import Control.Applicative


-- we have learnt the applicative functrors, and we know that it works like this :
ghci> [(+1),(*100),(*5)] <*> [1,2,3]  
[2,3,4,100,200,300,5,10,15]  

-- and we know that zipList do something like first functor to the first Value, and second functor to the second value
ghci> getZipList $ ZipList [(+1),(*100),(*5)] <*> ZipList [1,2,3]  
[2,200,15] 


-- if you define the zipList, you will do 
data ZipList a = ZipList [a]

-- and you may do that as well

data ZipList a = ZipList { getZipList :: [a] }  


newtype ZipList a = ZipList { getZipList :: [a] }  


-- QUOTE: newtype vs. Data
-- Instead of the data keyword, 
--   the newtype keyword is used. Now why is that? 
-- Well for one, newtype is faster. If you use the data keyword to wrap a type, there's some overhead to all that wrapping and unwrapping when your program is running. But if you use newtype, Haskell knows that you're just using it to wrap an existing type into a new type (hence the name), because you want it to be the same internally but have a different type. With that in mind, Haskell can get rid of the wrapping and unwrapping once it resolves which value is of what type.


-- but why not to use the newtype all the time?
-- QUOTE: like this ?
data Profession = Fighter | Archer | Accountant  
  
data Race = Human | Elf | Orc | Goblin  
  
data PlayerCharacter = PlayerCharacter Race Profession  

-- the reason
-- QUOTE: when you make a new type from an existing type by using the newtype keyword, you can only have one value constructor and that value constructor can only have one field. But with data, you can make data types that have several value constructors and each constructor can have zero or more fields:when you make a new type from an existing type by using the newtype keyword, you can only have one value constructor and that value constructor can only have one field. But with data, you can make data types that have several value constructors and each constructor can have zero or more fields:

-- When using newtype, you're restricted to just one constructor with one field.


-- 
-- define a CharList type with newtype key word
newtype CharList = CharList { getCharList :: [Char] } deriving (Eq, Show)

-- ghci> CharList "this will be shown!"  
-- CharList {getCharList = "this will be shown!"}  
-- ghci> CharList "benny" == CharList "benny"  
-- True  
-- ghci> CharList "benny" == CharList "oisters"  
-- False  

-- the type of CharList 
CharList :: [Char] -> CharList  

-- the type of getCharList

getCharList :: CharList -> [Char]  




