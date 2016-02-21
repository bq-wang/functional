-- file:
--  Person2.hs
-- description:
--  Person2

module Person
(Person(..)
,Car(..)
) where 


data Person = Person { firstName :: String
                     , lastName :: String
	             , age :: Int
		     , height :: Float
		     , phoneNumber :: String
		     , flavor :: String
		     } deriving (Show)

-- Check the type of flavor and firstName
-- :t flavor
-- :t firstName

-- data Car String String String Int deriving (Show)
data Car = Car { company :: String, model :: String, year :: Int } deriving (Show)

-- Car { company = "Ford", model = "Mustang", year=1967}

-- Create the Car object
-- Car "Ford" "Mustang" 1967
-- 
		     
-- 
-- Type Parameter :
-- the type parameter a 
data Maybe a = Nothing | Just a 




data Car = Car { company :: String  
               , model :: String  
               , year :: Int  
               } deriving (Show)  


-- with type paramter

data Car a b c = Car { company :: a  
                     , model :: b  
                     , year :: c   
                     } deriving (Show)  


tellCar :: Car -> String  
tellCar (Car {company = c, model = m, year = y}) = "This " ++ c ++ " " ++ m ++ " was made in " ++ show y

-- to use the tellCar
-- ghci> let stang = Car {company="Ford", model="Mustang", year=1967}  
-- ghci> tellCar stang  
-- "This Ford Mustang was made in 1967"  


tellCar :: (Show a) => Car String String a -> String  
tellCar (Car {company = c, model = m, year = y}) = "This " ++ c ++ " " ++ m ++ " was made in " ++ show y  


-- how to use the new tellCar method which has the new type paramter. 
-- ghci> tellCar (Car "Ford" "Mustang" 1967)  
-- "This Ford Mustang was made in 1967"  
-- ghci> tellCar (Car "Ford" "Mustang" "nineteen sixty seven")  
-- "This Ford Mustang was made in \"nineteen sixty seven\""  
-- ghci> :t Car "Ford" "Mustang" 1967  
-- Car "Ford" "Mustang" 1967 :: (Num t) => Car [Char] [Char] t  
-- ghci> :t Car "Ford" "Mustang" "nineteen sixty seven"  
-- Car "Ford" "Mustang" "nineteen sixty seven" :: Car [Char] [Char] [Char]  

