/*

With inheritance, you can define one superclass that contains the shared members (like SpeedUp() and SlowDown()). 
All classes that need those members can inherit them from the superclass.

In inheritance, one class inherits the members of another class. 
The class that inherits is called a subclass or derived class. The other class is called a superclass or base class.

In our car example, Sedan and Truck are subclasses (or derived classes). 
They will inherit members from a new class called Vehicle, which is the superclass (or base class).

The only rule is that a class can only inherit from one base class, e.g. Vehicle can’t inherit from Machine and Contraption.
*/

// A superclass is defined just like any other class:
class Vehicle
{

}

// And a subclass inherits, or “extends”, a superclass using colon syntax (:):
class Sedan : Vehicle
{
}

// A class can extend a superclass and implement an interface with the same syntax. 
// Separate them with commas and make sure the superclass comes before any interfaces:
class Sedan : Vehicle, IAutomobile
{
}

// The above code means that Sedan will inherit all the functionality of the Vehicle class, 
// and it “promises” to implement all the functionality in the IAutomobile interface.




Access Inherited Members with Protected
While working on Vehicle and Sedan, you may have seen this error:

Sedan.cs(11,13): error CS0200: Property or indexer 'Vehicle.Wheels' cannot be assigned to -- it is read only
Remember public and private? A public member can be accessed by any code outside of the enclosing class. A private member can only be accessed by code within the same class.

The above error comes up because either:

There is no setter for Vehicle.Wheels, or
The setter is private
How do we fix this problem? Making the setter public is not secure. Making it private is too restrictive – we only want the subclass Sedan to access the property. C# has another access modifier to solved that: protected!

A protected member can be accessed by the current class and any class that inherits from it. In this case, if the setter for Vehicle.Wheels is protected, then any Vehicle, Truck, and Sedan instance can call it.


Access Inherited Members with Base
To construct a Sedan, we must first construct an instance of its superclass Vehicle.

We can refer to a superclass inside a subclass with the base keyword.

For example, in Sedan:

base.SpeedUp();
refers to the SpeedUp() method in Vehicle.

There’s special syntax for calling the superclass constructor:

class Sedan : Vehicle
{
  public Sedan (double speed) : base(speed)
  {
  }
}
The above code shows a Sedan that inherits from Vehicle. The Sedan constructor calls the Vehicle constructor with one argument, speed. This works as long as Vehicle has a constructor with one argument of type double.

Even if we don’t use base() in Sedan, it will call a Vehicle constructor. Without an explicit call to base(), any subclass constructor will implicitly call the default parameterless constructor for its superclass. For example, this code implicitly calls Vehicle():

class Sedan : Vehicle
{
  // Implicitly calls base(), aka Vehicle()
  public Sedan (double speed)
  {
  }
}
The above code is equivalent to this:

{
  public Sedan (double speed) : base()
  {
  }
}
This code will ONLY work if the constructor Vehicle() exists. If it doesn’t, then an error will be thrown.

////

Override Inherited Members
Say that we wanted to make one more vehicle that operates a bit differently than a sedan or truck. We want to use most of the members in Vehicle, but we need to write new versions of SpeedUp() and SlowDown().

What we want is to override an inherited method. To do that, we use the override and virtual modifiers.

In the superclass, we mark the method in question as virtual, which tells the computer “this member might be overridden in subclasses”:

public virtual void SpeedUp()
In the subclass, we mark the method as override, which tells the computer “I know this member is defined in the superclass, but I’d like to override it with this method”:

public override void SpeedUp()
As an aside: there’s another way to solve this problem. Instead of using virtual and override to override a member, we can define a new member with the same name. Essentially, the inherited member still exists, but it is “hidden” by the member in the subclass. If this sounds confusing, that’s okay! We also think it leads to unnecessary confusion, and that leads to errors. We’re going to stick with the virtual - override approach in this lesson.


////

Make Inherited Members Abstract
Now we want to add one more method to Vehicle called Describe(). It will be different for every subclass, so there’s no point in defining a default one in Vehicle. Regardless, we want to make sure that it is implemented in each subclass.

This might sound similar to an interface. Why not add this method to the IAutomobile interface? We want Describe() to be available to all vehicles, not just automobiles.

To do this we need one more modifier: abstract. This line would go into the Vehicle class:

public abstract string Describe();
This is like the Vehicle class telling its subclasses: “If you inherit from me, you must define a Describe() method because I won’t be giving you any default functionality to inherit.” In other words, abstract member have no implementation in the superclass, but they must be implemented in all subclasses.

If one member of a class is abstract, then the class itself can’t really exist as an instance. Imagine calling Vehicle.Describe(). It doesn’t make sense because it doesn’t exist! This means that the entire Vehicle class must be abstract. Label it with abstract as well:

abstract class Vehicle
If you don’t do this, you’ll get an error message like this:

error CS0513: 'Vehicle.Describe()' is abstract but it is contained in non-abstract class 'Vehicle'
Once we write the abstract method and mark the class as abstract, we’ll need to actually implement it in each subclass. For example in Sedan:

public override string Describe()
{
  return $"This Sedan is moving on {Wheels} wheels at {Speed} km/h, with license plate {LicensePlate}.";
}
To make it clear that this Describe() method in Sedan is overriding the Describe() method in Vehicle, we will need label it override.



/////


Review
Well done! You learned a lot very quickly, so let’s do a review:

Inheritance is a way to avoid duplication across multiple classes.
In inheritance, one class inherits the members of another class.
The class that inherits is called a subclass or derived class. The other class is called a superclass or base class.
We can access a superclass’ members using base. This is very useful when calling the superclass’ constructor.
We can restrict access to a superclass and its subclasses using protected.
We can override a superclass member using virtual and override.
We can make a member in a superclass without defining its implementation using abstract. This is useful if every subclass’ implementation will be different.
