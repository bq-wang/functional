-- file
--   lengthCompare.hs
-- description:
--  compare algorithm that uses Ordering monoid

import Data.Monoid  
  
lengthCompare :: String -> String -> Ordering  
lengthCompare x y = (length x `compare` length y) `mappend`  
                    (x `compare` y)  

-- lengthCompare :: String -> String -> Ordering  
-- lengthCompare x y = let a = length x `compare` length y   
--                         b = x `compare` y  
--                     in  if a == EQ then b else a  


-- an modified version that comppare 1. the length, 2. the vowls

-- import Data.Monoid  
--   
-- lengthCompare :: String -> String -> Ordering  
-- lengthCompare x y = (length x `compare` length y) `mappend`  
--                     (vowels x `compare` vowels y) `mappend`  
--                     (x `compare` y)  
--     where vowels = length . filter (`elem` "aeiou")  







