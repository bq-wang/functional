-- file
--   type_synonyms.hs
-- description:
--   type synonyms 


-- why String is equivalent to [Char]
type String = [Char]


phoneBook :: [(String, String)]
phoneBook =      
    [("betty","555-2938")     
    ,("bonnie","452-2928")     
    ,("patsy","493-2928")     
    ,("lucille","205-2928")     
    ,("wendy","939-8282")     
    ,("penny","853-2492")     
    ]  


type PhoneBook = [(String, String)]

type PhoneNumber = String
type Name = String
type PhoneBook = [(Name, PhoneNumber)]


-- we can give it a very pretty and descriptive declaration
inPhoneBook :: Name -> PhoneNumber -> PhoneBook -> Bool  
inPhoneBook name pnumber pbook = (name,pnumber) `elem` pbook  


-- Type synonyms can also be parameterized.
--  we want a type that represents an association list type but still want it to be general so it can use any type as the keys and values, we can do this:

type AssocList k v = [(k, v)]


-- we can partially apply type parameters and get a new type constructors from them...
import qualified Data.Map
type IntMap v = Map Int v


-- or we could do it like this: 
type IntMap = Map  Int


-- 
data Either a b = Left a | Right b deriving (Eq, Ord, Read, Show)


-- ghci> Right 20  
-- Right 20  
-- ghci> Left "w00t"  
-- Left "w00t"  
-- ghci> :t Right 'a'  
-- Right 'a' :: Either a Char  
-- ghci> :t Left True  
-- Left True :: Either Bool b  


-- why types like this?
-- type like this is that you can annotate the type with some information where as tpyes like Nothing does not 
-- contain anything inside.  

data LockerState =  Take | Free  deriving (Show, Eq)
type Code =  String
type LockerMap = Map.Map Int (LockerState, Code)



lockerLookup :: Int -> LockerMap -> Either String Code  
lockerLookup lockerNumber map =   
    case Map.lookup lockerNumber map of   
        Nothing -> Left $ "Locker number " ++ show lockerNumber ++ " doesn't exist!"  
        Just (state, code) -> if state /= Taken   
                                then Right code  
                                else Left $ "Locker " ++ show lockerNumber ++ " is already taken!"  

lockers :: LockerMap 
lockers = Map.fromList
    [(100,(Taken,"ZD39I"))  
    ,(101,(Free,"JAH3I"))  
    ,(103,(Free,"IQSA9"))  
    ,(105,(Free,"QOTSA"))  
    ,(109,(Taken,"893JJ"))  
    ,(110,(Taken,"99292"))  
    ]  
