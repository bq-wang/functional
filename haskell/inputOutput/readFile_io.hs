-- file 
--  readFile_io.hs
-- descrpition: 
--  read file of the type 
--   readFile :: FilePath -> IO String 

import System.IO

main = do 
   contents <- readFile "girlfriend.txt"
   putStr contents



