module DataParallelism

// wat will be covered in this chapter include the followig
//  1. what is data parallelism and how we can levereage the Data Parallelism 


(*

Data parallelism relies on executing a single function in parallel with varying data input . This breaks work into discrete units. So it can be processed in parallel. On separate threads. 
ensuring that work can be partitioned between the available processors

NOTE:
 a special note might be that the Parallel. namespace has been moved to the TPL libraries. which is called the System.Threading.Tasks;


Aslo note thato hociaheit  

e.g. 

open System.Threading
open System.Threading.Tasks

Parallel.For(0, 100, (printfn "%i"))


you might want to check on the MSDN on the PLINQ libraries 

   Running Queries On Multi-Core Processors:  http://msdn.microsoft.com/en-us/magazine/cc163329.aspx
   初识Parallel Extensions之PLINQ: http://kb.cnblogs.com/page/42583/
*)

(*

#r "System.Linq.ParallelEnumerable.dll"
#r "System.Core.dll"

*)
open System.Threading
open System.Threading.Tasks


Parallel.For(0, 100, (printfn "%i")) |> ignore 


// an live example of using the parallel libraries is that 

open System.Threading
let emails  =  ["robert@strangelights.com"; "jon@doe.com";
                "jane@doe.com"; "venus@cats.com" ]

do Parallel.ForEach(emails, (fun addr -> 
    // code to create and send email goes here 
    ())) |> ignore


(* 

following show how to create a thin wrapper of ParallelEnumerable  to make it more like the Seq module

*) 

//namespace Strangelights.Extensions

// you will need the System.Core.dll libraries in order to use the "ParallelEnumerable" class.
//#r "System.Core.dll"

open System
open System.Linq
open System.Threading.Tasks
open System.Collections
open System.Collections.Generic

// import a small number of functions from the ParallelLinq
module PSeq = 
    // helper function to convert an ordinary seq (IEnumerable) into a IParallelEnumerable
//    let asParallel list: IParallelEnumerable<_> = ParallelQuery.AsParallel(list)
    //  check the following for details 
//    let asParallel list: IParallelEnumerable<_> = ParallelQuery.AsParallel(list) 
    let asParallel (list : IEnumerable<_>) = ParallelEnumerable.AsParallel(list)
    // the parallel map function we going to test 
    let map f list  = ParallelEnumerable.Select(asParallel list, new Func<_, _>(f))
    // other parallel functions you may consider using 
    let reduce f list = ParallelEnumerable.Aggregate(asParallel list, new Func<_, _, _> (f))
    let fold f acc list = ParallelEnumerable.Aggregate(asParallel list, acc, new Func<_, _, _> (f))

(*

due to the points that you may need to pay for the overhead of the cost of starting the parllel items, you may observes that the fact that the when dealing with smaller set of items,  you may 
find the parallel one runs slower than the serialized one 

*) 

open System.Diagnostics
//open Strangelights.Extensions


// the number of samples to collect
let samples = 5

// the number of times to repeat each test within a sample 
let runs = 100

// this function provides the "work" , by enumerating over a 
// collection of a given size

let addSlowly x = 
    Seq.fold (fun acc _ -> acc + 1) 0 (seq { 1 .. x})

// tests the sequential map function by performing a map on a
// a list with the given number of items and performing the given
// number of opertions for each item.
// the map is then iterated, to force it to perform the work.
let testMap items ops = 
    Seq.map (fun _ -> addSlowly ops) (seq { 1 .. items } ) 
    |> Seq.iter (fun _ -> ())

let testPMap items ops = 
    PSeq.map (fun _ -> addSlowly ops) (seq { 1 .. items } ) 
    |> Seq.iter (fun _ -> ())


// test the parallel map functoin, works as above
let harness f items ops = 
    // run once to ensure everything is JITed
    f items ops
    // collect a list of results 
    let res = 
        [ for _ in 1 .. samples do 
            let clock = new Stopwatch()
            clock.Start()
            for _ in 1 .. runs do
                f items ops
            clock.Stop()
            yield clock.ElapsedMilliseconds]
    // calculate the average
    let avg = float (Seq.reduce (+) res) / (float samples)

    // output the results
    printf "Items %i , Ops %i," items ops
    Seq.iter (printf "%i," ) res
    printfn "%f" avg

// the parameters to use 
let itemsList = [10; 100; 200; 400; 800; 1000]
let opsList = [10; 100; 200; 400; 800; 1000]

// test the sequential function 
for items in itemsList do 
    for ops in opsList do 
        harness testMap items ops

// test the parallel function 
for items in itemsList do
    for ops in opsList do
        harness testPMap items ops