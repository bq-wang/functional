-- file 
--  sequence_io.hs
-- descrpition: 
--   the sequence  takes a list of I/O actions and returns an I/O actions that will perform those actions one after the other. 


-- main = do 
--     a <- getLine
--     b <- getLine  
--     c <- getLine  
--     print [a,b,c] 


main = do 
   rs <- sequence [getLine, getLine, getLine]
   print rs


-- below won't create an I/O action, it will create a list of I/O actions, because that is like writing 
-- map print [1, 2, 3, 4]
-- it is like 
-- [print 1, print 2, print 3, print 4]
sequence (map print [1,2,3,4,5])


-- but since that is so common, we have mapM and mapM_

-- ghci> mapM print [1,2,3]  
-- 1  
-- 2  
-- 3  
-- [(),(),()]  
-- ghci> mapM_ print [1,2,3]  
-- 1  
-- 2  
-- 3  
