-- file 
--  ireverseRPN.hs
-- descrpition: 
--   with functional solving the problem of reverse polish numbers

solveRPN :: (Num a, Read a) => String -> a  
solveRPN = head . foldl foldingFunction [] . words  
    where   foldingFunction (x:y:ys) "*" = (x * y):ys  
            foldingFunction (x:y:ys) "+" = (x + y):ys  
            foldingFunction (x:y:ys) "-" = (y - x):ys  
            foldingFunction xs numberString = read numberString:xs  

-- 

-- use the following datat to solve the data below
-- ghci> solveRPN "10 4 3 + 2 * -"  
-- -4  
-- ghci> solveRPN "2 3 +"  
-- 5  
-- ghci> solveRPN "90 34 12 33 55 66 + * - +"  
-- -3947  
-- ghci> solveRPN "90 34 12 33 55 66 + * - + -"  
-- 4037  
-- ghci> solveRPN "90 34 12 33 55 66 + * - + -"  
-- 4037  
-- ghci> solveRPN "90 3 -"  
-- 87  

