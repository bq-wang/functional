--file 
-- type_synonyms.hs
-- description:
--  type synonyms 102, where we will examine more on the Type classes


-- below is how the Eq type class is implemented in Prelude

-- check on this page on the information about
--  "Haskell - Redefining (hiding) arithmetic operators"
-- http://stackoverflow.com/questions/2388604/haskell-redefining-hiding-arithmetic-operators
import Prelude hiding (Eq, ShowS, (==), (/=))




class Eq a where 
   (==) :: a -> a -> Bool
   (/=) :: a -> a -> Bool
   x == y = not (x /= y)
   x /= y = not (x == y)

data TrafficLight = Red | Yellow | Green


-- unlike the used case where we will define some classes where 
--   deriving from some types 
-- but we 
--   define an instance of the Eq typeclasses
instance Eq TrafficLight where  
    Red == Red = True  
    Green == Green = True  
    Yellow == Yellow = True  
    _ == _ = False


-- actually we only need to fullfill the minimalist of the Eq classes like this:
-- class Eq a where  
--     (==) :: a -> a -> Bool  
--     (/=) :: a -> a -> Bool  


-- and you can also define the instance of Show typeclasses 
-- like this: 


instance Show TrafficLight where 
  show Red = "Red Light" 
  show Yellow = "Yellow light"
  show Green = "Green light"


-- ghci> Red == Red  
-- True  
-- ghci> Red == Yellow  
-- False  
-- ghci> Red `elem` [Red, Yellow, Green]  
-- True  
-- ghci> [Red, Yellow, Green]  
-- [Red light,Yellow light,Green light]  




-- makes types that are sub-types of others. 
--
-- class (Eq a ) => Num a where
--    ... 

-- it is like a writing of "class Num a where"o
-- only we state that our type a must be an instance of Eq
-- we are essentially saying that we have to make a type an instance of Eq before we can make it an instance of Num



-- in the code above, the a has to be a concrete type but Maybe  is not a concrete type, 
-- suppose that you are writing an instance of Eq on Maybe m
-- here is how you might have written it 
-- instance Eq (Maybe m) where
--    Just x == Just y = x == y 
--    Nothing == Nothing = True
--    _ == _ = False 


-- see the problems within?
-- you can compare the Maybe types, but you have no assurance that what the Maybe contains can be used with Eq!. 
-- that is why we have to modify our instance declaration like this :
instance (Eq m) => Eq (Maybe m) where 
    Just x == Just y = x == y  
    Nothing == Nothing = True  
    _ == _ = False 

-- we are saying 
-- QUOTE: we want all types of the form Maybe m to be part of the Eq typeclass, but only those types where the m (so what's contained inside the Maybe) is also a part of Eq. 


-- When making instances, if you see that a type is used as a concrete type in the type declarations (like the a in a -> a -> Bool)

-- NOTE:
-- you can 
-- info YourTypeClass
-- :info Maybe
