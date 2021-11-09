C# (C-Sharp) is a programming language developed by Microsoft that runs on the .NET Framework.

C# is used to develop web apps, desktop apps, mobile apps, games and much more.

C# is part of .Net framework and is used for writing .Net applications. Therefore, before discussing the available tools for running a C# program, let us understand how C# relates to the .Net framework.

The .Net framework applications are multi-platform applications. 
The .Net framework consists of an enormous library of codes used by the client languages such as C#.

Although the.NET Framework runs on the Windows operating system, there are some alternative versions that work on other operating systems. Mono is an open-source version of the .NET Framework which includes a C# compiler and runs on several operating systems, including various flavors of Linux and Mac OS. 

'''
using System;

namespace RectangeApplication {

    class Rectangle {

        // member variables
        double length;
        double width;

        public void Acceptdetails() {
            length = 4.5;
            width = 3.5;
        }

        public double GetArea() {
            return length * width;
        }

        public void Display() {
            Console.WriteLine("Length: ", length)
            Console.WriteLine("Wdith: ", width)
            Console.WriteLine("Area: ", GetArea());
        }
    }

    class ExecuteRectangle {
        static void Main(string[] args) {
            Rectangle r = new Rectangle(); // instantiating the class
            r.Acceptdetails();
            r.Display();
            Console.ReadLine();
        }
    }
}
'''

The `using` keyword is used for including the namespace in the program. 
A program can include multiple `using` statements.

The `class` keyword is used for declaring a class.

// single line comments

/* multiple-line comments */

Member variables 
...are attributes or data members of a class, used for storing data.
The `Rectangle` class has two member variables named length and width.

Member functions
... a set of statements that perform a specific task. The member functions of a class
are declared within the class. Our sample class `Rectangle` contains three member functions:
`AcceptDetails, GetArea and Display`



## Types

object obj;
obj = 100; // object type being converted into a value type is called boxing.

syntax: dynamic <variable_name> = value;
dynamic d = 20; // example

checking for object type happens at compile time.
checking for dynamic type variables takes place at run time.

Pointer type variables store the memory address fo another type.

syntax: type* identifier 

// examples:

char* cptr;
int* iptr;

'x' a string with a single character is by default of type char

// error CS1012: Too many characters in character literal 
You're trying to use single quotes for string literals - that's invalid in C#. Single quotes are for character literals (char). You need double quotes for string literals.


# Arrays

Once we create an array, the size of that array is fixed. However, it’s possible to change the values it contains.

For example, we can initialize an array that has a length of three without specifying what those values are, then later go back and edit the array to include a new value. This is useful if we know how many things we’re expecting, but we don’t know their specific values yet:

// plantHeights will be equal to [0, 0, 0]
int[] plantHeights = new int[3]; 
 
// plantHeights will now be [0, 0, 8]
plantHeights[2] = 8; 
When we create the array with a known length but no known values, the array stores a default type value (0 for int, null for string). We then edit the array and swap out one of the default values with a new, specific value. In this case, we’re saying that at index 2 we want to swap the default value 0 for 8.

We can also edit the values of pre-existing arrays. Again, we can’t add to the length of an existing array, but we can swap out values:

int[] plantHeights = { 3, 4, 6 };
 
// plantHeights will be [3, 5, 6]
plantHeights[1] = 5; 
In this case, we already have an array with a defined set of values, { 3, 4, 6 }. But what if a plant grows? We’ll need to go back in and change its value. So if it’s the second plant, we access its value using bracket notation, then change its value to 5.


The Array method Array.Find()(documentation) searches a one-dimensional array for a specific value or set of values that match a certain condition and returns the first occurrence in the array.

int[] plantHeights = { 3, 6, 4, 1, 6, 8 };
 
// Find the first occurence of a plant height that is greater than 5 inches
int firstHeight = Array.Find(plantHeights, height => height > 5);
Find() takes two parameters: the first is the array and the second is a predicate that defines what we’re looking for. A predicate is a method that takes one input and outputs a boolean. Unlike IndexOf(), Find() returns the actual values that match the condition, instead of their index.

Array.Copy() (documentation) copies a range of elements from one array to a second array. It takes three parameters: the name of the array to be copied, the new array, and the length of the array elements.

string[] players = { "Emily", "Kyle", "Todd", "Rachel", "Grayson" };
 
// This creates a new array with default values
string[] playersCopy = new string[5];
 
// This will populate the playersCopy array with { "Grayson", "Rachel", "Todd", "Kyle", "Emily" }
Array.Copy(players, playersCopy, 5);



