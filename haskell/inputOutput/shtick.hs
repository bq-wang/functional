-- file
--    shtick.hs
-- description: 
--    you will need to compile this code with the 
--     ghc -- make helloworld
main = putStrLn "Hello, world"


-- ghci> :t putStrLn  
-- putStrLn :: String -> IO ()  
--     ghci> :t putStrLn "hello, world"  
--     putStrLn "hello, world" :: IO () 

-- QUOTE 
-- We can read the type of putStrLn like this: putStrLn takes a string and returns an I/O action that has a result type of () (i.e. the empty tuple, also know as unit).
--     putStrLn takes a string and returns an I/O action that has a result type of ()
--     
