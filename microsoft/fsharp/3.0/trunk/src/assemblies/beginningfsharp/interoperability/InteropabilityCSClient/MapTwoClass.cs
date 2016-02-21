using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;


/*
 comparing to the filterStringListDelegate function, shown in the following, which you can use the C# anonymous delegate feature adn 
 embed the delegate directly into the function call.
 
 */

namespace InteropabilityCSClient
{
  class MapTwoClass
  {
    public static void MapTwo()
    {
        // define a list of names
      List<string> names = new List<string>(
          new string[] { "Aurelie", "Fabrice",
          "Ibrahima", "Lionel" });
      // call the F# demo  function in an 
      // anonymous delegate
      List<string> results =
          FuncsTakesFuncs.filterStringListDelegate(
            delegate(string s) { return s.StartsWith("A"); }, names);

      // write the results to the console
      foreach (var s in results)
      {
        Console.WriteLine(s);
      }
    }
  }
}
