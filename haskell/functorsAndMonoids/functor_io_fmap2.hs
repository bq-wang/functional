-- file
--  functor_io_map2.hs 
-- description:
--   another use of functor on the IO action

import Data.Char  
import Data.List  
  
main = do line <- fmap (intersperse '-' . reverse . map toUpper) getLine  
          putStrLn line  
