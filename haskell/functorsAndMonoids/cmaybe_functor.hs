-- file
--  cmaybe_functor.hs 
-- description:
--  define the new type which is called CNothing



data CMaybe a = CNothing | CJust Int a deriving (Show)

-- ghci> CNothing  
-- CNothing  
-- ghci> CJust 0 "haha"  
-- CJust 0 "haha"  
-- ghci> :t CNothing  
-- CNothing :: CMaybe a  
-- ghci> :t CJust 0 "haha"  
-- CJust 0 "haha" :: CMaybe [Char]  
-- ghci> CJust 100 [1,2,3]  
-- CJust 100 [1,2,3]  


instance Functor CMaybe where 
   fmap f CNothing = CNothing
   fmap f (CJust counter x) = CJust (counter + 1) (f x)

-- the teset cases

-- ghci> fmap (++"ha") (CJust 0 "ho")  
-- CJust 1 "hoha"  
-- ghci> fmap (++"he") (fmap (++"ha") (CJust 0 "ho"))  
-- CJust 2 "hohahe"  
-- ghci> fmap (++"blah") CNothing  
-- CNothing  


-- test the id law of the functor - the law of the id fucntion
-- ghci> fmap id (CJust 0 "haha")  
-- CJust 1 "haha"  
-- ghci> id (CJust 0 "haha")  
-- CJust 0 "haha"  

-- you may as well to test the second law, the law of the functor mapping

-- If you think of functors as things that output values, you can think of mapping over functors as attaching a transformation to the output of the functor that changes the value.

