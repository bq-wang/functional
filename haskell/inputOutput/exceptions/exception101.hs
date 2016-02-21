-- file 
--   exception101.hs
-- descrpition: 
--  I/O code (i.e. impure code) can throw exception
--   

-- 4 `div` 0

-- head []

-- Pure code can throw exceptions, but it they can only be caught in the I/O part of our code (when we're inside a do block that goes into main).


-- QUOTE:
--  Pure code can throw exceptions, but it they can only be caught in the I/O part of our code (when we're inside a do block that goes into main). That's because you don't know when (or if) anything will be evaluated in pure code, because it is lazy and doesn't have a well-defined order of execution, whereas I/O code does.



-- QUOTE:
--  The logic of our program should reside mostly within our pure functions, because their results are dependant only on the parameters that the functions are called with. When dealing with pure functions, you only have to think about what a function returns, because it can't do anything else. 



-- QUOTE:
-- Pure functions are lazy by default, which means that we don't know when they will be evaluated and that it really shouldn't matter.
-- However, once pure functions start throwing exceptions, it matters when they are evaluated. That's why we can only catch exceptions thrown from pure functions in the I/O part of our code. And that's bad, because we want to keep the I/O part as small as possible. However, if we don't catch them in the I/O part of our code, our program crashes. The solution? Don't mix exceptions and pure code. 

import System.Environment 
import System.IO



-- main = do (fileName : _) <- getArgs 
--    contents <- readFile fileName
--    putStrLn $ "The file has " ++ show (length (lines contents)) ++ "lines!"

-- throws exception when file with the filename provided does not exists



-- solution I : check before act
-- doesFileExist
-- import System.Environment  
-- import System.IO  
-- import System.Directory  
--   
-- main = do (fileName:_) <- getArgs  
--           fileExists <- doesFileExist fileName  
--           if fileExists  
--               then do contents <- readFile fileName  
--                       putStrLn $ "The file has " ++ show (length (lines contents)) ++ " lines!"  
--               else do putStrLn "The file doesn't exist!"  


-- solution II: exception to use
-- catch to use 

import System.Environment
import System.IO
import System.IO.Error


-- the following means that 
--  run the  "toTry" and if there is an exception
-- try to handle that with the handler specified 
-- 
--
main = toTry `catch` handler  
              
toTry :: IO ()  
toTry = do (fileName:_) <- getArgs  
           contents <- readFile fileName  
           putStrLn $ "The file has " ++ show (length (lines contents)) ++ " lines!"  
  
handler :: IOError -> IO ()  
handler e = putStrLn "Whoops, had some trouble!"  

