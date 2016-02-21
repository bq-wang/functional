module ExceptionsAndExceptionHandling

// Exceptions and Exception handling

// defining exceptions in F# is similar to defining a constrctor of a union type, and the syntax for handling exceptions is similiar to pattern matching

// to define an exception
// syntax:
//  exception exception_name of value_type_list
// value_type_list::= type [, * value_type_list ]

exception WrongSecond of int


// to use the exception, do this:
// syntax:
//    try
//      stmt
//    with
//      exception_pattern match 
//    [finally] 
// NOTE:
//  the syntax follows that of
//  trying to match an F# constructor from a union type.

//


// list of prime numbers
let primes = [2; 3; 5; 7; 11; 13; 17; 19; 23; 29; 31; 37; 41; 43; 47; 53; 59]

// function to test if current second is prime
let testSecond() = 
    try 
        let currentSecond = System.DateTime.Now.Second in
        // test if current second is in the list of primes
        if List.exists (fun x -> x = currentSecond) primes then
            // use the failwith function to raise an exception 
            failwith "A prime second"
        else
            // Raise the WrongSecond exception
            raise (WrongSecond currentSecond)
    with
    // catch the wrong second exception
    WrongSecond x ->
        printf "The current was %i, which is not prime" x

// call the function 
testSecond()


// function to write to a file
let writeToFile() =
    // open a file
    let file = System.IO.File.CreateText("test.txt")
    try
        // write to it
        file.WriteLine("Hello F# users")
    finally
        // close the file, this will happen even if 
        // an exception occurs writing to the file
        file.Dispose()

// call the function 
writeToFile()

let readFromFile() = 
    let file = System.IO.File.OpenText("test.txt")
    try
        let content = file.ReadLine()
        printf "%s" content
    finally
        file.Dispose()

readFromFile()