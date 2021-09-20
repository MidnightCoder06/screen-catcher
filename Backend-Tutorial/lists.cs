/*
Introduction to Lists
At this point, we assume that you’re familiar with arrays: they’re useful tools for managing large amounts of sequential data.

But arrays have their drawbacks:

They have a limited length
You have to keep track of the number of elements in the array using a separate index
You can only edit one element at a time
Lists resolve all of these issues! Like arrays, they are a sequential collection of values and they can hold references to any type. Unlike arrays, they have (effectively) unlimited length, they automatically track the number of actual elements in the list, and they have handy methods to work with multiple elements at a time.

In this lesson we’ll cover list basics and some common list methods.
*/

using System;
using System.Collections.Generic;

namespace LearnLists
{
  class Program
  {
    static void Main()
    {
      List<string> citiesList = new List<string> { "Delhi", "Los Angeles", "Saint Petersburg" };
      
      citiesList.Add("New York City");
      
      citiesList.Remove("Dubai");
      
      citiesList.AddRange(new string[] {"Cairo", "Johannesburg"});
      
      bool hasNewDelhi = citiesList.Contains("New Delhi");
      
      foreach (string city in citiesList)
      {
        Console.WriteLine(city);
      }
      /*
        Delhi
        Los Angeles
        Saint Petersburg
        New York City
        Cairo
        Johannesburg
      */
    }
  }
}

/*

Creating and Adding
A list is a sequential data structure that can hold any type. Like arrays, you can use them to store any sequential information, like the letters of the alphabet, comments on a blogpost, the finishing times for a horse race, or items on a restaurant menu.

You create a list using the new keyword, like you would create any other class. You specify the type of element inside angle brackets: < >. In this example, the list is named citiesList and it holds instances of the type string.

List<string> citiesList = new List<string>();
You can add elements to the list using the Add() method:

citiesList.Add("Delhi");
You can access elements using indices and square brackets:

string city = citiesList[0];
You can also re-assign elements using bracket notation:

citiesList[0] = "New Delhi";
In order to use lists, you’ll need to add this to the top of your file. We’ll explain this in detail later:

using System.Collections.Generic;

*/

/*

Object Initialization
Our first way to create lists and add items took multiple lines:

List<string> citiesList = new List<string>();
citiesList.Add("Delhi");
citiesList.Add("Los Angeles");
We can do it all in one line using object initialization:

List<string> citiesList2 = new List<string> { "Delhi", "Los Angeles" };
We won’t cover everything about object initialization in this lesson, but you do need to recognize and use it.

Basic construction uses parentheses ( ) and no values.
Object initialization uses curly braces { } and the actual values go in-between.
If we need to add elements to that second list later, we can still use Add():

citiesList2.Add("Kiev");


*/

/*

Generic Collections
You’ve done great with lists so far! It’s time to take a look at the bigger picture.

Remember the one line we mentioned at the beginning of this lesson?

using System.Collections.Generic;
The list class is in a group of classes called generic collections. They don’t exist in the default set of System classes, so we need to make a reference to them with this line.

Generic collections are data structures that are defined with a generic type. Each class is defined generally without a specific type in mind. When we make an actual instance, we define the specific type:

List<string> citiesList = new List<string>();
List<Object> objects = new List<Object>();
Imagine it like a set of general instructions: in a toy store, we can tell the employees how to add and remove items from a shelf without specifying the type of toy. In the same way, we can use Add() and Remove() without knowing a lists’s data type.

For this reason, the formal class name of lists is List<T>. That T is a type parameter: it represents some type that we can specify later. The general instructions, however are neatly contained in the generic List<T> class.

*/