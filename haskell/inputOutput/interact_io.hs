-- file 
--  interact_io.hs
-- descrpition: 
--  interact takes a function of type String -> String as a parameter and returns an I/O action that will take some input, run that function on it and then print out the function's result.
main = interact shortLinesOnly  
  
shortLinesOnly :: String -> String  
shortLinesOnly input =   
    let allLines = lines input  
        shortLines = filter (\line -> length line < 10) allLines  
        result = unlines shortLines  
    in  result



-- main2 = interact $ unlines . filter ((<10) . length) . lines


-- respondPalindromes contents = unlines (map (\xs -> if isPalindrome xs then "palindrome" else "not a palindrome") (lines contents))  
--     where   isPalindrome xs = xs == reverse xs  
-- 

respondPalindromes = unlines . map (\xs -> if isPalindrome xs then "palindrome" else "not a palindrome") . lines  
    where   isPalindrome xs = xs == reverse xs  

main = interact respondPalindromes
