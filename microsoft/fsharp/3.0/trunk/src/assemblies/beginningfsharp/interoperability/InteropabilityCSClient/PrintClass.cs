extern alias fsharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;
// you will need to add reference to the FSharp.Core.dll
//using Microsoft.FSharp.Core;
//using Tuple = fsharp::System.Tuple;
//using SetModule = fsharp::Microsoft.FSharp.Collections.SetModule;



namespace InteropabilityCSClient
{
  static class PrintClass
  {
    internal static void HourMinute()
    {
      // call the "hourAndMinute" function collct the 
      // tuple that's returned 
      Tuple<int, int> t = DemoModule.hourAndMinute(DateTime.Now);
      // print the tuples' content 
      Console.WriteLine("Hour {0} Minute {1}", t.Item1, t.Item2);
    }
  }
}
