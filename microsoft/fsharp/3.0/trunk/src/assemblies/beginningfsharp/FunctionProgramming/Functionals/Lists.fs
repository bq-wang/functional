module Lists

// essentials
//   []
//   ::
//   ;
//   @    concatenate two lists
let emptyList = []
let oneItem = "one" :: []
let twoItem = "one" :: "two" :: []



let shortHand = ["apples"; "pears"]

let twoLists = ["one, "; "two," ] @ ["buckle"; "my "; "shoe"]


// the empty list 
let emptyList = []

// list of one item 
let oneItem = "one " :: []

// list of two items 
let twoItem = "one " :: "two" :: []

// list of two items
let shortHand = ["apples "; "pairs "]

// concatenation of two lists 
let twoLists = ["one, "; "two, "] @ ["buckle "; "my "; "shoe "]

// list of object 
let objList = [box 1; box 2.9; box "three"]


// print the lists 
let main() = 
    printfn "%A" emptyList
    printfn "%A" oneItem
    printfn "%A" twoItem
    printfn "%A" shortHand
    printfn "%A" twoLists
    printfn "%A" objList

