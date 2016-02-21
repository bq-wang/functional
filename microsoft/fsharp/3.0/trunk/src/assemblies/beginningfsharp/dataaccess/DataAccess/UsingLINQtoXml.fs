module UsingLINQtoXml

// what will be covered in this chapter include the following
//  1. how to use Linq to XML to create XML by an example 

(*

In this chapter, we will introduce /rewrite the code we shown in "IntroducingLINQ.fs"


*)

// you will need to add a reference to System.Xml.Linq
// you will need to add a reference to System.Xml
#r "System.Xml.dll"
#r "System.Xml.Linq.dll"

open System
open System.Reflection
open System.Xml.Linq
open System.Linq


// define easier access to LINQ methods
let select f s = Enumerable.Select(s, new Func<_,_>(f))
let where f s = Enumerable.Where(s, new Func<_,_>(f))
let groupBy f s = Enumerable.GroupBy(s, new Func<_,_>(f))
let orderBy f s = Enumerable.OrderBy(s, new Func<_,_>(f))
let count s = Enumerable.Count(s)


// query string methods using functions
let namesByFunction =
    (typeof<string>).GetMethods()
        |> where (fun m -> not m.IsStatic)
        |> groupBy (fun m -> m.Name)
        |> select (fun m -> new XElement(XName.Get(m.Key), count m))
        |> orderBy (fun e -> int e.Value)

// create an xml document with the overloads data
let overloadsXml =
    new XElement(XName.Get("MethodOverloads"), namesByFunction)

// print the xml string
printfn "%s" (overloadsXml.ToString())

(*

the output of the program is like this: 
  <MethodOverloads>
  <get_Chars>1</get_Chars>
  <CopyTo>1</CopyTo>
  <GetHashCode>1</GetHashCode>
  <get_Length>1</get_Length>
  <TrimStart>1</TrimStart>
  <TrimEnd>1</TrimEnd>
  <Contains>1</Contains>
  <ToLowerInvariant>1</ToLowerInvariant>
  <ToUpperInvariant>1</ToUpperInvariant>
  <Clone>1</Clone>
  <Insert>1</Insert>
  <GetTypeCode>1</GetTypeCode>
  <GetEnumerator>1</GetEnumerator>
  <GetType>1</GetType>
  <ToCharArray>2</ToCharArray>
  <Substring>2</Substring>
  <Trim>2</Trim>
  <IsNormalized>2</IsNormalized>
  <Normalize>2</Normalize>
  <CompareTo>2</CompareTo>
  <PadLeft>2</PadLeft>
  <PadRight>2</PadRight>
  <ToLower>2</ToLower>
  <ToUpper>2</ToUpper>
  <ToString>2</ToString>
  <Replace>2</Replace>
  <Remove>2</Remove>
  <Equals>3</Equals>
  <EndsWith>3</EndsWith>
  <IndexOfAny>3</IndexOfAny>
  <LastIndexOfAny>3</LastIndexOfAny>
  <StartsWith>3</StartsWith>
  <Split>6</Split>
  <IndexOf>9</IndexOf>
  <LastIndexOf>9</LastIndexOf>
</MethodOverloads>

*)
