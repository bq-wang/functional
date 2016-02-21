-- let_in.hs
-- show the use of 'let' and 'in' keyword 


-- let bindings let you bind to variables anywhere and are expressions themselves, but are very local, so they don't span across guards
-- let bindings can be used for pattern matching.

cylinder :: (RealFloat a) => a -> a -> a  
cylinder r h = 
    let sideArea = 2 * pi * r * h  
        topArea = pi * r ^2  
    in  sideArea + 2 * topArea  


-- difference between 
-- let <bindings> in <expression> with "where" clause (or another term is "where bindings" )is that 
-- 
-- let recall that we said that if-else is an expression, so you can write
-- [if 5 > 3 then "Woo" else "Boo", if 'a' > 'b' then "Foo" else "Bar"]     

-- and you can write as follow
-- 4 * (if 10 > 5 then 10 else 0) + 2

-- with let, you can 
-- 4 * (let a = 9 in a + 1) + 2


-- [let square x = x * x in (square 5, square 3, square 2)]

-- semi-colons can help in some situations
-- (let a = 100; b = 200; c = 300 in a * b * c, let foo = "Hey"; bar = "there!" in foo ++ bar)

-- let can be used in pattern-matching, e.g.
-- (let (a,b,c) = (1,2,3) in a+b+c) * 100

-- yet another cmi func, but without "where bindings"
-- calcBmis :: (RealFloat a) => [(a, a)] -> [a]
-- calcBmis xs = [bmi | (w, h) <- xs, let bmi = w / h ^2]

-- call it this way
--   calcBmis [(90.0, 1.78)]

-- scope rules, let expression in the 'output' function (the part before |) and all predicates and sections that coming after of the binding
calcBmis :: (RealFloat a) => [(a, a)] -> [a]  
calcBmis xs = [bmi | (w, h) <- xs, let bmi = w /h ^ 2, bmi >= 25.0]

let zoot x y z = x * y + z
zoot 3 9 2

-- a NOTE: the 'in' keyword will confine the scope of the names, e.g. 
calcBmis :: (RealFloat a) => [(a, a)] -> [a]  
-- zoot 3 9 2
-- above will be visbile in the entire file
let boot x y z = x * y + z in boot 3 4 2
-- only visbile in the expression above
