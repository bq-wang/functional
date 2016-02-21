using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Strangelights;


namespace InteropabilityCSClient
{
  class DefiningTypesInNamespacesClient
  {
    internal static void UseTheClass()
    {
      // create a list of classes
      List<TheClass> theClasses = new List<TheClass>() { 
        new TheClass(5),
        new TheClass(6),
        new TheClass(7),

      };

      // increment the list 
      TheModule.incList(theClasses);

      // write out each value in the list 
      foreach (TheClass c in theClasses)
      {
        Console.WriteLine(c.TheField);
      }
    }
  }
}
