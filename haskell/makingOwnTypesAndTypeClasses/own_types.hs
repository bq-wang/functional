-- fie:
--  own_type.hs
-- description:
--  create your own types and type classes


-- Algebraic data types intro

--
-- data:

-- e.g. how the Bool type is defined.
data Bool = False | True
data Int = -2147483648 | -2147483647 | ... | -1 | 0 | 1 | 2 | ... | 2147483647  

-- e.g. suppose that we are defining shapes which could be a Circle or a Rectangle
--   
data Shape = Circle Float Float Float | Rectangle Float Float Float Float

-- 
-- value constructors:
--   Cirlce as well as Rectangle are like value contructors
-- Circle: Value contructors which takes 3 parameters
-- Rectangle: Value constructors which takes 4 parameters

:t Circle
:t Rectangle


-- make a function takes a Shape and returns something
surface :: Shape -> Float
surface (Circle _ _ r) = pi * r ^ 2
surface (Rectangle x1 y1 x2 y2) = (abs $ x2 - x1) * (abs $ y2 - y1)

-- surface $ Circle 10 20 10  
-- surface $ Rectangle 0 0 100 100


-- 
-- make Shape showable:
data Shape = Circle Float Float Float | Rectangle Float Float Float Float deriving (Show)

-- haskell automatically make "Shape" part of the Show typeeclass    

Circle 10 20 5
Rectangle 50 230 60 90

-- more usage on constructor as functions
map (Circle 10 20) [4, 5, 6, 6]

-- make it better
-- re-org the type classes

data Point = Point Float Float deriving (Show)
data Shape = Circle Point Float | Rectangle Point Point deriving (Show)

surface :: Shape -> Float
surface (Circle _ r) = pi * r ^ 2
surface (Rectangle (Point x1 y1) (Point x2 y2)) = (abs $ x2 - x1) * (abs $ y2 - y1)

surface (Rectangle (Point 0 0) (Point 100 100)) 
surface (Circle (Point 0 0) 24) 
    

-- yet anoter example
nudge :: Shape -> Float -> Float -> Shape
nudge (Circle (Point x y) r) a b = Circle (Point (x + a) (y + b)) r
nudge (Rectangle (Point x1 y1) (Point x2 y2)) a b = Rectangle (Point (x1+a) (y1+b)) (Point (x2+a) (y2+b))  

-- auxiliary functions to help dealing with Points    

baseCircle :: Float -> Shape
baseCircle r = Circle (Point 0 0) r

baseRect :: Float -> Float -> Shape
baseRect with height = Rectangle (Point 0 0) (Point width height)

-- nudge (baseRect 40 100) 60 23 
-- 


-- 
-- exports both the type and functions within
--  
-- client use our code will by deafult import Rectangle, Circle and others without doing
-- Shape (Rectangle, Circle)
module Shapes 
( Point(..) -- all the value constructors for Shape 
, Shape(..) 
, surface
, nudge
, baseCircle
, baseRect
) where

--
-- Record Syntax :
--     what is this all about?

data Person = Person String String Int Float String String deriving (Show)  
let guy =  Person "Buddy" "Finklestein" 43 184.2 "526-2928" "Chocolate"  

-- kind of cool
-- NOTE
--  please see the rest of Person definition in the file Person.hs


