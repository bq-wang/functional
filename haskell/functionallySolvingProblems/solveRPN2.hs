-- file 
--  reverseRPN2.hs
-- descrpition: 
--  solve the reverseRPN data issues


import Data.List  
  
solveRPN :: String -> Float  
solveRPN = head . foldl foldingFunction [] . words  
    where   foldingFunction (x:y:ys) "*" = (x * y):ys  
            foldingFunction (x:y:ys) "+" = (x + y):ys  
            foldingFunction (x:y:ys) "-" = (y - x):ys  
            foldingFunction (x:y:ys) "/" = (y / x):ys  
            foldingFunction (x:y:ys) "^" = (y ** x):ys  
            foldingFunction (x:xs) "ln" = log x:xs  
            foldingFunction xs "sum" = [sum xs]  
            foldingFunction xs numberString = read numberString:xs  


-- solve the RPN data issue with the following data to prove the correctness of the data
-- ghci> solveRPN "2.7 ln"  
-- 0.9932518  
-- ghci> solveRPN "10 10 10 10 sum 4 /"  
-- 10.0  
-- ghci> solveRPN "10 10 10 10 10 sum 4 /"  
-- 12.5  
-- ghci> solveRPN "10 2 ^"  
-- 100.0  
-- solveRPN "43.2425 0.5 ^"
