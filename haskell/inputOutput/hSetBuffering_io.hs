-- file 
--   hSetBuffering_io.hs
-- descrpition: 
--    It takes a handle and a BufferMode and returns an I/O action that sets the buffering.  It takes a handle and a BufferMode and returns an I/O action that sets the buffering. 
--   an example of the value to the hSetBuffering is like this:
--     NoBuffering, LineBuffering or BlockBuffering (Maybe Int). 
-- 

import System.IO

main = do 
  withFile "something.txt" ReadMode (\handle -> do 
    hSetBuffering handle $ BlockBuffering (Just 2048)
    contents <- hGetContents handle
    putStr contents)

-- you may as well try the hFush function which will flush the buffers that is in the end writeBuffer
