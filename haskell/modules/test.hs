import Data.Char (chr, ord)

-- the test before
encode :: Int -> String -> String
encode shift msg = 
  let ords = map ord msg
      shifted = map (+shift) ords
  in map chr shifted
