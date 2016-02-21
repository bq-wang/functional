-- file
--  repondPalindromes_io.hs
-- description:
-- respondPalindromes contents = unlines (map (\xs -> if isPalindrome xs then "palindrome" el
-- se "not a palindrome") (lines contents))
--     where   isPalindrome xs = xs == reverse xs
--
main = interact respondPalindromes

respondPalindromes = unlines . map (\xs -> if isPalindrome xs then "palindrome" else "not a palindrome") . lines 
    where   isPalindrome xs = xs == reverse xs

