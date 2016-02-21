-- file
--  applicative_with_functor_param.hs
-- description:
--  Another instance of Applicative is (->) r, so functions


instance Application ((->) r ) where 
  pure x = (\_ -> x)
  f <*> g = \x -> f x (g x)

-- ghci> (pure 3) "blah"  
-- 3  

-- and because of Currying.function application is left-associative. 
-- pure 3 "blah"

-- the folowing result is expected from the 

--
--ghci> :t (+) <$> (+3) <*> (*100)  
--(+) <$> (+3) <*> (*100) :: (Num a) => a -> a  
--ghci> (+) <$> (+3) <*> (*100) $ 5  
--508  


-- even more examples 
-- ghci> (\x y z -> [x,y,z]) <$> (+3) <*> (*2) <*> (/2) $ 5  
-- [8.0,10.0,2.5]  

-- yet another instance of ApplicativeInstance is like this: 

-- instance Applicative ZipList where 
--    pure x = ZipList (repeat x)
--    ZipList fs <*> ZipList xs = ZipList (zipWith (\f x -> f x) fs xs):w


-- getZipList

-- ghci> getZipList $ (+) <$> ZipList [1,2,3] <*> ZipList [100,100,100]  
-- [101,102,103]  
-- ghci> getZipList $ (+) <$> ZipList [1,2,3] <*> ZipList [100,100..]  
-- [101,102,103]  
-- ghci> getZipList $ max <$> ZipList [1,2,3,4,5,3] <*> ZipList [5,3,1,2]  
-- [5,3,3,4]  
-- ghci> getZipList $ (,,) <$> ZipList "dog" <*> ZipList "cat" <*> ZipList "rat"  
-- [('d','c','r'),('o','a','a'),('g','t','t')]


-- QUOTE;
-- The (,,) function is the same as \x y z -> (x,y,z). Also, the (,) function is the same as \x y -> (x,y).

-- yet another Control.Applicatio function is called liftA2
--     liftA2 :: (Applicative f) => (a -> b -> c) -> f a -> f b -> f c
liftA2 :: (Applicative f) => (a -> b -> c) -> f a -> f b ->f c
liftA2 f a b = f <$> a <*> b


-- QUOTE:
--   , we can say that liftA2 takes a normal binary function and promotes it to a function that operates on two functors.

-- Let's try implementing a function that takes a list of applicatives and returns an applicative that has a list as its result value. We'll call it sequenceA.

sequenceA :: (Applicative f) => [f a] -> f [a]  
sequenceA [] = pure []  
sequenceA (x:xs) = (:) <$> x <*> sequenceA xs  


-- run this with teh following data
-- ghci> sequenceA [Just 3, Just 2, Just 1]  
-- Just [3,2,1]  
-- ghci> sequenceA [Just 3, Nothing, Just 1]  
-- Nothing  
-- ghci> sequenceA [(+3),(+2),(+1)] 3  
-- [6,5,4]  
-- ghci> sequenceA [[1,2,3],[4,5,6]]  
-- [[1,4],[1,5],[1,6],[2,4],[2,5],[2,6],[3,4],[3,5],[3,6]]  
-- ghci> sequenceA [[1,2,3],[4,5,6],[3,4,4],[]]  
-- []  
-- 


-- code used to wrok like this :
ghci> map (\f -> f 7) [(>4),(<10),odd]  
[True,True,True]  
ghci> and $ map (\f -> f 7) [(>4),(<10),odd]  
True  

-- now works like this: 
ghci> sequenceA [(>4),(<10),odd] 7  
[True,True,True]  
ghci> and $ sequenceA [(>4),(<10),odd] 7  
True  

-- QUOTE: When used with [], sequenceA takes a list of lists and returns a list of lists
--- ghci> sequenceA [[1,2,3],[4,5,6]]  
--- [[1,4],[1,5],[1,6],[2,4],[2,5],[2,6],[3,4],[3,5],[3,6]]  
--- ghci> [[x,y] | x <- [1,2,3], y <- [4,5,6]]  
--- [[1,4],[1,5],[1,6],[2,4],[2,5],[2,6],[3,4],[3,5],[3,6]]  
--- ghci> sequenceA [[1,2],[3,4]]  
--- [[1,3],[1,4],[2,3],[2,4]]  
--- ghci> [[x,y] | x <- [1,2], y <- [3,4]]  
--- [[1,3],[1,4],[2,3],[2,4]]  
--- ghci> sequenceA [[1,2],[3,4],[5,6]]  
--- [[1,3,5],[1,3,6],[1,4,5],[1,4,6],[2,3,5],[2,3,6],[2,4,5],[2,4,6]]  
--- ghci> [[x,y,z] | x <- [1,2], y <- [3,4], z <- [5,6]]  
--- [[1,3,5],[1,3,6],[1,4,5],[1,4,6],[2,3,5],[2,3,6],[2,4,5],[2,4,6]] 

-- think of why and how it works?

-- SequnceA with the IO action 
-- ghci> sequenceA [getLine, getLine, getLine]  
-- heyh  
-- ho  
-- woo  
-- ["heyh","ho","woo"]



-- the following as a coronay will hold if the law of  functors holds

--- pure f <*> x = fmap f x
--- 
--- pure id <*> v = v
--- pure (.) <*> u <*> v <*> w = u <*> (v <*> w)
--- pure f <*> pure x = pure (f x)
--- u <*> pure y = pure ($ y) <*> u


