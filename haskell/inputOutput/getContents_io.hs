-- file 
--  getContents_io.hs
-- descrpition: 
--  getContents_io.hs the lazy getContents_io.hs
import Data.Char  
  
main = do 
    main2
--    contents <-  getContents
--    putStr (map toUpper contents)


main2 = do 
    contents <- getContents  
    putStr (shortLinesOnly contents)  
  
shortLinesOnly :: String -> String  
shortLinesOnly input =   
    let allLines = lines input  
        shortLines = filter (\line -> length line < 10) allLines  
        result = unlines shortLines  
    in  result  
