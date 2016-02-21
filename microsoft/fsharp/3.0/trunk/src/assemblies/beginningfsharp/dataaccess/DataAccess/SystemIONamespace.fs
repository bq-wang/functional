module SystemIONamespace

// what will be covered in this chapter include the following 
// 1.  list files information 
// 2.  read file contents 
open System.IO

// list all the files in teh root of the C: drive 
let files = Directory.GetFiles(@"c:\")

// write out various information about the file 
for filepath in files do 
    let file = new FileInfo(filepath) 
    printfn "%s\t%d\t%O"
                file.Name
                file.Length
                file.CreationTime

open System.IO
// test.csv:
//Apples,12,25
//Oranges,12,25
//Bananas,12,25

// open a  test file and print the contents
let readFile() = 
    let lines = File.ReadAllLines("test.csv")
    let printline(line: string) = 
        let items = line.Split([|','|])
        printfn "%O %O %O" 
            items.[0]
            items.[1]
            items.[2]
    Seq.iter printline lines

do readFile()

(*


the output of of the file is like below: 

Apples 12 25
Oranges 12 25
Bananas 12 25

*)
