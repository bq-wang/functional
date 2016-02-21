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


  static class GetQuantityThreeClass
  {
    public static void GetQuantityThred()
    {
      // get a random quantity
      UseUnionType_EasyQuantity.EasyQuantity q = UseUnionType_EasyQuantity.getRandomEasyQuantity();
      // convert quantity to a float and show it 
      Console.WriteLine("Value as a float: {0}", q.ToFloat());

    }
  }
}
