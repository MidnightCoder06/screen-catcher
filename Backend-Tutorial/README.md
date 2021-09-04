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
