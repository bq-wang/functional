-- file
--  applicative_io.hs
-- description:
--  applicative IO 
import Control.Applicative
myAction :: IO String  
myAction = (++) <$> getLine <*> getLine  


main = do  
    a <- (++) <$> getLine <*> getLine  
    putStrLn $ "The two lines concatenated turn out to be: " ++ a  

