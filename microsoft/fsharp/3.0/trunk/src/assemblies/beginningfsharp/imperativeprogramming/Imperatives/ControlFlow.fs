module ControlFlow

open System


// the If expression 
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Sunday then 
    printfn "Sunday playlist: lazy on A sunday afternoon - QUee"

if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Monday then 
    printfn "Monday Playlist: Blue MOnday - New Order"
else
    printfn "Alt Playlist: Fell in Love with a Girl - white Stripes"

if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Tuesday then
    printfn "Tuesday Playlist: Ruby Tuesday - Rolling Stones"
printfn "Everyday Playlist: Eight Days A week - Beatles"


// you can use the same indentation to group multiple statement to be part of the statement. 
if System.DateTime.Now.DayOfWeek = System.DayOfWeek.Friday then
    printfn "Friday Playlist : Firday I'm in love - The Cure"
    printfn "Friday Playlist : View from the Afternoon - Arctic Monkeys"

// the for expression 
// an array for words
// don't know what this is , but it does sound very strange
// let words = [| "Red"; "Lorry", "Yello", "Lorry"|]
//    [|("Red", "Lorry", "Yello", "Lorry")|]

let words = [| "Red"; "Lorry"; "Yello"; "Lorry";|]

// use a for loop to print each element
for  word in words do
    printfn "%s" word

// a Ryunosuke Akutagawa haiku aray 
let ryunosukeAkutagawa = [| "Green"; "frog,"; 
    "Is"; "Your"; "body"; "also";
    "freshly"; "painted?" |]

for index = 0 to Array.length ryunosukeAkutagawa - 1 do 
    printf "%s " ryunosukeAkutagawa.[index]

// a Shuson Kato haiku array (backwards)
let shusonKato = [| "watching."; "been"; "have";
    "children"; "three"; "my"; "realize"; "and";
    "ant"; "an"; "kill"; "I"; 
    |]

// loop over the array backwards printing each word 
for index = Array.length shusonKato - 1 downto 0 do 
    printf "%s" shusonKato.[index]



// the following are taken from the msdn 
// loops : for .. in Expression (F#)
// check this for examples: http://msdn.microsoft.com/en-us/library/dd233227.aspx
let list1 = [1; 5; 100; 450; 788]
for i in list1 do 
    printfn "%d" i

let seq1 = seq { for i in 1 .. 10 -> (i, i * i) } 

for (a, asqr) in seq1 do 
    printfn "%d squared is %d" a asqr

let function1() = 
    for i in 1 .. 10 do 
        printf "%d " i 
    printfn ""
function1()


// loop over a range skip of 2, 
let function2() = 
    for i in 1 .. 2 .. 10 do 
        printf "%d " i
    printfn ""
function2()


let function3() =
    for c in 'a' .. 'z' do 
        printf "%c " c
    printfn ""
function3()


let function4() = 
    for i in 10 .. -1 .. 1 do 
        printf "%d " i
    printfn "... left off !"

function4()

// beginning and ending of the range cna also be an expression, such as functions, as in the following code 
let beginning x y = x - 2 * y 
let ending x y = x + 2 * y 

let function5 x y = 
    for i in (beginning x y ) .. (ending x y ) do 
        printf "%d " i 
    printfn ""
function5 10 4

// the next one shows how to use the wildcards character (_)
let mutable count = 0
for _ in list1 do 
    count <- count + 1
printfn "Number of elements in list1: %d" count
