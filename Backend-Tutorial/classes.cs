/*
Fields
We need to associate different pieces of data, like a size and name, to each Forest object. 
In C#, these pieces of data are called fields. 
Fields are one type of class member, which is the general term for the building blocks of a class.

Create fields like this:

class Forest {
  public string name;
  public int trees;
}

This might look similar to defining a variable. It is! Each field is a variable and it will have a different value for each object.

Once we create a Forest instance, we can access and edit each field with dot notation:

Forest f = new Forest();
f.name = "Amazon";
Console.WriteLine(f.name); // Prints "Amazon"
 
Forest f2 = new Forest();
f2.name = "Congo";
Console.WriteLine(f2.name); // Prints "Congo"
*/

/*
Properties
As of now, a program can plant any value in a Forest field. 
For example, if we had an area field of type int, we could set it to 0, 40, or -1249. 
Can we have a forest of -1249 area? We need a way to define what values are valid and disallow those that are not. 
C# provides a tool for that: properties.

Properties are another type of class member. 
Each property is like a spokesperson for a field: it controls the access (getting and setting) to that field. We can use this to validate values before they are set to a field. A property is made up of two methods:

a get() method, or getter: called when the property is accessed
a set() method, or setter: called when the property is assigned a value
This shows a basic Area property without validation:

public int area;
public int Area
{
  get { return area; }
  set { area = value; }
}
The Area property is associated with the area field. It’s common to name a property with the title-cased version of its field’s name, e.g. age and Age, name and Name.

The set() method above uses the keyword value, which represents the value we assign to the property. Back in Program.cs, when we access the Area property, the get() and set() methods are called:

Forest f = new Forest();
f.Area = -1; // set() is called
Console.WriteLine(f.Area); // get() is called; prints -1
In the above example, when set() is called, the value variable is -1, so area is set to -1.

Here’s the same property with validation in the set() method. If we try to set Area to a negative value, it will be changed to 0.

public int Area
{
  get { return area; }
  set 
  { 
    if (value < 0) { area = 0; }
    else { area = value; }
  }
}
In Program.cs:

Forest f = new Forest();
// set() is called
f.Area = -1; 
// get() is called; prints 0
Console.WriteLine(f.Area);



Automatic Properties
It might have felt tedious to write the same getter and setter for the Name and Trees properties. C# has a solution for that! The basic getter and setter pattern is so common that there is a short-hand called an automatic property. As a reminder, here’s the basic pattern for an imaginary size property:

public string size;
public string Size
{
  get { return size; }
  set { size = value; }
}
This pattern can be written as an automatic property:

public string Size
{ get; set; }
In this form, you don’t have to write out the get() and set() methods, and you don’t have to define a size field at all! A hidden field is defined in the background for us. All we have to worry about is the Size property.


Public vs. Private
At this point we have built fields to associate data with a class and properties to control the getting and setting of each field. As it is now, any code outside of the Forest class can “sneak past” our properties by directly accessing the field:

f.Age = 32; // using property
f.age = -1; // using field
The second line avoids the property’s validation by directly accessing the field. We can fix this by using the access modifiers public and private:

public — a public member can be accessed by any class
private — a private member can only be accessed by code in the same class


For example, since a class’ properties define how other programs get and set its fields, it’s good practice to make fields private and properties public.
*/

/*
Constructors
In each of the examples so far, we created a new Forest object and set the property values one by one. It would be nice if we could write a method that’s run every time an object is created to set those values at once.

C# has a special type of method, called a constructor, that does just that. It looks like a method, but there is no return type listed and the method name is the name of its enclosing class:

class Forest 
{
  public Forest()
  {
  }
}
We can add code in the constructor to set values to fields:

class Forest
{
  public int Area;
 
  public Forest(int area)
  {
    Area = area;
  }
}
This constructor method is used whenever we instantiate an object with the new keyword:

 // Constructor is called here
Forest f = new Forest(400);
But we’ve been instantiating new objects all day! Why did it work before we defined a constructor?

If no constructor is defined in a class, one is automatically created for us. It takes no parameters, so it’s called a parameterless constructor. That’s why we have been able to instantiate new objects without errors:

Forest f = new Forest();



We can refer to the current instance of a class with the this keyword.

class Forest
{
  public int Area
  {  ...  }
 
  public Forest(int area)
  {
    this.Area = area;
  }
}
this.Area = area means “when this constructor is used to make a new instance, use the argument area to set the value of this new instance’s Area field”.

We would call it the same way:

Forest f = new Forest(400);

*/

/*
Overloading Constructors
Just like other methods, constructors can be overloaded. 
For example, we may want to define an additional constructor that takes one argument:

public Forest(int area, string country)
{ 
  this.Area = area;
  this.Country = country;
 }
 
public Forest(int area)
{ 
  this.Area = area;
  this.Country = "Unknown";
}
The first constructor provides values for both fields, and the second gives a default value when the country is not provided. 
Now you can create a Forest instance in two ways:

Forest f = new Forest(800, "Africa");
Forest f2 = new Forest(400);
Notice how we’ve written duplicate code for our second constructor: this.Area = area;. Later on, if we need to adjust the constructor, we’ll need to find every copy of the code and make the exact same change. That means more work and chances for errors.

We have two options to resolve this. In either case we will remove the duplicated code:

Use default arguments. This is useful if you are using C# 4.0 or later (which is fairly common) and the only difference between constructors is default values.
public Forest(int area, string country = "Unknown")
{
  this.Area = area;
  this.Country = country;
}
2. Use : this(), which refers to another constructor in the same class. This is useful for old C# programs (before 4.0) and when your second constructor has additional functionality. This example has an additional functionality of announcing the default value.

public Forest(int area, string country)
{ 
  this.Area = area;
  this.Country = country;
}
 
public Forest(int area) : this(area, "Unknown")
{ 
  Console.WriteLine("Country property not specified. Value defaulted to 'Unknown'.");
}
Remember that this.Area refers to the current instance of a class. W
hen we use this() like a method, it refers to another constructor in the current class. 
In this example, the second constructor calls this() — which refers to the first Forest() constructor 
— AND it prints information to the console.

*/



