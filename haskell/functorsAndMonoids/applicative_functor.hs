-- file
--  applicative_functor.hs
-- description:
--  represented in Haskell by the Application typeclasses, found in the Control.Applicative module

-- the Applicative functor
-- we'll take a look at applicative functors, which are beefed up functors, represented in Haskell by the Applicative typeclass
import Control.Applicative
--

-- example of mapping functors over functors
--
-- ghci> :t fmap (++) (Just "hey")  
-- fmap (++) (Just "hey") :: Maybe ([Char] -> [Char])  
-- ghci> :t fmap compare (Just 'a')  
-- fmap compare (Just 'a') :: Maybe (Char -> Ordering)  
-- ghci> :t fmap compare "A LIST OF CHARS"  
-- fmap compare "A LIST OF CHARS" :: [Char -> Ordering]  
-- ghci> :t fmap (\x y z -> x + y / z) [3,4,5,6]  
-- fmap (\x y z -> x + y / z) [3,4,5,6] :: (Fractional a) => [a -> a -> a]  

-- We see how by mapping "multi-parameter" functions over functors, we get functors that contain functions inside them.



--ghci> let a = fmap (*) [1,2,3,4]  
--ghci> :t a  
--a :: [Integer -> Integer]  
--ghci> fmap (\f -> f 9) a  
--[9,18,27,36]  


-- the Applicative typeclasses
-- it has this type constraint

-- QUOTE:
--  it also introduces a class constraint. It says that if we want to make a type constructor part of the Applicative typeclass, it has to be in Functor first.
class (Functor f) => Applicative f where  
    pure :: a -> f a  
    (<*>) :: f (a -> b) -> f a -> f b  


-- QUOTE:
-- The <*> function is really interesting. It has a type declaration of f (a -> b) -> f a -> f b. Does this remind you of anything? Of course, fmap :: (a -> b) -> f a -> f b.
-- It's a sort of a beefed up fmap. 
-- QUOTE:
--  <*> takes a functor that has a function in it and another functor and sort of extracts that function from the first functor and then maps it over the second one. When I say extract, I actually sort of mean run and then extract, maybe even sequence. We'll see why soon.

instance Applicative Maybe where 
   pure = Just  -- Just is a functor,  I believe that Just Nothing = Nothing, and Just Just x = Just x 
   Nothing <*> _ = Nothing
   (Just f) <*> something = fmap f something

-- Again, from the class definition we see that the f that plays the role of the applicative functor should take one concrete type as a parameter, so we write instance Applicative Maybe where instead of writing instance Applicative (Maybe a) where.

-- example of the applicative functor
-- ghci> Just (+3) <*> Just 9  
-- Just 12  
-- ghci> pure (+3) <*> Just 10  
-- Just 13  
-- ghci> pure (+3) <*> Just 9  
-- Just 12  
-- ghci> Just (++"hahah") <*> Nothing  
-- Nothing  
-- ghci> Nothing <*> Just "woot"  
-- Nothing  

-- unlike normal functor mapping, you can just map a function and then you cannot get the result out in any general way . even 
-- if the result is a partially applied function

-- QUOTE:
--  applicative functors. on the otherhand, allow you to operate on several functors with a single function 

--ghci> pure (+) <*> Just 3 <*> Just 5  
--Just 8  
--ghci> pure (+) <*> Just 3 <*> Nothing  
--Nothing  
--ghci> pure (+) <*> Nothing <*> Just 5  
--Nothing  

-- QUOTE:
-- what is the benefit of the applicative functor?
-- allow us to take a function that expects parameters that aren't necessarily wrapped in functors and use that function to operate on several values that are in functor contexts.


-- the <$> operator

-- (++) <$> Just "Johntra" <*> Just "volta"

-- why is it cool?
-- QUOTE:  just sprinkle some <$> and <*> about and the function will operate on applicatives and return an applicativ


-- how is Applicative is implemented on the [] types?
instance Applicative [] where  
    pure x = [x]  
    fs <*> xs = [f x | f <- fs, x <- xs]  

-- more on the <*> and <$>

-- ghci> [(*0),(+100),(^2)] <*> [1,2,3]  
-- [0,0,0,101,102,103,1,4,9]  
-- 
-- ghci> [(+),(*)] <*> [1,2] <*> [3,4]  
-- [4,5,5,6,3,4,6,8]  
-- ghci> (++) <$> ["ha","heh","hmm"] <*> ["?","!","."]  
-- ["ha?","ha!","ha.","heh?","heh!","heh.","hmm?","hmm!","hmm."]  

-- some even more??
-- ghci> [ x*y | x <- [2,5,10], y <- [8,10,11]]     
-- [16,20,22,40,50,55,80,100,110]  
--    
-- ghci> (*) <$> [2,5,10] <*> [8,10,11]  
-- [16,20,22,40,50,55,80,100,110]  
-- 
-- 
-- ghci> filter (>50) $ (*) <$> [2,5,10] <*> [8,10,11]  
-- [55,80,100,110]  


-- Applicative on the IO

instance Applicative IO where  
    pure = return  
    a <*> b = do  
        f <- a  
        x <- b  
        return (f x)  

-- QUOTE  
--  Since pure is all about putting a value in a minimal context that still holds it as its result, 


-- with the IO action been applicative , you can do this : 
myAction :: IO String  
myAction = do  
    a <- getLine  
    b <- getLine  
    return $ a ++ b  


myAction :: IO String
myAction = (++) <$> getLine <$> getLine
