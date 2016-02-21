-- file
--   functor reversed
-- description:
---  functor function in a reversed way 
-- main = do line <- getLine   
--           let line' = reverse line  
--           putStrLn $ "You said " ++ line' ++ " backwards!"  
--           putStrLn $ "Yes, you really said" ++ line' ++ " backwards!"  

main = do line <- fmap reverse getLine  
          putStrLn $ "You said " ++ line ++ " backwards!"  
          putStrLn $ "Yes, you really said" ++ line ++ " backwards!"  

