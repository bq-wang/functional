-- file 
--   Car2.hs
-- description: 
--   a car with a more variant things than others 

module Car
(Car(..)
) where 

-- the car record type does not use the Record syntax 
data Car = Car { company :: String  
               , model :: String  
               , year :: Int  
               } deriving (Show)  
tellCar :: Car -> String  
tellCar (Car {company = c, model = m, year = y}) = "This " ++ c ++ " " ++ m ++ " was made in " ++ show y  


-- use the following to test the tellCar funciton 
-- tellCar ( Car {company="Ford", model="Mustang", year=1967}  )



