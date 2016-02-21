extern alias fsharp;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using fsharp::Microsoft.FSharp.Collections;
using Strangelights;

namespace InteropabilityCSClient
{
  //class UseUnionTypeClinetTwo
  //{
  //}


  static class GetQuantityTwoClass
  {
    public static void GetQuantityTwo()
    {
      // get a random quantity 
      UseUnionType.Quantity q = UseUnionType.getRandomQuantity();
      // use if ... else chain to display value 
      if (q.IsDiscrete)
      {
        Console.WriteLine("Discrete value: {0}", ((UseUnionType.Quantity.Discrete)q).Item);
      }
      else if (q.IsContinuous)
      {
        Console.WriteLine("Continuous value: {0}", ((UseUnionType.Quantity.Continuous)q).Item);
      }

    }
  }
}
