module UsePInvoke_MessageBeep

// what will be covered in this chapter include the following 
//  1. how to use the message beep from the P/Invoke method 

open System.Runtime.InteropServices

(*

it is advised that you can find similar site to the following that 
http://pinvoke.net

*)

// declare a function found in an external .dll
[<DllImport("User32.dll")>]
extern bool MessageBeep(uint32 beepType)

// call this method ignoring the result 
MessageBeep(0ul) |> ignore
