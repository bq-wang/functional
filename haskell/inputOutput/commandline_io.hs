-- file
--   commandline_io.hs
-- description:
--   command line IO 101

import System.Environment
import Data.List


main = do 
   args <- getArgs  
   progName <- getProgName  
   putStrLn "The arguments are:"  
   mapM putStrLn args  
   putStrLn "The program name is:"  
   putStrLn progName  

-- run with the following command line with 
-- runhaskell commandline_io.hs first second w00t "multi word arg"  
