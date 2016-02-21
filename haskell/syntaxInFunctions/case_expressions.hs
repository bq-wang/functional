-- let_in.hs
-- discuss the case expression in general
-- have I told you that the pattern-matching is syntactic sugar for case expression?

head' :: [a] -> a
head' [] = error "No head for empty list!"
head' (x:_) = x


-- rewrite with the case expression 
head'' :: [a] -> a
head'' xs = case xs of [] -> error "No head for empty list!"
                       (x: _) -> x

-- case expression of pattern -> result  
--                    pattern -> result  
--                    pattern -> result  
--                    ...  		       

-- case expression can be widely used.
-- pattern-matching on functino parameter only when you define functions
-- case exprssion can be used anywhere

describeList :: [a] -> String  
describeList xs = "The list is " ++ case xs of [] -> "empty."  
                                               [x] -> "a singleton list."   
                                               xs -> "a longer list."  
-- above can have "pattern-maching" in the middle of an expression
-- an equivalent one is like this:

describeList' :: [a] -> String
describeList' xs = "The list is " ++ what xs 
  where what [] = "empty."
        what [x] = "a singleton list."
        what xs = "a longer list."
