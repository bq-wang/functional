-- file
--  monoid_maybe.hs
-- description:
--   Maybe the monoids

instance Monoid a => Monoid (Maybe a) where  
    mempty = Nothing  
    Nothing `mappend` m = m  
    m `mappend` Nothing = m  
    Just m1 `mappend` Just m2 = Just (m1 `mappend` m2)  

-- and the examples that uses the Maybe monoid

- ghci> Nothing `mappend` Just "andy"  
- Just "andy"  
- ghci> Just LT `mappend` Nothing  
- Just LT  
- ghci> Just (Sum 3) `mappend` Just (Sum 4)  
- Just (Sum {getSum = 7})  


-- But if we don't know if the contents are monoids, we can't use mappend between them, so what are we to do? Well, one thing we can do is to just discard the second value and keep the first one. For this, the First a type exists and this is its definition:

-- 
newtype First a = First { getFirst :: Maybe a }  
    deriving (Eq, Ord, Read, Show)

instance Monoid (First a) where  
    mempty = First Nothing  
    First (Just x) `mappend` _ = First (Just x)  
    First Nothing `mappend` x = x  

-- and if you run it this way ?

-- 
-- ghci> getFirst $ First (Just 'a') `mappend` First (Just 'b')  
-- Just 'a'  
-- ghci> getFirst $ First Nothing `mappend` First (Just 'b')  
-- Just 'b'  
-- ghci> getFirst $ First (Just 'a') `mappend` First Nothing  
-- Just 'a'  

-- 
-- ghci> getFirst . mconcat . map First $ [Nothing, Just 9, Just 10]  
-- Just 9  


-- 
