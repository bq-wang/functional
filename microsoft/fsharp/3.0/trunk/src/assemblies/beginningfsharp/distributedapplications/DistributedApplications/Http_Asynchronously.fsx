
// what will be covered in this chapter includes the following 
//    1. to make the exisitng code that retrieve and access data once per time to asynchronously with many workflows.

open System
open System.IO
open System.Net
open System.Text
open System.Xml
open System.Xml.XPath
open System.Globalization
open Microsoft.FSharp.Control.WebExtensions

// a record to hold details about a tweeter
type Tweeter = 
    { Id : int;
      Name: string;
      ScreenName : string;
      PictureUrl: string; } 

// turn the xaml stream into a strongly typed list of  tweeters

let treatTweeter name (stream: Stream) = 
    printfn "Processing: %s" name
    let xdoc = new XPathDocument(stream) 
    let nav = xdoc.CreateNavigator()
    let xpath = nav.Compile("users/user")
    let iter = nav.Select(xpath)
    let items = 
        [ for x in iter -> 
            let x = x :?> XPathNavigator
            let getvalue (nodeName: string) = 
                let node = x.SelectSingleNode (nodename)
                node.Value
            {
                Id = Int32.Parse(getValue "id");
                Name = getValue "name";
                ScreenName = getValue "screen_name";
                PictureUrl = getValue "profile_image_url"; } ]
    name, items
// function to make the urls of 
let friendsUrl = Printf.sprintf "http://twitter.com/statuses/friends/%s.xml"

// aynchronously get the friends of the tweeter
let getTweeters name =
    async { do printfn "Starting request for: %s" name
            let req = WebRequest.Create(friendsUrl name)
            use! resp = req.AsyncGetResponse()
            use stream = resp.GetResponseStream()
            return treatTweeter name stream }

// from a single twitter username get all the friends of friends of that user
let getAllFriendsOfFriends name = 
    // runt eh first user synchronously 
    let name, friends = Async.RunSynchronously (getTweeters name) 
    // only take the first 99 users since we're only allowed 100
    // requests an hour from the twitter servers
    let length = min 99 (Seq.length friends)
    // get he screen name of all the tweeter friends
    (* this is important *)
    let friendsScreenName = 
        Seq.take length (Seq.map (fun { ScreenName = sn } -> sn ) friends) // this is so-called pattern matching with variable-card pattern
    // create asynchronous workflows to get friends of friends
    let friendsOfFriendsWorkflows = 
        Seq.map (fun sn -> getTweeters sn) friendsScreenName
    // run this in parallel
    let fof = Async.RunSynchronously(Async.Parallel friendsOfFriendsWorkflows)
    // return the friends list and the fiends of friend list 
    friendsScreenName, fof