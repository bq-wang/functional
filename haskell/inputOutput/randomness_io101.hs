-- file : 
--  randomness_io101.hs
-- description:
--  this is a file which will demonstrate the use of randomness functions


import System.Random

-- random :: (RandomGen g, Random a) => g -> (a, g). random :: (RandomGen g, Random a) => g -> (a, g). 
-- to get an standard random generator, you can use the "mkStdGen" function as below 
--

-- random (mkStdGen 100) 


-- ghci> random (mkStdGen 100) :: (Int, StdGen)  
-- (-1352021624,651872571 1655838864)  
-- 
-- -- and if we give the same Random generator
-- ghci> random (mkStdGen 100) :: (Int, StdGen)  
-- (-1352021624,651872571 1655838864)  

-- constue on the return result of the textual representation of the randomness
-- the first component of the tuple is our number whereas the second component is a textual representation of our new random generator. 

-- more on this random generator

-- ghci> random (mkStdGen 949488) :: (Float, StdGen)  
-- (0.8938442,1597344447 1655838864)  
-- ghci> random (mkStdGen 949488) :: (Bool, StdGen)  
-- (False,1485632275 40692)  
-- ghci> random (mkStdGen 949488) :: (Integer, StdGen)  
-- (1691547873,1597344447 1655838864)  


threeCoins :: StdGen -> (Bool, Bool, Bool)  
threeCoins gen =   
    let (firstCoin, newGen) = random gen  
        (secondCoin, newGen') = random newGen  
        (thirdCoin, newGen'') = random newGen'  
    in  (firstCoin, secondCoin, thirdCoin)  


-- ghci> threeCoins (mkStdGen 21)  
-- (True,True,True)  
-- ghci> threeCoins (mkStdGen 22)  
-- (True,False,True)  
-- ghci> threeCoins (mkStdGen 943)  
-- (True,False,True)  
-- ghci> threeCoins (mkStdGen 944)  
-- (True,True,True)  


-- : randoms

-- return a infinite set of randoms 
-- ghci> take 5 $ randoms (mkStdGen 11) :: [Int]  
-- [-1807975507,545074951,-1015194702,-1622477312,-502893664]  
-- ghci> take 5 $ randoms (mkStdGen 11) :: [Bool]  
-- [True,True,True,True,False]  
-- ghci> take 5 $ randoms (mkStdGen 11) :: [Float]  
-- [7.904789e-2,0.62691015,0.26363158,0.12223756,0.38291094]  


-- g, a and n are like alias to the typeclass of 
--  RandomGen, Random and Num
finiteRandoms :: (RandomGen g, Random a, Num n) => n -> g -> ([a], g)
finiteRandoms 0 gen = ([], gen)
finiteRandoms n gen =
  let (value, newGen) = random gen
      (restOfList, finalGen) = finiteRandoms(n - 1) newGen
  in (value: restOfList, finalGen)

-- call with the following methods 
--    finiteRandoms 5 (mkStdGen 11) :: ([Int], StdGen)
-- *Main System.Random> finiteRandoms 5 (mkStdGen 11) :: ([Int], StdGen)
-- ([5258698905265467991,-1046130112415077602,3603401487739301952,-595625523242114439,-242088768969841391],912247095 2118231989)


-- randomR (1, 6) (mkStdGen 359353)
-- ghci> randomR (1,6) (mkStdGen 359353)  
-- (6,1494289578 40692)  
-- ghci> randomR (1,6) (mkStdGen 35935335)  
-- (3,1250031057 40692) 

-- take 10 $ randomRs ('a','z') (mkStdGen 3) :: [Char]  
