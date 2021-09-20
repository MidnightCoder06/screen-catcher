References of the Same Type
Classes are reference types. That means that when we create a new instance of a class and store it in a variable, the variable is a reference to the object.

Let’s see what’s happening behind the scenes. When this code is run:

Dissertation diss1 = new Dissertation();
A new Dissertation instance is constructed and stored in the computer’s memory. You can imagine a slot in your computer holding the instance’s type, property values, etc. diss1 is a reference to that location in memory.

diss1 is not the actual object, it is a reference to the object. Thus an object can have multiple references:

Dissertation diss1 = new Dissertation();
Dissertation diss2 = diss1;

Now there are two references to the same location in memory: we can say that diss1 and diss2 refer to the same object. If changes are made to that object, then they will be reflected in both references to it:

Dissertation diss1 = new Dissertation();
Dissertation diss2 = diss1;
diss1.CurrentPage = 0;
diss2.CurrentPage = 16;
Console.WriteLine(diss1.CurrentPage);
Console.WriteLine(diss2.CurrentPage);

The middle two lines of this code are setting the CurrentPage property of the same object (first setting it to 0, then 16)
The last two lines will print the same value, 16
You can imagine references like directions to a house: they tell you where to find the house, but they are not the house itself!


////////


References vs. Values
To better grasp the idea of reference types, let’s look at the other kind of type: value types. While reference-type variables refer to a place in memory, value-type variables hold the actual data.

int is a value type, so the variable num holds the value 6:

int num = 6;
Reference types, on the other hand, refer to a location in memory. Every class is a reference type, so the variable diss refers to a location in memory that has the Dissertation object:

Dissertation diss = new Dissertation(50);
Every “primitive” data type is a value type, including:

int
double
bool
char
Revisiting our metaphor: a reference is like directions to a house, which “points” to a house. It isn’t the actual house. A value type is the house itself!

You might have noticed that string is missing here. It works a bit differently, so it will be covered in a later lesson.


/////

Reference vs. Value Comparison
When we compare value types with ==, the C# compiler performs a value comparison. For example, this prints true because the value 6 is equal to the value 6:

int int1 = 6;
int int2 = 6;
Console.WriteLine(int1 == int2);
// Output: true
int1 and int2 are the actual value 6. When we compare the value 6 with 6, they’re the same!

When we compare reference types with ==, the C# compiler performs a referential comparison, which means it checks if two variables refer to the same memory location. For example, this prints false because d1 and d2 refer to two different locations in memory (even though they contain objects with the same values):

Dissertation d1 = new Dissertation(50);
Dissertation d2 = new Dissertation(50);
Console.WriteLine(d1 == d2);
// Output: false
We constructed two different Dissertation objects which happened to have the same values. Each reference (d1 and d2) point to different objects, so they are not equal.

/////

Polymorphism
We just saw how useful it is to have the same interface for multiple data types. This is a common concept across many programming languages, and it’s called polymorphism.

The concept really includes two related ideas. A programming language supports polymorphism if:

