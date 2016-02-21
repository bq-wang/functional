-- file
--  type_classes_yesno_typeclasses.hs
-- description:
--  type classes exaple : an yesno type classes

class YesNo a where 
  yesno :: a -> Bool


data Tree a = EmptyTree | Node a (Tree a) (Tree a) deriving (Show, Read, Eq)

data TrafficLight = Red | Yellow | Green

instance YesNo Int where  
    yesno 0 = False  
    yesno _ = True 

instance YesNo [a] where  
    yesno [] = False  
    yesno _ = True

instance YesNo Bool where  
    yesno = id    

-- NOTE::
--   Joe's Note
-- We didn't need a class constraint because we made no assumptions about the contents of the Maybe
-- however, I can think of one , where you don't want  a Maybe a,
-- but the a is yet another Maybe, and the value is Nothing...
instance YesNo (Maybe a) where  
    yesno (Just _) = True  
    yesno Nothing = False  

instance YesNo (Tree a) where 
    yesno EmptyTree = False
    yesno _ = True


instance YesNo TrafficLight where  
    yesno Red = False  
    yesno _ = True  


-- ghci> yesno $ length []  
-- False  
-- ghci> yesno "haha"  
-- True  
-- ghci> yesno ""  
-- False  
-- ghci> yesno $ Just 0  
-- True  
-- ghci> yesno True  
-- True  
-- ghci> yesno EmptyTree  
-- False  
-- ghci> yesno []  
-- False  
-- ghci> yesno [0,0,0]  
-- True  
-- ghci> :t yesno  
-- yesno :: (YesNo a) => a -> Bool  


yesnoIf :: (YesNo y) => y -> a -> a -> a
yesnoIf yesnoVal yesResult noResult = if yesno yesnoVal then yesResult else noResult


-- ghci> yesnoIf [] "YEAH!" "NO!"  
-- "NO!"  
-- ghci> yesnoIf [2,3,4] "YEAH!" "NO!"  
-- "YEAH!"  
-- ghci> yesnoIf True "YEAH!" "NO!"  
-- "YEAH!"  
-- ghci> yesnoIf (Just 500) "YEAH!" "NO!"  
-- "YEAH!"  
-- ghci> yesnoIf Nothing "YEAH!" "NO!"  
-- "NO!"  



