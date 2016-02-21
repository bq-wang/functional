-- file
--  kinds_and_some_typefoo.hs
-- description: 
--   we'll take a look at formally defining how types are applied to type constructors, just like we took a look at formally defining how values are applied to functions by using type declarations.


-- QUOTE: 
--  (functions are also values, because we can pass them around and such) each have their own type. 
-- 

-- Types are little labels that values carry so that we can reason about the values. But types have their own little labels, called kinds.



-- NOTE: 
-- Types are little labels that values carry so that we can reason about the values. But types have their own little labels, called kinds.

--
-- how to check the kinds of a types ??
-- the key is the 
-- :k types o
-- e.g.
-- ghci> :k Int
-- Int :: * 

-- How quaint. What does that mean? A * means that the type is a concrete type. A concrete type is a type that doesn't take any type parameters and values can only have types that are concrete types.

-- 
-- checkig Maybe
-- ghci> :k Maybe  
-- Maybe :: * -> *  

-- 
-- checking Maybe Int
-- ghci> :k Maybe Int  
-- Maybe Int :: *  

-- more 
-- ghci> :k Either  
-- Either :: * -> * -> * 
-- 
-- ghci> :k Either String  
-- Either String :: * -> *  
-- ghci> :k Either String Int  
-- Either String Int :: *  


class Tofu t where  
    tofu :: j a -> t a j  

-- j a has to have a kind of *
--
-- so j has a kind of * -> * 
-- and t should be a type of  * -> (* -> *) -> *
-- So it takes a concrete type (a), a type constructor that takes one concrete type (j) and produces a concrete type. Wow.


data Frank a b  = Frank {frankField :: b a} deriving (Show) 
-- ghci> :t Frank {frankField = Just "HAHA"}  
-- Frank {frankField = Just "HAHA"} :: Frank [Char] Maybe  
-- ghci> :t Frank {frankField = Node 'a' EmptyTree EmptyTree}  
-- Frank {frankField = Node 'a' EmptyTree EmptyTree} :: Frank Char Tree  
-- ghci> :t Frank {frankField = "YES"}  
-- Frank {frankField = "YES"} :: Frank Char []


-- now we making Frank an instance of ToFu is preety simple 
instance Tofu Frank where 
   tofu x = Frank x
-- ghci> tofu (Just 'a') :: Frank Char Maybe  
-- Frank {frankField = Just 'a'}  
-- ghci> tofu ["HELLO"] :: Frank [Char] []  
-- Frank {frankField = ["HELLO"]}  


-- we did flex our type muscle, let's do some type-foo. We have this data type

data Barry t k p = Barry { yabba :: p, dabba :: t k }

-- ghci> :k Barry  
-- Barry :: (* -> *) -> * -> * -> *  

instance Functor (Barry a b) where  
    fmap f (Barry {yabba = x, dabba = y}) = Barry {yabba = f x, dabba = y}  
