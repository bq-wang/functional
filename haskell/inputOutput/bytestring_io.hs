-- file 
--  bytestring_io.hs
-- description:
--  bytestring is sorts of like lists, only each elements is one byte (or 8 bits) in size


import qualified Data.ByteString.Lazy as B
import qualified Data.ByteString as S


-- pack function has the following signature
-- ghci> B.pack [99,97,110]  
-- Chunk "can" Empty  
-- ghci> B.pack [98..120]  
-- Chunk "bcdefghijklmnopqrstuvwx" Empty  


-- unpack is the inverse function of pack, it takes a bytestring and turns it to a list bytes


-- fromChunks 
--  taks a list of stric bytestrings and converts it lazily bytestring. 

-- toChunks
--   takes a lazy bytestring and converts it to a list of strict ones.
-- ghci> B.fromChunks [S.pack [40,41,42], S.pack [43,44,45], S.pack [46,47,48]]  
-- Chunk "()*" (Chunk "+,-" (Chunk "./0" Empty))  


--  bytestring version of ':' is called cons
--   and cons' is an optimized version of cons

-- ghci> B.cons 85 $ B.pack [80,81,82,84]  
-- Chunk "U" (Chunk "PQRT" Empty)  
-- ghci> B.cons' 85 $ B.pack [80,81,82,84]  
-- Chunk "UPQRT" Empty  
-- ghci> foldr B.cons B.empty [50..60]  
-- Chunk "2" (Chunk "3" (Chunk "4" (Chunk "5" (Chunk "6" (Chunk "7" (Chunk "8" (Chunk "9" (Chunk ":" (Chunk ";" (Chunk "<"  
-- 													      Empty))))))))))  
-- ghci> foldr B.cons' B.empty [50..60]  



-- As you can see empty makes an empty bytestring.
--  empty [50 .. 60]
