-- file 
-- getChar_haskell.hs
-- descrpition: 
-- getChar function test


main = do 
   c <- getChar
   if c /= ' ' 
      then do 
        putChar c 
        main 
       else return ()
-- ghci actually use print function when you type out a value 
