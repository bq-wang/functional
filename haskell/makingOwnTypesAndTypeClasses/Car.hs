-- file :
--   Car.hs
-- description:
-- this is a file that defines a type paramterized Car in Haskell


module Car
(Car(..)
) where 


data Car a b c = Car { company :: a
                     , model :: b
                     , year :: c
                     } deriving (Show)


tellCar :: (Show a) => Car String String a -> String
-- does this mean that you have created an alias to company with c,and alias to model with m and alias to year with y
tellCar (Car {company = c, model = m, year = y}) = "This " ++ c ++ " " ++ m ++ " was made in " ++ show y



