-- file
--   main_with_do.hs
-- desription:
--   introduce the do monad which can glue together several I/O actions into one 


main = do 
   putStrLn "Hello, what's your name?"
   name <- getLine
   putStrLn("Hey " ++ name ++ ",you rock!")


--wha is the name <- getLine   
-- QUOTE:   So what's up with name <- getLine then? You can read that piece of code like this: perform the I/O action getLine and then bind its result value to name. getLine has a type of IO String, so name will have a type of String.


-- what is the type of getine?

-- ghci> :t getLine  
-- getLine :: IO String 


-- QUOTE: 
-- getLine is an I/O action that contains a result type of String. That makes sense, because 

nameTag = "Hello, my name is "  ++ getLine


main = do  
    putStrLn "Hello, what's your name?"  
    name <- getLine  
    putStrLn $ "Read this carefully, because this is your future: " ++ tellFortune name  

-- the following is not valid 
-- nameTag = "hello, my name is  " ++ getLine

main = do 
  foo <- putStrLn "Hello, what's your name?" -- foo would jsut have a value of monad
  name <- getLine
  putStrLn("Hey " ++ name ++ ", you rock !") --  ina  do block , the last action cannot be bound to a name 



-- QUOTE: 
-- Except for the last line, every line in a do block that doesn't bind can also be written with a bind. So putStrLn "BLAH" can be written as _ <- putStrLn "BLAH". But that's useless, so we leave out the <- for I/O actions that don't contain an important result, like putStrLn something.


--
name = getLine -- it just give getLine I/O action a different name 

import Data.Char

main = do 
   putStrLn "What's your first name?"
   firstName <- getLine
   putStrLn "What's  your last name ?"
   lastName <- getLine 
   let bigFirstName = map toUpper firstName
       bigLastName = map toUpper lastName
   putStrLn $ "hey " ++ bigFirstName ++ " " ++ bigLastName ++ ", how are you?" 
