-- file 
--   lockers.hs
-- description:
--   lockers libraries 
--   an example of the Type synonyms.
import qualified Data.Map as Map  
import Prelude hiding (Either, Left, Right)
data Either a b = Left a | Right b deriving (Eq, Ord, Read, Show)  
data LockerState = Taken | Free deriving (Show, Eq)  
  
type Code = String  
  
type LockerMap = Map.Map Int (LockerState, Code)  

lockers :: LockerMap
lockers = Map.fromList
    [(100,(Taken,"ZD39I"))
    ,(101,(Free,"JAH3I"))
    ,(103,(Free,"IQSA9"))
    ,(105,(Free,"QOTSA"))
    ,(109,(Taken,"893JJ"))
    ,(110,(Taken,"99292"))
    ]

-- lockerLookup :: Int -> LockerMap -> Either String Code  
-- lockerLookup lockerNumber map =   
--     case Map.lookup lockerNumber map of   
--         Nothing -> Left $ "Locker number " ++ show lockerNumber ++ " doesn't exist!"  
--         Just (state, code) -> if state /= Taken   
--                                 then Right code  
--                                 else Left $ "Locker " ++ show lockerNumber ++ " is already taken!"  

lockerLookup :: Int -> LockerMap -> Either String Code
lockerLookup lockerNumber map = 
   case Map.lookup lockerNumber map of
        Nothing -> Left $ "Locker Number " ++ show lockerNumber ++ "does't exist!"
        Just (state, code) -> if state /= Taken
                              then Right code
                              else Left $ "Locker" ++ show lockerNumber ++ "Is already taken!"

-- ghci> lockerLookup 101 lockers  
-- Right "JAH3I"  
-- ghci> lockerLookup 100 lockers  
-- Left "Locker 100 is already taken!"  
-- ghci> lockerLookup 102 lockers  
-- Left "Locker number 102 doesn't exist!"  
-- ghci> lockerLookup 110 lockers  
-- Left "Locker 110 is already taken!"  
-- ghci> lockerLookup 105 lockers  
-- Right "QOTSA" 
