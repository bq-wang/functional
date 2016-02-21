module LogicalOrAndOperator

//  what we will cover in this chaper include the following 
//   1. the logical Or and And operator  (actually it is the bitwise and operator)


open System.Windows.Forms

let anchor = AnchorStyles.Left ||| AnchorStyles.Left


printfn "Test anchorStyle.Left: %b" (anchor &&& AnchorStyles.Left <> enum 0)

printfn "Test anchorStyle.Right: %b" (anchor &&& AnchorStyles.Right <> enum 0)
