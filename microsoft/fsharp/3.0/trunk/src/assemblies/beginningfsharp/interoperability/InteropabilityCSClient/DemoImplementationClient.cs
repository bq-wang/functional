extern alias fsharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fsharp::Microsoft.FSharp.Core;
using fsharp::Microsoft.FSharp.Collections;
using Strangelights;


namespace InteropabilityCSClient
{
  class DemoImplementation : IDemoInterface
  {
    // C# style implementation, named arguments
    // make no difference here
    public int CSharpNamedStyle(int x, int y)
    {
      return x + y;
    }

    // C# style implemenation 
    public int CSharpStyle(int x, int y)
    {
      return x + y;
    }

    // curried style implementation
    public int CurriedStyle(int x, int y)
    {
      // curried style implementation 
      // create a delegate to return 
      Converter<int, int> d = delegate(int z) { return x + z; };
      // convert delegate to a FSharpFunc
      return FuncConvert.ToFSharpFunc(d).Invoke(y);
    }

    // tuple style implementation
    public int TupleStyle(Tuple<int, int> t)
    {
      return t.Item1 + t.Item2;
    }
  }

  class DemoImplementationClient
  {
    internal static void DemoUseImplementation()
    {
      DemoImplementation impl = new DemoImplementation();
      int result = impl.CSharpNamedStyle(3, 5);
      Console.WriteLine("CSharpNamedStyle: {0}", result);

      result = impl.CSharpStyle(3, 5);
      Console.WriteLine("CSharpStyle: {0}", result);

      result = impl.CurriedStyle(3, 5);
      Console.WriteLine("CurriedStyle: {0}", result);

      result = impl.TupleStyle(new Tuple<int, int>(3, 5));
      Console.WriteLine("CurriedStyle: {0}", result);
    }
  }


}