Objects of different types have a common interface (interface in the general meaning, not just a C# interface), and
The objects can maintain functionality unique to their data type
Let’s prove to ourselves that this is true in C#. We’ll use the example of Stringify: Dissertation and Book have different Stringify() methods but can both be referenced as Books.

Here are snippets from each class:

class Dissertation : Book
{
  public override string Stringify()
  {
    return "This is a Dissertation object!";
  }
}
 
 
class Book
{
  public virtual string Stringify()
  {
    return "This is a Book object!";
  }
}
Given that information, what will the below program print?

Book bk = new Book();
Book bdiss = new Dissertation();
Console.WriteLine(bk.Stringify());
Console.WriteLine(bdiss.Stringify());
The answer is:

This is a Book object!
This is a Dissertation object!
Even though bk and bdiss are both Book type references, their behavior is different. Dissertation overrides the Stringify() method, so all Dissertation objects (regardless of reference type) will use that method.

Therefore, C# support polymorphism!

You’ll never have to write polymorphism in your code, but this vocabulary is essential to communicating with other developers!

So remember: polymorphism is the ability in programming to present the same interface for differing data types.


////


ToDo: 

look into:

upcasting
downcasting 
as and is operators.

////

Null and Unassigned References
So far we’ve seen:

A reference to an object
Multiple references to an object
What about a reference that refers to no object? In C# a reference to no object is called either a null reference or unassigned. We’ll need to apply these concepts in C# whenever we want to show that a reference is “missing”, create a reference variable without defining it, or initialize an empty array.

In the first use case, we’d like to create a reference that is “missing” or empty. We set it equal to the keyword null:

Diary dy = null;
In the second case, if we create a reference variable without a value, it is unassigned:

Diary dy;
// dy is unassigned
In the third case, if we create an empty array of reference types, each element is an unassigned reference:

Diary[] diaries = new Diary[5];
// diaries[1] is unassigned, diaries[2] is unassigned, etc.
Be careful when checking for null and unassigned references. We can only compare a null reference if it is explicitly labeled null:

Diary dy = null;
Console.WriteLine(dy == null);
// Output: true
For the other two cases, comparing an unassigned variable we’ll get an error:

Object o;
Console.WriteLine (o == null);
// error CS0165: Use of unassigned local variable 'o'
This might seem annoying at first, but it’s actually a good thing: the C# compiler prevents future issues down the road by raising an error the first time an unassigned variable is used.


namespace LearnReferences
{
  class Program
  {
    static void Main(string[] args)
    {
      Book b1 = null;
      // Remember that null presents a null reference, so you should see nothing printed.
      Console.WriteLine(b1);
      Console.WriteLine(b1 == null); // true
    }
  }
}

///////

Introduction to Object
In C# there is one type of reference that can be used for all objects. It’s aptly called Object.

Every class is derived from Object. Whether it’s the class’ superclass or the superclass’ superclass’ superclass, Object is at the top of the class’ inheritance hierarchy.

Since references can be upcast to any type in its inheritance hierarchy, then all types can by referenced as Objects:

Object o1 = new Dissertation();
Object o2 = new Diary();
Object o3 = new Random();
Object o4 = new Forest("Amazon");

If that’s so, why not use Object references for everything? Because the functionality of an object is limited by its reference type. We lose all of a specific type’s specific functionality when we reference it as an Object type. We would also lose the automatic type-checking that saves us from type errors.

When we do use them, Object references can be very useful! For example, if we’re not sure what type a variable is, we can safely store it as an Object. We can also assume that any object has access to the standard Object members for basic manipulation.

The Object Type
Every class is derived from Object — even classes that we define ourselves!

When you create a class, C# implicitly makes it inherit Object. So when we write this code:

class Book
{}
C# assumes we mean:

class Book : Object
{}
Even if we already declared a superclass, like…

class Book : Media
{}
…Object will be at the top of the family tree. Maybe Media directly inherits from Object, or its base class inherits from Object, etc.

Value types and strings also inherit from Object:

Object o5 = 21;
Object o6 = false;
Object o7 = "Hello you!";


Object o1 = new Object();
// t is System.Object
Type t = o1.GetType();
 
string s = o1.ToString();
// Prints "System.Object"
Console.WriteLine(s);
 
Object o2 = o1;
// Equals true
bool b = o1.Equals(o2);


///////

Overriding Object Members
The Equals() and ToString() methods in Object are virtual, so they can be overridden.

For example, we can override ToString() in the Diary class:

class Diary
{
  /* other members omitted */
 
  public override string ToString()
  {
    return $"This Diary is currently on page {CurrentPage}."; 
  }
}
Now any Diary instance will use this version of the method:

Diary dy = new Diary(7);
Console.WriteLine(dy.ToString());
// Output: "This Diary is currently on page 7."


/////

Object in Plain Sight
At the very beginning of your C# journey, you learned about Console.WriteLine(). You used this tool with nearly every type, from int and bool to Dissertation and Diary:

bool b = true;
Diary d = new Diary();
Console.WriteLine(b);
Console.WriteLine(d);
We can use this same tool with every type because every type inherits from Object!

Under the hood, Console.WriteLine() uses ToString(), which is defined in Object. Every object needs some kind of string representation to be printed in text. These two lines are equivalent:

Console.WriteLine(b);
Console.WriteLine(b.ToString());




///////



Re-introduction to Strings
Previous lessons have stated that all classes are reference types and all “primitive” values are value types.

// Reference type
Object o = new Object();
// Value type
bool b = true;
Do we consider string a reference type or a value type?

Spoiler! Strings are technically reference types. But in action, it’s a bit more complicated. Nearly every C# program uses some strings, so you’ll need to know how it works. This lesson will explain the unique behavior of string references.

By the way: in C#, String and string are equivalent. This just gives us more options when we are coding. It’s convenient for beginners because they usually see string introduced with other primitive value types like int and bool.

Strings Can Look Like Values
String, or string, is a class that represents text. Technically its value is stored as a collection of char objects.

Since it is a class, it is a reference type. In some cases its behavior looks like a value type:

A string reference will always point to the original object, so “modifying” one reference to a string will not affect other references
Comparing strings with the equality operator (==) performs a value, not referential, comparison
Here are two examples of the first behavior (modifying one reference doesn’t affect the others):

// Example 1
string dog = "chihuahua";
string tinyDog = dog;
dog = "dalmation";
Console.WriteLine(dog);
// Output: "dalmation"
Console.WriteLine(tinyDog);
// Output: "chihuahua"
 
// Example 2
string s1 = "Hello ";
string s2 = s1;
s1 += "World";
System.Console.WriteLine(s1);
// Output: "Hello World"
System.Console.WriteLine(s2);
// Output: "Hello"
The can be explained by the fact that strings are immutable: they cannot be changed after they are created. Anything that appears to modify a string actually returns a new string object.

Here’s an example of the second behavior (value-like comparisons):

string s = "hello";
string t = "hello";
// b is true
bool b = (s == t);
Typically we want to compare strings by value, so this makes it easier to write in code and it also gives the C# compiler flexibility in how it implements the program (it doesn’t have to worry about where the actual string value is stored).



namespace StringTheException
{
  class Program
  {
    static void Main(string[] args)
    {
      string s1 = "immutable";
      string s2 = "immutable";
      Console.WriteLine(s1 == s2); // true

      Object obj1 = new Object();
      Object obj2 = new Object();

      Console.WriteLine(obj1 == obj2); // false
    }
  }
}

Strings can be Null or Empty or Unassigned
Like other reference types, string references can be null or unassigned. They can also have a third value: empty.

// Unassigned
string s;
// Null
string s2 = null;
// Empty string
string s3 = "";
// Also empty string
string s4 = String.Empty;
// This prints true
Console.WriteLine(s3 == s4);
All of these signify a lack of text, but they each mean something slightly different:

unassigned means that the programmer did not give the variable any value
null means that the programmer intentionally made the variable refer to no object
an empty string signifies a piece of text with zero characters. This is often used to represent a blank text field. It can be represented by "" or String.Empty
The Microsoft Programming Guide suggests using String.Empty or "" instead of null to avoid NullReferenceException errors.

We can check for null OR empty strings using the static String method IsNullOrEmpty(). It’s explained in more detail in the documentation.