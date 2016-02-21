-- file 
-- when_monad.hs
-- descrpition: 
--   the Control.Monad

import Control.Monad

main =do 
   c <- getChar
   when (c  /= ' ') $ do 
      putChar c 
      main
