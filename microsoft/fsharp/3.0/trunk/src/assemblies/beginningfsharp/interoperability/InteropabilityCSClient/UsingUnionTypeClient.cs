using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;

namespace InteropabilityCSClient
{
  //class UsingUnionTypeClient
  //{
  //}

  static class GetQuantityZeroClass
  {
    public static void GetQuantityZero()
    {
      // initialize both a Discrete and Continuous quantity 
      /* you cannot do the following, but 
      
      UseUnionType.Quantity d = UseUnionType.Quantity.Discrete(12);
      UseUnionType.Quantity c = UseUnionType.Quantity.Continuous(12.0);
      
      */


      /* but you are allowed to do the following 
       */
      UseUnionType.Quantity d = UseUnionType.Quantity.NewDiscrete(12);
      UseUnionType.Quantity c = UseUnionType.Quantity.NewContinuous(12.0);
    }
  }
}
