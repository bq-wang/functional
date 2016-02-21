-- file
--  applicative_functor.hs
-- description:
--  applicative functors

-- the Applicative functor
-- we'll take a look at applicative functors, which are beefed up functors, represented in Haskell by the Applicative typeclass
import Control.Applicative
--
import System.IO


sequenceA :: (Applicative f) => [f a] -> f [a]  
sequenceA [] = pure []  
sequenceA (x:xs) = (:) <$> x <*> sequenceA xs  

main = do 
  iresult <- sequenceA [getLine, getLine, getLine]
  map (\x -> putStrLn x) iresult
