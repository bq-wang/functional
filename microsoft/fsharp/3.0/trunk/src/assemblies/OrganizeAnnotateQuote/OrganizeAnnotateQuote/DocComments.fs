module DocComments

// in this chapter, we will cover the following 
//  1. how to create and use the "Doc Comment"
//  2. how to generate the doc.xml with the fsc command line 
// what is "Doc comment" - Doc comments allow you to extract comments from the source file in the form of XML or HTML

/// this is an explanation 

let myString = " this is a string" 


(*

the comand line is :

fsc --doc:doc.xml DocComments.fs 

the following are the content when you run 


<?xml version="1.0" encoding="utf-8"?>
<doc>
<assembly><name>DocComments</name></assembly>
<members>
<member name="P:DocComments.myString">
<summary>
 this is an explanation 
</summary>
</member>
<member name="T:DocComments">

</member>
</members>
</doc>


*)


(* though the compiler can generate the <summary> and </summary> 

but it also means that you can explicitly take control *)

/// <summary>
/// divides the given parameter by 10
/// </summary>
/// <param name="x"> the thing to be divied by 10 </param>
let divTen x = x / 10 


(*

<?xml version="1.0" encoding="utf-8"?>
<doc>
<assembly><name>DocComments</name></assembly>
<members>
<member name="M:DocComments.divTen(System.Int32)">
 <summary>
 divides the given parameter by 10
 </summary>
 <param name="x"> the thing to be divied by 10 </param>
</member>
<member name="T:DocComments">

</member>
</members>
</doc>
*)