// You already know how to create a field and property, like:

class Forest
{
  private string definition;
  public string Definition
  {
     get { return definition; }
     set { definition = value; }
   }
}

// To make a static field and property, just add static after the access modifier (public or private).

class Forest
{
  private static string definition;
  public static string Definition
  { 
    get { return definition; }
    set { definition = value; }
  }
}
/*
Remember that static means “associated with the class, not an instance”. 
Thus any static member is accessed from the class, not an instance:

static void Main(string[] args)
{
  Console.WriteLine(Forest.Definition);
}

If you tried to access a static member from an instance (like f.Definition) you would get an error like:
error CS0176: Static member 'Forest.Definition' cannot be accessed with an instance reference, qualify it with a type name instead

You already know how to create an instance method, like:

class Forest
{
  private string definition;
  public void Define()    
  {
    Console.WriteLine(definition);
  }
}
This behavior (printing a general definition) isn’t specific to any one instance — it applies to the class itself, 
so it should be made static.

To make a static method, just add static after the access modifier (public or private).

class Forest
{
  private static string definition;
  public static void Define()
  { 
    Console.WriteLine(definition); 
  }
}
Notice that we added static to both the field definition and method Define().

This is because a static method can only access other static members. It cannot access instance members:

class Forest
{
  private string definition;
  public static void Define()
  { 
    // Throws error because definition is not static
    Console.WriteLine(definition); 
  }
}
Otherwise, static methods work like any other method.
*/


/*
Static Constructors
An instance constructor is run before an instance is used, and a static constructor is run once before a class is used:

class Forest 
{
  static Forest()
  {  ...  }
}
This constructor is run when either one of these events occurs:

Before an object is made from the type.
Before a static member is accessed.
In other words, if this was the first line in Main(), a static constructor for Forest would be run:

Forest f  = new Forest();
It would also be run if this was the first line in Main():

Forest.Define();
Typically we use static constructors to set values to static fields and properties.

A static constructor does not accept an access modifier.
*/


////  Forest.cs

namespace StaticMembers
{
  class Forest
  {
    // FIELDS
    
    public int age;
    private string biome;
    private static int forestsCreated;
    private static string treeFacts;
    
    // CONSTRUCTORS
    
    // instance constructor
    public Forest(string name, string biome)
    {
      this.Name = name;
      this.Biome = biome;
      Age = 0;
      ForestsCreated++;
    }
    
    // static constructor 
    static Forest()
    {
      treeFacts = "Forests provide a diversity of ecosystem services including:\r\n  aiding in regulating climate.\r\n  purifying water.\r\n  mitigating natural hazards such as floods.\n";
      ForestsCreated = 0;
    }
    
    // PROPERTIES
    
    public string Name
    { get; set; }
    
    public int Trees
    { get; set; }
    
    public string Biome
    {
      get { return biome; }
      set
      {
        if (value == "Tropical" ||
            value == "Temperate" ||
            value == "Boreal")
        {
          biome = value;
        }
        else
        {
          biome = "Unknown";
        }
      }
    }
    
    public int Age
    { 
      get { return age; }
      private set { age = value; }
    }
    
    public static int ForestsCreated
    {
      get { return forestsCreated; }
      private set { forestsCreated = value; }
    }
    
    public static string TreeFacts
    {
      get { return treeFacts; }
    }
    
  }

}

////  Program.cs 


namespace StaticMembers
{
  class Program
  {
    static void Main(string[] args)
    {
      // you are calling the method without instantiating the class 
      Forest.PrintTreeFacts(); 
    }
  }
}

/*
Static Classes
We covered a few static members: field, property, method, and constructor. What if we made the whole class static?

static class Forest {}
A static class cannot be instantiated, so you only want to do this if you are making a utility or library, like Math or Console.

These two common classes are static because they are just tools — they don’t need specific instances and they don’t store new information.

Now when you see something like:

Math.Min(34, 54);
Console.WriteLine("yeehaw!");
You know that these are two static classes calling two static methods.



Common Static Errors
With great power comes great responsibility. If you plan on using static, you must be familiar with the errors you might cause! Here a few common ones:

This error usually means you labeled a static constructor as public or private, which is not allowed:

error CS0515: 'Forest.Forest()': static constructor cannot have an access modifier
This usually means you tried to reference a non-static member from a class, instead of from an instance:

error CS0120: An object reference is required to access non-static field, method, or property 'Forest.Grow()'
This usually means that you tried to reference a static member from an instance, instead of from the class:

error CS0176: Member 'Forest.TreeFacts' cannot be accessed with an instance reference; qualify it with a type name instead




Main()
Now that you’re familiar with classes, you’re ready to tackle the Main() method, the entry point for any program. You’ve seen it many times, but now you can explain every part!

class Program
{
  public static void Main (string[] args) 
  {
  }
}
Main() is a method of the Program class.
public — The method can be called outside the Program class.
static — The method is called from the class name: Program.Main().
void — The method means returns nothing.
string[] args — The method has one parameter named args, which is an array of strings.
Main() is like any other method you’ve encountered. It has a special use for C#, but that doesn’t mean you can’t treat it like a plain old method!

*/