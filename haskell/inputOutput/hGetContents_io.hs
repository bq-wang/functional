-- file 
--  hGetContents_io.hs
-- descrpition: 
--  unlike the getContents_io.hs , which automatically read from the stdin, gGetContents will read from aHandle
import Data.Char  

import System.IO


main = do 
    withFile "girlfriend.txt" ReadMode (\handle -> do 
       contents <- hGetContents handle
       putStr contents) 

-- haskell's way of withFile pattern, which is more like the Dispose pattern used quit common in C# language


-- and if you will implements the code of hGetHandle it is like this: 


withFile' :: FilePath -> IOMode -> (Handle -> IO a) -> IO a  
withFile' path mode f = do  
    handle <- openFile path mode   
    result <- f handle  
    hClose handle  
    return result  

-- other functions that will take an h variant is that hGetContents, hPutStr, hGetChar, hPutStrLn
