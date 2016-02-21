using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;


namespace InteropabilityCSClient
{
  //static class UseUnionTypeClientOne
  //{

  //}

  /*
   the key here is that you will first need to cast the the union type to the discriminate  type and then access the Item property.

   what is the simplest way to acces data of an F# discriminated union type in C#
   http://stackoverflow.com/questions/17254855/what-is-the-simplest-way-to-access-data-of-an-f-discriminated-union-type-in-c
   
   Using F# Discriminated Unions in C# (Beta2) 
   http://blogs.msdn.com/b/jaredpar/archive/2009/10/27/using-f-discriminated-unions-in-c-beta2.aspx
   */

  static class GetQuantityOneClass
  {

    public static void GetQuantityOne()
    {
      // get a random quantity 
      UseUnionType.Quantity q = UseUnionType.getRandomQuantity();

      // switch the .Tag property to switch over the quantity 
      switch (q.Tag)
      {
        case UseUnionType.Quantity.Tags.Discrete:
          //Console.WriteLine("Discrete value: {0}", UseUnionType.Quantity.Tags.Discrete);
          Console.WriteLine("Discrete value: {0}", ((UseUnionType.Quantity.Discrete) q).Item);
          break;
        case UseUnionType.Quantity.Tags.Continuous:
          //Console.WriteLine("Continuous value: {0}", q.ToString());
          Console.WriteLine("Continous value: {0}", ((UseUnionType.Quantity.Continuous) q).Item);
          break;
      }
    }
    
  }
}
