-- file 
--   repeatable_read.hs
-- description:
--   repeatable read from I/O action 


-- you can run the program this way 
-- 
--  ghc --make hellowrld
--
-- ./helloworld
--
-- or you can run this command
-- runhaskell
--   runhaskel repeatable_read.hs


-- every if should have a matching 
-- an else condition . that is because every 
-- expression should returns a value 
-- so it is if condition then I/O action else I/O action 

main = do   
    line <- getLine  
    if null line  
        then return ()  
        else do  
            putStrLn $ reverseWords line  
            main  
  
reverseWords :: String -> String  
reverseWords = unwords . map reverse . words  

--  why this "return () " 
-- statement 
-- the return in Haskell is really nothing like the return in most other languages!the return in Haskell is really nothing like the return in most other languages!

--  In Haskell (in I/O actions specifically), it makes an I/O action out of a pure value. If you think about the box analogy from before, it takes a value and wraps it up in a box.

-- return "haha", will have a type of "IO String "
