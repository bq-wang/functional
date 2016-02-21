-- file
--  monad_maybe.hs
-- description:
--  the type of monad_maybe

instance Monad Maybe where  
    return x = Just x  
    Nothing >>= f = Nothing  
    Just x >>= f  = f x  
    fail _ = Nothing  


-- ghci> return "WHAT" :: Maybe String  
-- Just "WHAT"  
-- ghci> Just 9 >>= \x -> return (x*10)  
-- Just 90  
-- ghci> Nothing >>= \x -> return (x*10)  
-- Nothing


