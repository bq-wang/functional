module LanguageDefinition

// what will be covered in this chapter
//  1. we will  show you some of the language definition to show you how to parse a simple arithmetic language. 
//  2. the tool that we will use is the fslex and fsyacc.exe 


(*

the reason that we don't use the combinator, it will use its own extrual format using *, +, /, - to represetn 
the operations. An EBNF, Extended Backus-Naur form, definitoin of the language is shown in the following code 



an EBNT, Extendd Backus-Naur form, definition of hte language is shown in the following code 

*)

(*

digit = "1" | "2" | "3" | "4" | "5" | "6" | "7" | "8" | "9" | "0" ;
numpart = digit, {digit };
number ["-"], numpart, [".", numpart];
operator = "+" | "-" | "*" | "/" ;
character = "A" | "B" | "C" | "D" | "E" | "F" | "G"
            | "H" | "I" | "J" | "K" | "L" | "M" | "N"
            | "O" | "P" | "Q" | "R" | "S" | "T" | "U"
            | "V" | "W" | "X" | "Y" | "Z"
            | "a" | "b" | "c" | "d" | "e" | "f" | "g"
            | "h" | "i" | "j" | "k" | "l" | "m" | "n"
            | "o" | "p" | "q" | "r" | "s" | "t" | "u"
            | "v" | "w" | "x" | "y" | "z" | "_" ;
ident = character, {character };
ident or num = ident | number;

expression = ident or num;
             | [ "(" ] , ident or num , operator , ident or num , [ ")" ] ;

*)


(*
some of the epxression of the language is as follows. 


1 + 2


5.87 + (8.465 / 3.243)

*)



