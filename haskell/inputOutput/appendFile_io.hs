-- file 
--  functors_redux.hs
-- descrpition: 
--   a functor redux
--      here's a quick refresher: Functors are things that can be mapped over, like lists, Maybes, trees, and such. In Haskell, they're described by the typeclass Functor, which has only one typeclass method, namely fmap, 
--    which has a type of fmap :: (a -> b) -> f a -> f b. It says: give me a function that takes an a and returns a b and a box with an a (or several of them) inside it and I'll give you a box with a b (or several of them) inside it    


-- let's first see the Functor methods 
--   Let's see how IO is an instance of Functor. When we fmap a function over an I/O action

instance Functor IO where
   fmap f action = do 
     result <- action 
     return (f result)
