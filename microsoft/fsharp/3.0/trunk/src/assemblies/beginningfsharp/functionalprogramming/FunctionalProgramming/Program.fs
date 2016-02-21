// Learn more about F# at http://fsharp.net

module Program
// some strings
let message = "Hello
World\r\n\t"

let dir  = @"c:\projects"

// a byte array 
let bytes = "bytesbytesbytes"B

// Some numeric types
let xA = 0xFFy
let xB = 0o7777un
let xC = 0b100010UL


// print the results
let main() = 
    printfn "%A" message
    printfn "%A" dir
    printfn "%A" bytes
    printfn "%A" xA
    printfn "%A" xB
    printfn "%A" xC

main()