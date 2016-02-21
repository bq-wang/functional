-- file 
--   ioeGetFileName.hs
-- descrpition: 
--   ioe functions families to let you ask the exceptions some attributes
--   

import System.Environment     
import System.IO     
import System.IO.Error     
    
main = toTry `catch` handler     
                 
toTry :: IO ()     
toTry = do (fileName:_) <- getArgs     
           contents <- readFile fileName     
           putStrLn $ "The file has " ++ show (length (lines contents)) ++ " lines!"     
    
handler :: IOError -> IO ()     
handler e     
    | isDoesNotExistError e =   
        case ioeGetFileName e of Just path -> putStrLn $ "Whoops! File does not exist at: " ++ path  
                                 Nothing -> putStrLn "Whoops! File does not exist at unknown location!"  
    | otherwise = ioError e     


-- or you can add hook more than one handler to the functions
-- main = do toTry `catch` handler1  
--           thenTryThis `catch` handler2  
--           launchRockets 
-- 


-- This is kind of similar to try-catch blocks of other languages
--  I prefer to have their type be something like IO (Either a b), meaning that they're normal I/O actions but the result that they yield when performed is of type Either a b, meaning it's either Left a or Right b.
