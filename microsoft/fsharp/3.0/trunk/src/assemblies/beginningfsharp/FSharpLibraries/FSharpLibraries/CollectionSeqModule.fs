module CollectionSeqModule


// what will be covered in this chapter include 
//    1. the Collection.Seq


(*


the Microsoft.FSharp.Seq moduel contains functions that work with any collection that supports the IEnumerable itnerface. 

which is the most of the Collections in the .NET Framework 

*)



(*

a speical notes on the Seq module . 

􀀁Note FSLib contains several modules designed to work with various types of collections. These include Array,
Array2 (two-dimensional arrays), Array3 (three-dimensional arrays), Hashtbl (a hash table implementation),
IEnumerable, LazyList, List, Map, and Set. I’ll cover only Seq because it should generally be favored over these
collections because of its ability to work with lots of different types of collections. Also, although each module has
functions that are specific to it, many functions are common to them all.

*)


(*

as a general introduction, the following will be covered in the following sections *)




(*


map and iter: 

concat:
fold: 

exists and forall: 

filter, find and tryFind 

choose: perform a filter and map at the same time 
init and Infinite: initialize a collection 

unfold: provides a more flexible way to initialize lists 

cast: convert from non-negeneric of IEnumerable, rather than IEnumerable<T>
*)

