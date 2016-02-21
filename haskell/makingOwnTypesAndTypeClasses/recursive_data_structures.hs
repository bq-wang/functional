-- file
--   recursive_data_structure.hs
-- description:
--  recursive data structure 

-- we can create recursive data types, where one value of some type contains values of that type, which in turn contain more values of the same type and so on.

import Prelude hiding (List)
-- data List a = Empty | Cons a (List a) deriving (Show, Read, Eq, Ord)  
-- in record type 
-- 
-- data List a = Empty | Cons { listHead :: a, listTail :: List a} deriving (Show, Read, Eq, Ord)  



-- ghci> Empty  
-- Empty  
-- ghci> 5 `Cons` Empty  
-- Cons 5 Empty  
-- ghci> 4 `Cons` (5 `Cons` Empty)  
-- Cons 4 (Cons 5 Empty)  
-- ghci> 3 `Cons` (4 `Cons` (5 `Cons` Empty))  
-- Cons 3 (Cons 4 (Cons 5 Empty)) 

-- we can define functions to be automatically infix by making them comprised of only special characters. 
-- First off, we notice a new syntactic construct, the fixity declarations. When we define functions as operators, we can use that to give them a fixity (but we don't have to). A fixity states how tightly the operator binds and whether it's left-associative or right-associative. For instance, *'s fixity is infixl 7 * and +'s fixity is infixl 6. 

infixr 5 :-:
data List a = Empty | a :-: (List a) deriving (Show, Read, Eq, Ord)  

-- ghci> 3 :-: 4 :-: 5 :-: Empty  
-- (:-:) 3 ((:-:) 4 ((:-:) 5 Empty))  
-- ghci> let a = 3 :-: 4 :-: 5 :-: Empty  
-- ghci> 100 :-: a  
-- (:-:) 100 ((:-:) 3 ((:-:) 4 ((:-:) 5 Empty)))  


-- since we know that we can define operator, let's define a ++ operator

-- ++ is defined for normal lists
--infixr 5  ++ 
--(++) :: [a] -> [a] -> [a]  
--[]     ++ ys = ys  
--(x:xs) ++ ys = x : (xs ++ ys)


-- .++ is what we define for ourselves
infixr 5  .++  
(.++) :: List a -> List a -> List a   
Empty .++ ys = ys  
(x :-: xs) .++ ys = x :-: (xs .++ ys) 

-- ghci> let a = 3 :-: 4 :-: 5 :-: Empty  
-- ghci> let b = 6 :-: 7 :-: Empty  
-- ghci> a .++ b  
-- (:-:) 3 ((:-:) 4 ((:-:) 5 ((:-:) 6 ((:-:) 7 Empty))))  


--: Binary Search Tree
--
data Tree a = EmptryTree | Node a (Tree a) (Tree a) deriving (Show, Read, Eq)


singleton :: a -> Tree a  
singleton x = Node x EmptyTree EmptyTree  
  
treeInsert :: (Ord a) => a -> Tree a -> Tree a  
treeInsert x EmptyTree = singleton x  
treeInsert x (Node a left right)   
    | x == a = Node x left right  
    | x < a  = Node a (treeInsert x left) right  
    | x > a  = Node a left (treeInsert x right)  


