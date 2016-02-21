-- file
--   we can represent the pole with a simple pair of integers
-- description:
--  pierre will walk with pole landed with birds

type Birds = Int  
type Pole = (Birds,Birds)  

--landLeft :: Birds -> Pole -> Pole  
--landLeft n (left,right) = (left + n,right)  
--  
--landRight :: Birds -> Pole -> Pole  
--landRight n (left,right) = (left,right + n)  

-- suppose that our Monad is implemented in such a way 
-- 
-- instance Monad Maybe where  
--     return x = Just x  
--     Nothing >>= f = Nothing  
--     Just x >>= f  = f x  
--     fail _ = Nothing  

-- and now hte rework of the land functions
landLeft :: Birds -> Pole -> Maybe Pole  
landLeft n (left,right)  
    | abs ((left + n) - right) < 4 = Just (left + n, right)  
    | otherwise                    = Nothing  
  
landRight :: Birds -> Pole -> Maybe Pole  
landRight n (left,right)  
    | abs (left - (right + n)) < 4 = Just (left, right + n)  
    | otherwise                    = Nothing  

-- test with the following 
-- return (0,0) >>= landLeft 1 >>= landRight 4 >>= landLeft (-1) >>= landRight (-2)  


--  We couldn't have achieved this by just using Maybe as an applicative. If you try it, you'll get stuck, because applicative functors don't allow for the applicative values to interact with each other very much.


-- we can now add a new construct which will fails pierre, here is the definition
banana :: Pole -> Maybe Pole  
banana _ = Nothing  


-- test with the following code
-- ghci> return (0,0) >>= landLeft 1 >>= banana >>= landRight 1  
-- Nothing  

--


-- If you replace >> with >>= \_ ->, it's easy to see why it acts like it does.
-- QUOTE: Normally, passing some value to a function that ignores its parameter and always just returns some predetermined value would always result in that predetermined value. With monads however, their context and meaning has to be considered as well. 


-- ghci> return (0,0) >>= landLeft 1 >> Nothing >>= landRight 1  
-- Nothing  

-- comparision will speak for us, what that will looks likes if we haven't try the clever choice that we have made before
-- 
--routine :: Maybe Pole  
--routine = case landLeft 1 (0,0) of  
--    Nothing -> Nothing  
--    Just pole1 -> case landRight 4 pole1 of   
--        Nothing -> Nothing  
--        Just pole2 -> case landLeft 2 pole2 of  
--            Nothing -> Nothing  
--            Just pole3 -> landLeft 1 pole3  
