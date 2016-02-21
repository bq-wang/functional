-- file 
--  forever
-- descrpition: 
--    takes an I/O action and returns an I/O action that just repeats the I/O action it got forever. It's located in Control.Monad

import Control.Monad  
import Data.Char  
  
main = forever $ do  
    putStr "Give me some input: "  
    l <- getLine  
    putStrLn $ map toUpper l  
