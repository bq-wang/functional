module TypeDefinitionsWithTypeParameters

// are we going to talk about the type parameters

// first syntax - a.k.a the 0Camel-Style syntax, type parameters are placed before the name of the type.
type 'a BinaryTree = 
    | BinaryNode of 'a BinaryTree * 'a BinaryTree
    | BinaryValue of 'a

let tree1 = 
    BinaryNode(
        BinaryNode (BinaryValue 1, BinaryValue 2),
        BinaryNode (BinaryValue 3, BinaryValue 4) )

// second syntax. a.k.a .NET-style syntax, type parameters in angle brackets after the type name.

type Tree<'a> = 
    | Node of Tree<'a> list
    | Value of 'a

let tree2 = 
    Node ([ Node( [Value "one"; Value "two"]);
          Node ([Value "three"; Value "four"]) ] )

// NOTE:
//   like the variable types, the names of the type parameters always start with a single quote (') followed by an alphanumeric name for that type 
// if multiple parameterized types are required
// type_parameterized = 'type_varia
// 


// REVIEW:
// variable type:
//
//let doNothing x = x
//val doNothing : 'a -> 'a
// the 'a is a variable type, which means even though the compiler does not yet know know the type, it knows that the type of the return value will be the same as the type of the argument, check the "Chapter 3 - Functional Programming"

// Function to print the binary tree
let rec printBinaryTreeValues x = 
    match x with 
    | BinaryNode(node1, node2) -> 
        printBinaryTreeValues node1
        printBinaryTreeValues node2
    | BinaryValue x -> 
        printf "%A, " x

// function to print the three
let rec printTreeValues x = 
    match x with 
    | Node l -> List.iter printTreeValues l
    | Value x -> 
        printf "%A, " x


// Print the results
printBinaryTreeValues tree1
printfn ""
printTreeValues tree2

