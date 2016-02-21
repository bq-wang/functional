-- file
--  monad_typeclass.hs
-- description:
--  the monad type class

class Monad m where  
    return :: a -> m a -- return get a value and put that into  a context 
  
    (>>=) :: m a -> (a -> m b) -> m b --  it takes a monadic value (that is, a value with a context) and feeds it to a function that takes a normal value but returns a monadic value. 
  
    (>>) :: m a -> m b -> m b  
    x >> y = x >>= \_ -> y  
  
    fail :: String -> m a  i -- it's used by Haskell to enable failure in a special construct for monads that we will meet later
    fail msg = error msg  


instance Monad Maybe where  
    return x = Just x  
    Nothing >>= f = Nothing  
    Just x >>= f  = f x  
    fail _ = Nothing  
