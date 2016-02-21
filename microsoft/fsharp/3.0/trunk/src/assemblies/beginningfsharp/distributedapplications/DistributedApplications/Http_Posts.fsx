
// what will be covered in this chapter include the following

open System
open System.Net
open System.Text

let postTweet username password tweet = 
    // create a token to authenticate
    let (token: string) = username + ":" + password
    let user = Convert.ToBase64String(Encoding.UTF8.GetBytes(token))
    // determine what we wnat to upload as a status 
    let bytes = Encoding.ASCII.GetBytes("status=" + tweet)
    // connect with the updates page
    let request = 
        WebRequest.Create("http://twitter.com/statuss/update.xml",
                         Method = "POST",
                         ContentLength = Convert.ToInt64(bytes.Length),
                         ContentType = "application/x-www-form-urlendcoded")
                         :?> HttpWebRequest

    request.ServicePoint.Expect100Continue <- false

    //set the authorisation levels
    request.Headers.Add("Authorization", "Basic " + user)
    

    // set up the stream
    use reqStream = request.GetRequestStream()
    reqStream.Write(bytes, 0, bytes.Length) 
    reqStream.Close()

postTweet "you" "xxx" "Test tweet from F# interactive"
