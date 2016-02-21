-- file 
--  writeFile.hs
-- descrpition: 
--  write contents to IO the type of the writeFile call is like this:
--   iwriteFile :: FilePath -> String -> IO()

import System.IO
import Data.Char

main = do 
   contents <- readFile "girlfriend.txt"
   writeFile "girlfriendcaps.txt" (map toUpper contents)




