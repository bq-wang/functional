-- file 
--  files_streams.hs
-- descrpition: 
--  Files and Streams
import Control.Monad  
import Data.Char  
  
main = forever $ do  
    putStr "Give me some input: "  
    l <- getLine  
    putStrLn $ map toUpper l  
