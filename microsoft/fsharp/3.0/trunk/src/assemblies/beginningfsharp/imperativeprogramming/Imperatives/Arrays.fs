module Arrays

// Arrays are mutalbe collection type in F#.

// Array synatx: 
//   defines: an array with [|, close the defines with |], element separate by ;
//   access  : .[]
//   update:  <- 


// define an array literal

let rhymeArray = 
    [| "Went to market";
        "stayed  home";
        "had roast beef";
        "had non"|]

// unpack the array into identifier
let firstPiggy = rhymeArray.[0]
let secondPiggy = rhymeArray.[1]
let thirdPiggy = rhymeArray.[2]
let fourthPiggy = rhymeArray.[3]


// update elements of the array 
rhymeArray.[0] <- "Wee,"
rhymeArray.[1] <- "Wee,"
rhymeArray.[2] <- "Wee,"
rhymeArray.[3] <- "all the way home"


// give a short name to the new line characters
let nl = System.Environment.NewLine

// print out the identifiers & array 
printfn "%s%s%s%s%s%s%s"
    firstPiggy nl
    secondPiggy nl
    thirdPiggy nl
    fourthPiggy

printfn "%A" rhymeArray

// multidimensional arrays in F# come in two, slightly different flavors: jagged and rectangular.

// define a jagged array literals

let jagged = [| [| "one" |]; [| "two"; "three"|] |]

// unpack elements from the arrays

let singleDim = jagged.[0]
let itemOne = singleDim.[0]
let itemTwo = jagged.[1].[0]

// print some of the unpacked elements
printfn "%s %s" itemOne itemTwo

// define a rectangular arrays

// create a square array
// inially populated with zeros
let square = Array2D.create 2 2 0

// populate the array
square.[0, 0] <- 1
square.[0, 1] <- 2
square.[1, 0] <- 3
square.[1, 1] <- 4

// print the array
printfn "%A" square 


// define Pascal's Triagnle as an 
// array literal

let pascalsTriangle = 
    [| [|1|];
       [|1; 1|];
       [|1; 2; 1|];
       [|1; 3; 3; 1|];
       [|1; 4; 6; 4; 1;|];
       [|1; 5; 10; 10; 5; 1|];
       [|1; 6; 15; 20; 15; 6; 1|];
       [|1; 7; 21; 35; 35; 21; 7; 1|];
       [|1; 8; 28; 56; 70; 56; 28; 8; 1|]; |]

// collect elements from the jagged array 
// assigning them to the square array 

let numbers = 
    let length = (Array.length pascalsTriangle) in 
    let temp = Array2D.create 3 length 0 in 
    for index = 0 to length - 1 do
        let naturalIndex = index - 1 in
        if naturalIndex >= 0 then 
            temp.[0, index] <- pascalsTriangle.[index].[naturalIndex]
        let triangularIndex = index - 2 in 
        if triangularIndex >= 0 then 
            temp.[1, index] <- pascalsTriangle.[index].[triangularIndex]
        let tetrahedralIndex = index - 3 in 
        if tetrahedralIndex >= 0 then 
            temp.[2, index] <- pascalsTriangle.[index].[tetrahedralIndex]
    done
    temp

// print the array 
printfn "%A" numbers

// the type of temp is val numbers : int [,]

