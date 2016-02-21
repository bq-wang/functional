-- file
--  fistful_monoids.hs
-- description:
--  fistful of monoids

import qualified Foldable as F

-- Monads are a natural extension of applicative functors and with them we're concerned with this:
-- 
--  : if you have a value with a context, m a, how do you apply to it a function that takes a normal a and returns a value with a context? That is, how do you apply a function of type a -> m b to a value of type m a? So essentially, we will want this function:
-- 
-- (>>=) :: (Monad m) => m a -> (a -> m b) -> m b  
--


-- If we have a fancy value and a function that takes a normal value but returns a fancy value, how do we feed that fancy value into the function?

-- but monads are just applicative functors that support >>=. The >>= function is pronounced as bind.

-- we will see how we can deel with that ..

import Data.Maybe

-- if we try to create the effect of taking a fancy value and a function which take a normal value but return a fancy value
-- you can do this:
-- ghci> (\x -> Just (x+1)) 1  
-- Just 2  
-- ghci> (\x -> Just (x+1)) 100  
-- Just 101  

applyMaybe :: Maybe a -> (a -> Maybe b) -> Maybe b  
applyMaybe Nothing f  = Nothing  
applyMaybe (Just x) f = f x  



-- an exapmle of running the applyMaybe is as follow. 
-- ghci> Just 3 `applyMaybe` \x -> Just (x+1)  
-- Just 4  
-- ghci> Just "smile" `applyMaybe` \x -> Just (x ++ " :)")  
-- Just "smile :)"  
-- ghci> Nothing `applyMaybe` \x -> Just (x+1)  
-- Nothing  
-- ghci> Nothing `applyMaybe` \x -> Just (x ++ " :)")  
-- Nothing  


