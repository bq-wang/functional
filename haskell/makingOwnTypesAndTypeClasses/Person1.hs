-- file:
--   Person.hs
-- description:
--   the file defines the Person object

-- 
-- Record Syntax

module Person 
( Person(..)
, firstName
, lastName
, age
, height
, phoneNumber
, flavor
) where 

data Person = Person String String Int Float String String deriving (Show)

firstName :: Person -> String
firstName (Person firstName _ _ _ _ _) = firstName

lastName :: Person -> String
lastName (Person _ lastName _ _ _ _) = lastName

age :: Person -> Int
age (Person _ _ age _ _ _ ) = age

height :: Person -> Float
height (Person _ _ _ height _ _) = height  
  
phoneNumber :: Person -> String  
phoneNumber (Person _ _ _ _ number _) = number  
  
flavor :: Person -> String  
flavor (Person _ _ _ _ _ flavor) = flavor

-- 
-- alternative way to write data types
-- with mnemonic such as follo
-- NOTE : 
--  Check on the Person2.hs
