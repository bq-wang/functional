-- file 
--  exception_trycatch.hs
-- descrpition: 
--  cehck to see if the exception is the one that we are expecting 
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
    | isDoesNotExistError e = putStrLn "The file doesn't exist!"  
    | otherwise = ioError e  





-- the following types of exception that exists below 

-- isAlreadyExistsError
-- isDoesNotExistError
-- isAlreadyInUseError
-- isFullError
-- isEOFError
-- isIllegalOperation
-- isPermissionError
-- isUserError


-- so that you could have a handlers that looks like something like this:

-- handler :: IOError -> IO ()  
-- handler e  
--     | isDoesNotExistError e = putStrLn "The file doesn't exist!"  
--     | isFullError e = freeSomeSpace  
--     | isIllegalOperation e = notifyCops  
--     | otherwise = ioError e  


-- there a series of exception that exists which start with ioe and you can see a full list of them 
--  such as ioeGetFileName
-- 

-- ioeGetFileName :: IOError -> Maybe FilePath


