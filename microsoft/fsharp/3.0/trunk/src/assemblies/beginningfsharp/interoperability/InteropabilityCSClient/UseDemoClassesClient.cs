extern alias fsharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fsharp::Microsoft.FSharp.Core;
using Strangelights;


namespace InteropabilityCSClient
{
  class UseDemoClassesClient
  {

    internal static void UseDemoClasses()
    {
      DemoClasses c = new DemoClasses(3);
      /* 
         it seems that you cannot invoke the FSharpFunction style with new compiler 
       */
      //FSharpFunc<int, int> ff = c.CurriedStyle(4, 4);
      //int result = ff.Invoke(5);
      int result = c.CurriedStyle(4, 4);
      Console.WriteLine("Curried Style Results {0}", result);
      result = c.TupleStyle(4, 5);
      Console.WriteLine("Tuple Style result {0}", result);
    }
  }
}
