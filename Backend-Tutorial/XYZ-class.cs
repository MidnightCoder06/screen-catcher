/*

we’ll need to implement this IAutomobile interface. 
In C#, we must first clearly announce that a class implements an interface using the colon syntax:

*/

using System;

namespace LearnInterfaces
{
  // This Sedan class “promises” to implement the IAutomobile interface.
  class Sedan : IAutomobile
  {
    public string LicensePlate
    { get; }

    public double Speed
    { get; }

    public int Wheels
    { get; }

    public void Honk()
    { 
      Console.WriteLine("beep beep!");
     }
  }
}