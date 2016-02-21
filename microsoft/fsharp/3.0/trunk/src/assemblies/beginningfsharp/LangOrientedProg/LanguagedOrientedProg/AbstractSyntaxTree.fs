//module AbstractSyntaxTree

// what will be covered in this chapter incldue the following 
//        1 the definition of some AST type that shall be used by other modules

namespace Strangelights.Expression

type Ast = 
    | Ident of string
    | Val of System.Double
    | Multi of Ast * Ast 
    | Div of Ast * Ast
    | Plus of Ast * Ast
    | Minus of Ast * Ast


