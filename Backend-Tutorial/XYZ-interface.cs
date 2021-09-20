/*
The interface is a set of properties, methods, and other members. 
They are declared with a signature but their behaviors are not defined. 
A class implements an interface if it defines those properties, methods, and other members.

Every interface should have a name starting with “I”. 
This is a useful reminder to other developers and our future selves that this is an interface, not a class. 
We can add members, like properties and methods, to the interface. 

An interface is a set of actions and values, but it doesn’t specify how they work.

Just like classes, interfaces are best organized in their own files.

The interface says what a class MUST have. It does not say what a class MUST NOT have.

In fact, interfaces cannot specify two types of members that are commonly found in classes:

Constructors
Fields
*/

using System;

namespace LearnInterfaces
{
  interface IAutomobile
  {
    string LicensePlate { get; }
    double Speed { get; }
    int Wheels { get; }
    void Honk();
  }
}