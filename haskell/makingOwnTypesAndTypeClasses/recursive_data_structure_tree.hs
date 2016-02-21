-- file
--   recursive_data_structure_tree.hs
-- description:
--   recursive data structure tree


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


-- checkstreeInsert works 
-- ghci> let nums = [8,6,4,1,7,3,5]  
-- ghci> let numsTree = foldr treeInsert EmptyTree nums  
-- ghci> numsTree  
-- Node 5 (Node 3 (Node 1 EmptyTree EmptyTree) (Node 4 EmptyTree EmptyTree)) (Node 7 (Node 6 EmptyTree EmptyTree) (Node 8 EmptyTree EmptyTree))
-- 


-- check that that the treeElem will works correctly
-- ghci> 8 `treeElem` numsTree  
-- True  
-- ghci> 100 `treeElem` numsTree  
-- False  
-- ghci> 1 `treeElem` numsTree  
-- True  
-- ghci> 10 `treeElem` numsTree  
-- False  
