-- file
--  special_functor.hs_ 
-- description:
--  special fucntor "(->) r " or the "r -> a"


-- QUOTE:
-- Another instance of Functor that we've been dealing with all along but didn't know was a Functor is (->) r. You're probably slightly confused now, since what the heck does (->) r mean? The function type r -> a can be rewritten as (->) r a, much like we can write 2 + 3 as (+) 2 3. When we look at it as (->) r a, we can see (->) in a slighty different light, because we see that it's just a type constructor that takes two type parameters, just like Either. But remember, we said that a type constructor has to take exactly one type parameter so that it can be made an instance of Functor. That's why we can't make (->) an instance of Functor, but if we partially apply it to (->) r, it doesn't pose any problems. If the syntax allowed for type constructors to be partially applied with sections (like we can partially apply + by doing (2+), which is the same as (+) 2), you could write (->) r as (r ->). How are functions functors? Well, let's take a look at the implementation, which lies in Control.Monad.Instances

-- QUOTE:
-- which lies in Control.Monad.Instances

-- 
instance Functor ((->) r) where  
    fmap f g = (\x -> f (g x))  

-- If the syntax allowed for it, it could have been written as

instance Functor (r ->) where  
    fmap f g = (\x -> f (g x)) 

-- let's see the fmap's type, it is 
--     fmap :: (a -> b) -> f a -> f b
-- Now what we'll do is mentally replace all the f's, which are the role that our functor instance plays, with (->) r's
-- we will get 
--   fmap :: (a -> b) -> ((->) r a) -> ((->) r b)
-- now write the  (->) r a and (-> r b) as infix type r->b and r -> b
-- now what we get is 
--   fmap :: (a -> b) -> (r -> a) -> (r -> b)

-- Mapping one function over a function has to produce a function


-- anoter way to write the function is as follow. 
--   
instance Functor ((->) r) where  
    fmap = (.)  

-- to run the command below, you might need to run as follow 
--   :m + Control.Monad.Instances

-- ghci> :t fmap (*3) (+100)  
-- fmap (*3) (+100) :: (Num a) => a -> a  
-- ghci> fmap (*3) (+100) 1  
-- 303  
-- ghci> (*3) `fmap` (+100) $ 1  
-- 303  
-- ghci> (*3) . (+100) $ 1  
-- 303  
-- ghci> fmap (show . (*3)) (*100) 1  
-- "300"  


-- QUOTE:
-- the functor law:
-- The first functor law states that if we map the id function over a functor, the functor that we get back should be the same as the original functore

-- example of the functor law
-- ghci> fmap id (Just 3)  
-- Just 3  
-- ghci> id (Just 3)  
-- Just 3  
-- ghci> fmap id [1..5]  
-- [1,2,3,4,5]  
-- ghci> id [1..5]  
-- [1,2,3,4,5]  
-- ghci> fmap id []  
-- []  
-- ghci> fmap id Nothing  
-- Nothing  

instance Functor Maybe where  
    fmap f (Just x) = Just (f x)  
    fmap f Nothing = Nothing  

-- QUOTE:
--   The second law says that composing two functions and then mapping the resulting function over a functor should be the same as first mapping one function over the functor and then mapping the other one. 

--   fmap (f . g) = fmap f . fmap g
-- should be the same as the one below 
--   fmap (f . g) F = fmap f (fmap g F).

-- Many times, you can intuitively see how these laws hold because the types act like containers or functions.  



