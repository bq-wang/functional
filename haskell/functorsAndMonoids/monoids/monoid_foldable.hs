-- file
--  monoid_foldable.hs
-- description:
--  the foldable monoids.hs

import qualified Foldable as F


ghci> :t foldr  
foldr :: (a -> b -> b) -> b -> [a] -> b  
ghci> :t F.foldr  
F.foldr :: (F.Foldable t) => (a -> b -> b) -> b -> t a -> b  

ghci> foldr (*) 1 [1,2,3]  
6  
ghci> F.foldr (*) 1 [1,2,3]  
6  

-- an example that shows how it looks like
ghci> foldr (*) 1 [1,2,3]  
6  
ghci> F.foldr (*) 1 [1,2,3]  
6  

-- more examples on the way..
ghci> F.foldl (+) 2 (Just 9)  
11  
ghci> F.foldr (||) False (Just True)  
True  

-- 
-- 
data Tree a = Empty | Node a (Tree a) (Tree a) deriving (Show, Read, Eq)  

-- the foldMap function 's type
--   foldMap :: (Monoid m, Foldable t) => (a -> m) -> t a -> m  


instance F.Foldable Tree where  
    foldMap f Empty = mempty  
    foldMap f (Node x l r) = F.foldMap f l `mappend`  
                             f x           `mappend`  
                             F.foldMap f r  

testTree = Node 5  
            (Node 3  
                (Node 1 Empty Empty)  
                (Node 6 Empty Empty)  
            )  
            (Node 9  
                (Node 8 Empty Empty)  
                (Node 10 Empty Empty)  
            )  

-- ghci> F.foldl (+) 0 testTree  
-- 42  
-- ghci> F.foldl (*) 1 testTree  
-- 64800  


-- remember the getAny in Any method type
newtype Any = Any { getAny :: Bool }  
    deriving (Eq, Ord, Read, Show, Bounded)  

instance Monoid Any where  
        mempty = Any False  
        Any x `mappend` Any y = Any (x || y)  



-- ghci> getAny $ F.foldMap (\x -> Any $ x > 15) testTree  
-- False  
-- 
-- ghci> F.foldMap (\x -> [x]) testTree  
-- [1,3,6,5,8,9,10]  
