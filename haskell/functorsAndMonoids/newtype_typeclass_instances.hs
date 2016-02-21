-- file
--  newtype_typeclass_instance.hs
-- description:
--  Using newtype to make type class instances
import Control.Applicative
import Control.Monad.Instances


-- there's no way to do something like that with (a,b) so that the type parameter a ends up being the one that changes when we use fmap. 
-- To get around this, we can newtype our tuple in such a way that the second type parameter represents the type of the first component in the tuple:


newtype Pair b a = Pair { getPair :: (a,b) }  

instance Functor (Pair c) where  
    fmap f (Pair (x,y)) = Pair (f x, y) 


-- the f to the fmap looks like 


-- fmap :: (a -> b) -> Pair c a -> Pair c b  

-- ghci> getPair $ fmap (*100) (Pair (2,3))  
-- (200,3)  
-- ghci> getPair $ fmap reverse (Pair ("london calling", 3))  
-- ("gnillac nodnol",3)  
-- 

