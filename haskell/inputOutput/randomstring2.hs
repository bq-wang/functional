-- file : 
--  randomstring2.hs
-- description:
--   generate random string 2

import System.Random  
 
-- this will always generate the same result, 
 
import System.Random  
import Data.List  



-- use an infnite generator sequence and split at the 20 parts  
-- main = do  
--     gen <- getStdGen  
--     let randomChars = randomRs ('a','z') gen  
--         (first20, rest) = splitAt 20 randomChars  
--         (second20, _) = splitAt 20 rest  
--     putStrLn first20  
--     putStr second20

-- main = do  
--     gen <- getStdGen  
--     putStrLn $ take 20 (randomRs ('a','z') gen)  
--     gen2 <- getStdGen  
--     putStr $ take 20 (randomRs ('a','z') gen2)  


-- or you can do this 
--   newStdGen 
-- which splits our current random generator into two generators.. it updates the global generator with one of them and encapsulate 
-- the other as its result

-- Another way is to use the newStdGen action, which splits our current random generator into two generators. It updates the global random generator with one of them and encapsulates the other as its result.
main = do 
   gen <- getStdGen
   putStrLn $ take 20  (randomRs ('a', 'z') gen)
   gen' <- newStdGen
   putStr $ take 20 (randomRs ('a', 'z') gen')



