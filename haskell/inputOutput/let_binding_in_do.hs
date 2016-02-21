-- file
--  let_binding_in_do.hs
-- description: 
--  the let binding in the do monad
import Data.Char  
  
main = do  
    putStrLn "What's your first name?"  
    firstName <- getLine  
    putStrLn "What's your last name?"  
    lastName <- getLine  
    let bigFirstName = map toUpper firstName  
        bigLastName = map toUpper lastName  
    putStrLn $ "hey " ++ bigFirstName ++ " " ++ bigLastName ++ ", how are you?"

-- so in general 
--
-- <- is (for now) to perform I/O actions and binding their results to names. map toUppser firstName, however, isn't an I/O actoin. It's a pure expression in Haskell



