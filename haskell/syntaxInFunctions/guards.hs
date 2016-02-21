-- guard 
-- Whereas patterns are a way of making sure a value conforms to some form and deconstructing it, guards are a way of testing whether some property of a value (or several of them) are true or false.



-- Guard case 
--   Guards returns true or false
--   it is a boolean expression
bmiTell :: (RealFloat a ) => a -> String
bmiTell bmi
  | bmi <= 18.5 = "You're underweight, you emo, you!"
  | bmi <= 25.0 = "You're supposedly normal. Pffft, I bet you're ugly!"  
  | bmi <= 30.0 = "You're fat! Lose some weight, fatty!"
  | otherwise = "You're a whale, congratulations!"  

bmiTell' :: (RealFloat a) => a -> a -> String  
bmiTell' weight height  
    | weight / height ^ 2 <= 18.5 = "You're underweight, you emo, you!"  
    | weight / height ^ 2 <= 25.0 = "You're supposedly normal. Pffft, I bet you're ugly!"  
    | weight / height ^ 2 <= 30.0 = "You're fat! Lose some weight, fatty!"  
    | otherwise                 = "You're a whale, congratulations!"  


max' :: (Ord a) => a -> a -> a
max' a b 
  | a > b = a
  | otherwise = b

-- can write in one line 
-- max' :: (Ord a) => a -> a -> a  
-- max' a b | a > b = a | otherwise = b  

-- how the compare function are implemented

myCompare :: (Ord a) => a -> a -> Ordering
a `myCompare` b 
  | a > b = GT
  | a == b = EQ
  | otherwise = LT

-- 3 `myCompare` 2


-- the "where" clause in guard 
-- let's rewrite the bmiTell function

bmiTell'' :: (RealFloat a) => a -> a -> String  
bmiTell'' weight height  
    | bmi <= 18.5 = "You're underweight, you emo, you!"  
    | bmi <= 25.0 = "You're supposedly normal. Pffft, I bet you're ugly!"  
    | bmi <= 30.0 = "You're fat! Lose some weight, fatty!"  
    | otherwise   = "You're a whale, congratulations!"  
    where bmi = weight / height ^ 2  

-- We put the keyword where after the guards (usually it's best to indent it as much as the pipes are indented) and then we define several names or functions. 
-- These names are visible across the guards and give us the advantage of not having to repeat ourselves.
-- the names are only visible to that function


-- 
bmiTell3 :: (RealFloat a) => a -> a -> String  
bmiTell3 weight height  
    | bmi <= skinny = "You're underweight, you emo, you!"  
    | bmi <= normal = "You're supposedly normal. Pffft, I bet you're ugly!"  
    | bmi <= fat    = "You're fat! Lose some weight, fatty!"  
    | otherwise     = "You're a whale, congratulations!"  
    where bmi = weight / height ^ 2  
          skinny = 18.5  
          normal = 25.0  
          fat = 30.0  

-- where binding in "pattern matching!"
initials :: String -> String -> String  
initials firstname lastname = [f] ++ ". " ++ [l] ++ "."  
    where (f:_) = firstname  
          (l:_) = lastname 
-- initials "joe" "wang"

-- stay tuned, how to define function inside the "where" clause

calcBmis :: (RealFloat a) => [(a, a)] -> [a]
calcBmis xs = [bmi w h | (w, h) <- xs]
  where bmi weight height = weight / height ^ 2

-- in code above, bmi is defined inside the function 'calcBmis'



