extern alias fsharp;

using System;
//using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;
using fsharp::Microsoft.FSharp.Collections;
// where you can do the following as well.
//using fsharp.Microsoft.FSharp.Collections;
using fsharp::Microsoft.FSharp.Core;

/*
 the key here is that you must use the Microsoft.FSharp.Collections.FSharpList<int>.
*/


namespace InteropabilityCSClient
{
  class ReturnFSharpListClient
  {
    internal static void ReturnFSharpClientMain(string[] args)
    {
      // get the list of integers
      //List<int> ints = ReturnFSharpList.getList();
      FSharpList<int> ints = ReturnFSharpList.getList();

      // foreach over the list printing it 
      foreach (var i in ints)
      {
        Console.WriteLine(i);
      }
    }
  }
}
