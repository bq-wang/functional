-- file 
--   derived_instances.hs
-- description:
--   a typeclaess is a sort of interface that defines some behaviors
--   a type can be made of an instance of a typeclass if it supports the behavior
-- for stuff tha can be equated
-- e.g. the Eq typeclass, where Int is a part of the Eq typeclass, the real  usefulness of the Eq typeclass we can use 
-- == function with values of that types. 
-- this is why the expression like 4 == 4 and "foo" /= "bar" typecheck.


-- a person class that has implemented the person class

-- data Person = Person { firstName :: String  
--                      , lastName :: String  
--                      , age :: Int  
--                      } deriving (Eq)


-- ghci> let mikeD = Person {firstName = "Michael", lastName = "Diamond", age = 43}  
-- ghci> let adRock = Person {firstName = "Adam", lastName = "Horovitz", age = 41}  
-- ghci> let mca = Person {firstName = "Adam", lastName = "Yauch", age = 44}  
-- ghci> mca == adRock  
-- False  
-- ghci> mikeD == adRock  
-- False  
-- ghci> mikeD == mikeD  
-- True  
-- ghci> mikeD == Person {firstName = "Michael", lastName = "Diamond", age = 43}  
-- True  


-- now, let make the Person class part of the typeclass of 
--  String, String, Int

data Person = Person { firstName :: String  
                     , lastName :: String  
                     , age :: Int  
                     } deriving (Eq, Show, Read)  

-- ghci> let mikeD = Person {firstName = "Michael", lastName = "Diamond", age = 43}  
-- ghci> mikeD  
-- Person {firstName = "Michael", lastName = "Diamond", age = 43}  
-- ghci> "mikeD is: " ++ show mikeD  
-- "mikeD is: Person {firstName = \"Michael\", lastName = \"Diamond\", age = 43}"  


-- ghci> read "Person {firstName =\"Michael\", lastName =\"Diamond\", age = 43}" :: Person  
-- Person {firstName = "Michael", lastName = "Diamond", age = 43} 


--  We can also read parameterized types, but we have to fill in the type parameters. So we can't do read "Just 't'" :: Maybe a, but we can do read "Just 't'" :: Maybe Char.


-- you can even compare Nothing with Just a 
-- because Nothing comes before Just so Nothing is smaller than anything else. 
-- 

-- ghci> Nothing < Just 100  
-- True  
-- ghci> Nothing > Just (-49999)  
-- False  
-- ghci> Just 3 `compare` Just 2  
-- GT  
-- ghci> Just 100 > Just 50  
-- True  

-- we cannot do this
-- Just(*3) > Just (*2)
-- because functions are not comparable.


-- data Day = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday 


-- you can make it a part of the Enum typeclass

data Day = Monday | Tuesday | Wednesday | Thursday | Friday | Saturday | Sunday   
           deriving (Eq, Ord, Show, Read, Bounded, Enum)  

-- 

minBound :: Day
maxBound :: Day 

succ Monday
pred Saturday


-- 
