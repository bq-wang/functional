-- file
--   type_paramter.hs
-- description:
--    this is a type paramter illustration on the map types

module Vector
( Vector(..)
) where 



-- If we were defining a mapping type, we could add a typeclass constraint in the data declaration:
-- data (Ord k) => Map K v = ... 

-- NOTE:  it's a very strong convention in Haskell to never add typeclass constraints in data declarations. Why?



data Vector a = Vector a a a deriving (Show)  
-- vector plus
vplus :: (Num t) => Vector t -> Vector t -> Vector t  
(Vector i j k) `vplus` (Vector l m n) = Vector (i+l) (j+m) (k+n)  
-- vector Mult  
vectMult :: (Num t) => Vector t -> t -> Vector t  
(Vector i j k) `vectMult` m = Vector (i*m) (j*m) (k*m)  
-- vector scalarMult  
scalarMult :: (Num t) => Vector t -> Vector t -> t  
(Vector i j k) `scalarMult` (Vector l m n) = i*l + j*m + k*n  

-- NOTE on the vector classes
--    note that the vector class can only operate on the same Vector class and can work on Float, Int, and Double. 


-- 
-- ghci> Vector 3 5 8 `vplus` Vector 9 2 8  
-- Vector 12 7 16  
-- ghci> Vector 3 5 8 `vplus` Vector 9 2 8 `vplus` Vector 0 2 3  
-- Vector 12 9 19  
-- ghci> Vector 3 9 7 `vectMult` 10  
-- Vector 30 90 70  
-- ghci> Vector 4 9 5 `scalarMult` Vector 9.0 2.0 4.0  
-- 74.0  
-- ghci> Vector 2 9 3 `vectMult` (Vector 4 9 5 `scalarMult` Vector 9 2 4)  
-- Vector 148 666 222  
