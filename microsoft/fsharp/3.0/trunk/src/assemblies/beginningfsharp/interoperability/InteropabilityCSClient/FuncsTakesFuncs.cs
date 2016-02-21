extern alias fsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;
using fsharp::Microsoft.FSharp.Core;


namespace InteropabilityCSClient
{

  class MapOneClass
  {
    public static void MapOne()
    {
      // define a list of names
      List<string> names = new List<string>(
          new string[] { "Stefany", "Oussama", "Sebastien", "Frederick" }
        );
      // define a predicate delegate/function 
      Converter<string, bool> pred =
          delegate(string s) { return s.StartsWith("S"); };

      // convert to a FastFunc
      FSharpFunc<string, bool> ff =
        FuncConvert.ToFSharpFunc<string, bool>(pred);
      // call the F# demo function
      IEnumerable<string> results = FuncsTakesFuncs.filterStringList(ff, names);

      // write the results to the console
      foreach (var name in results)
      {
        Console.WriteLine(name);
      }
    }  
  }
}
