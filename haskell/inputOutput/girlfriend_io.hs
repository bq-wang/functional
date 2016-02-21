-- file
--  girlfriend_io.hs
-- description:
--  open and read files, and close the file with the hClose call
--
import System.IO

main = do  
    handle <- openFile "girlfriend.txt" ReadMode  
    contents <- hGetContents handle  
    putStr contents  
    hClose handle  

-- type of openFile

--  poenFile :: FilePath -> IOMode -> IO Handle
