-- file::
--  type_parameter.hs
-- description:
--  use to demonstrate the use of the type parameters


-- data Maybe = Nothing | Just a 

-- :t Just 84
-- Just 84 :: (num t) => Maybe t

-- :t Nothing 
-- Nothing :: Maybe a

-- e.g. just examples
-- Just 10 :: Maybe Double 

-- data Car = Car { company :: String  
--                , model :: String  
--                , year :: Int  
--                } deriving (Show)

data Car a b c = Car { company :: a
               , model ::b
	       , year :: c
              } deriving (Show)

-- Car String String Int


tellCar :: Car -> String 
tellCar (Car {company = c, model = m, year = y}) = "This " ++ c ++ " " ++ m ++ " was made in " ++ show y  


