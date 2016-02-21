-- file : 
--  haskell_return_statement.hs
-- description:
--  haskell return statement  demo 

main = do 
  -- returndoes not cause the I/O do block to end in execution or anything like that. 
  return () 
  return "HAHAHA"
  line <- getLine
  return "BLAH BLAH BLAH"
  return 4 
  putStrLn line


-- main = do 
--   a <- return "hell"
--   b <- return "yeah!"
--   putStrLn $ a ++ "  " + b 


-- main = do 
--   let a = "hell"
--       b = "yeah"
-- putStrLn a ++ " " ++ b 

-- why do we have a return statement?
--   we mostly use return either because we need to create an I/O action that doesn't do anything or because we don't want the I/O action that's made up from a do block to have the result value of its last action, but we want it to have a different result value, so we use return to make an I/O action that always has our desired result contained and we put it at the end.
