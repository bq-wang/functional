-- file
--  newtype_laziness.hs
-- description:
--  on newtype laziness
import Control.Applicative
import Control.Monad.Instances

-- This fact means that not only is newtype faster, it's also lazier. Let's take a look at what this means.
--  Haskell can represent the values of types defined with newtype just like the original ones, only it has to keep in mind that the their types are now distinct.

-- 

-- NOTE: undefine meant for undefined
--  which is a  representation of a erroneous computation
-- 

-- import Prelude.undefined
-- ghci> undefined  
-- *** Exception: Prelude.undefined  

--  head [3, 4, 5, undefined, 2, undefined]
-- 3


data CoolBool = CoolBool { getCoolBool :: Bool }


helloMe :: CoolBool -> String  
helloMe (CoolBool _) = "hello" 

-- if you applies that to the helloMe, you will get an error back 
-- 
-- ghci> helloMe undefined  
-- "*** Exception: Prelude.undefined  
-- 

-- it has the exception because undefined will be evaluated and exception been thrown...

newtype CoolBool = CoolBool { getCoolBool :: Bool }  

-- ghci> helloMe undefined  
-- "hello"  

-- REASON?
--    it just has to be aware of the values being of different types. And because Haskell knows that types made with the newtype keyword can only have one constructor, it doesn't have to evaluate the value passed to the function to make sure that it conforms to the (CoolBool _) pattern because newtype types can only have one possible value constructor and one field!

-- DIFFERENCE
--  data can be used to make your own types from scratch
--  newtype is for making a completely new type out of an existing type. 
--    it is more about making a direct conversion from one type to another


-- tyupe VS. newtype vs. data

-- The type keyword is for making type synonyms. e..g
-- type IntList = [Int]
-- ghci> ([1,2,3] :: IntList) ++ ([1,2,3] :: [Int])  
--     [1,2,3,1,2,3]  
-- 
-- 

-- newtype  keyword is for taking existing types and wrapping them in new types
-- e.g.
--  newtype CharList = CharList { getCharList :: [Char] }  

-- data:  The data keyword is for making your own data types and with them, you can go hog wild. 
-- 
