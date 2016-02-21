-- file : 
--  randomstring_gen.hs
-- description:
--   generate the random string with the 
import System.Random  
  
main = do  
    gen <- getStdGen  
    putStr $ take 20 (randomRs ('a','z') gen)  


