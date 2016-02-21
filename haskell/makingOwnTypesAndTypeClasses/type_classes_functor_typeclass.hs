-- file 
--   type_classes_functor_class.hs
-- description:
--   defien a Functor type classes

-- QUOTE 
--  But now, the f is not a concrete type (a type that a value can hold, like Int, Bool or Maybe String), but a type constructor that takes one type parameter.
--  we see that fmap takes a function from one type to another and a functor applied with one type and returns a functor applied with another type.
-- 

import Prelude hiding (Functor, fmap, mapM, Left, Right, Either)

class Functor f where 
   fmap :: (a -> b) -> f a -> f b 


instance Functor [] where 
  fmap = map 

-- that's is!
--   instance Functor [a] where
-- notice how we didn't wirte instance Functor [a] where
--  because from fmap :: (a -> b) -> f a -> f b, we see that the f has to be a type constructor that takes one type. [a] is already a concrete type (of a list with any type inside it), while [] is a type constructor that takes one type and can produce types such as [Int], [String] or even [[String]].


-- Since for lists, fmap is just map, we get the same resutls when using htem on lists. 
-- map :: (a -> b) -> [a] -> [b]  
-- ghci> fmap (*2) [1..3]  
-- [2,4,6]  
-- ghci> map (*2) [1..3]  
-- [2,4,6] 


instance Functor Maybe where  
    fmap f (Just x) = Just (f x)  
    fmap f Nothing = Nothing  

-- and we can write the following . 
-- ghci> fmap (++ " HEY GUYS IM INSIDE THE JUST") (Just "Something serious.")  
-- Just "Something serious. HEY GUYS IM INSIDE THE JUST"  
-- ghci> fmap (++ " HEY GUYS IM INSIDE THE JUST") Nothing  
-- Nothing  
-- ghci> fmap (*2) (Just 200)  
-- Just 400  
-- ghci> fmap (*2) Nothing  
-- Nothing  

-- a Functor which is our Tree a
--  it can be thought of as a box in a way 
-- (holds several or no values) 
-- and the "Tree" type constructor takes exactly one type parameter
data Tree a = EmptyTree | Node a (Tree a) (Tree a) deriving (Show, Read, Eq)

singleton :: a -> Tree a
singleton x = Node x EmptyTree EmptyTree

treeInsert :: (Ord a) => a -> Tree a -> Tree a
treeInsert x EmptyTree = singleton x
treeInsert x (Node a left right)
    | x == a = Node x left right
    | x < a  = Node a (treeInsert x left) right
    | x > a  = Node a left (treeInsert x right)


treeElem :: (Ord a) => a -> Tree a -> Bool
treeElem x EmptyTree = False
treeElem x (Node a left right)
    | x == a = True
    | x < a  = treeElem x left
    | x > a  = treeElem x right




instance Functor Tree where  
    fmap f EmptyTree = EmptyTree  
    fmap f (Node x leftsub rightsub) = Node (f x) (fmap f leftsub) (fmap f rightsub) 

-- 
-- ghci> fmap (*2) EmptyTree  
-- EmptyTree  
-- ghci> fmap (*4) (foldr treeInsert EmptyTree [5,7,3,2,1,7])  
-- Node 28 (Node 4 EmptyTree (Node 8 EmptyTree (Node 12 EmptyTree (Node 20 EmptyTree EmptyTree)))) EmptyTree  

data Either a b = Left a | Right b deriving (Eq, Ord, Read, Show)

-- Well, if we wanted to map one function over both of them, a and b would have to be the same type.
-- 
instance Functor (Either a) where  
    fmap f (Right x) = Right (f x)  
    fmap f (Left x) = Left x  

