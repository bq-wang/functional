
// what will be covered in this chapter include the following 

namespace Strangelights.WebService

open System.Web.Services

[<WebService(Namespace = "http://strangelights.com/FSharp/Foundations/WebServices")>]
type Service = 
    inherit WebService 
    new() = {}
    [<WebMethod(Description = "Performs integer additoin")>]
    member w.Addition ((x: int), (y : int)) = x + y 

