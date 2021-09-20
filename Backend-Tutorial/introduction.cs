// double quotes and the semi-colon seem necessary 
Console.WriteLine("Hello There");

// you have declare variable types
string name = "Jean";
Console.WriteLine(name);

//  It’s good practice to use camelCase styling when declaring variables

// Declare an integer
int myAge;
myAge = 32;

// Declare a string
string countryName = "Netherlands";

/*
Converting Data Types
Because variables have to be strictly typed, there may be some circumstances where we want to change the type of data a variable is storing. 
This strategy is known as data type conversion.

For example, let’s try converting a double to an integer:
*/

double myDouble = 3.2;
 
// Round myDouble to the nearest whole number
int myInt = myDouble;
/*
But if you tried to run this code, it wouldn’t work. Sorry.
However, if you did the reverse and turned an int into a double:
*/

int myInt = 3;
// Turn it into a decimal
double MyDouble = myInt;

/*
It’s fine! Why is that?

C# checks to make sure that when we convert data types from one to another that we’re not losing any data, because that could cause problems in our code.

Because of that, there are a couple different ways to do data type conversion:

implicit conversion: happens automatically if no data will be lost in the conversion. That’s why it’s possible to convert an int (which can hold less data) to a double (which can hold more), but not the other way around.
explicit conversion: requires a cast operator to convert a data type into another one. So if we do want to convert a double to an int, we could use the operator (int).
So, if we’re to fix the error in our previous code, we’d rewrite it as follows:
*/

double myDouble = 3.2;
 
// Round myDouble to the nearest whole number
int myInt = (int)myDouble;
// It’s also possible to convert data types using built-in methods. For most data types, there is a Convert.ToX() method, like Convert.ToString() and Convert.ToDouble().


/*
Double and Decimal
If we need to use a decimal value, we have a few options: float, double, and decimal. These values are useful for anything that requires more precision than a whole number, like measuring the precise location of an object in 3D space.

A double is usually the best choice of the three because it is more precise than a float, but faster to process than a decimal. However, make sure to use a decimal for financial applications, since it is the most precise.

To define a variable with the type double, you would write it as follows:
*/

double variableName = 39.76876;
//To define a variable with the type decimal, you would write it as follows:

decimal variableName = 489872.76m;
//Don’t forget the m character after the number! This character tells C# that we’re defining a decimal and not a double.

/*
When using operators, it’s important to pay attention to data types. 
If we use two integers, it will return an integer every time. However, if we combine an integer with a double, the answer will be a double. 
Let’s look at the following example:
*/
Console.WriteLine(5 / 3);
Console.WriteLine(5 / 3.0);
 
// prints 1
// prints 1.66667


/*

Define a Method

In C#, it’s convention to use PascalCase to name your method. 
The name starts with an uppercase letter and each word following begins with an uppercase as well.

calling methods with arguments, like Math.Min(3, 4)

define a parameter, which sort of works like a variable within a method. Imagine it as a placeholder for the actual argument value.

*/

static void YourMethodName(string identity) // parameter
{
  Console.WriteLine(identity); // argument 
}

// When you call your method, the values to be used for each parameter are called arguments.


// In this example, punctuation is an optional parameter, and its default value is ".".
static void YourMethodName(string message, string punctuation = ".")
{
  Console.WriteLine(message + punctuation);
}

/*

Named Arguments

In this example, your method has five optional parameters:

static void YourMethodName(int a = 0, int b = 0, int c = 0, int d = 0, int e = 0) {...}
When you call the method, you only want to specify d. But calling the method this way would set a to 4, not d!

YourMethodName(4);
Refer to the parameter by its name instead:

YourMethodName(d: 4);
With named arguments, you can list them in any order:

YourMethodName(d: 4, b: 1, a: 2);
You can also mix named arguments with positional arguments, but positional arguments MUST come before named arguments:

YourMethodName(2, 1, d: 4) // a is 2, b is 1, d is 4
YourMethodName(d: 4, 2, 1) // Error!
Named arguments aren’t always necessary, but they can be useful when:

a method has many optional parameters
you want to differentiate between similar arguments


*/
 

 /*

Method Overloading

Say you want to use Math.Round(), a built-in method. You go to the Microsoft documentation to learn how to use it, and find at least 8 different versions! They all have the same name: Math.Round().

What’s happening here is called method overloading, and each “version” is called an overload. Though they have the same name, the overloads are different because they have either (i) different parameter types or (ii) different number of parameters. This is useful if you want the same method to have different behavior based on its inputs.

Let’s examine this concept with these two overloads: Math.Round(Double, Int32) and Math.Round(Double).

The first overload, Math.Round(Double, Int32), rounds the double to the int‘s number of decimal points

Math.Round(3.14159, 2); // returns 3.14
The second, Math.Round(Double), rounds the double to the nearest integer.

Math.Round(3.14159); // returns 3
In C#, when we say that the methods are “different”, we are really talking about their method signatures, which is the method’s name and parameter types in order.

For example, both methods above are named Round(), but one has Double and Int32 parameters, and the other has a Double parameter.


 */

namespace OutParameters
{
  class Program
  {
    static void Main(string[] args)
    {
      string ageAsString = "102";      
      string nameAsString = "Granny";
      
      int ageAsInt;
      bool outcome;
      
      outcome = Int32.TryParse(ageAsString, out ageAsInt);
      
      Console.WriteLine(outcome); // True
      Console.WriteLine(ageAsInt); // 102
      
      int nameAsInt;
      bool outcome2;
      
      outcome2 = Int32.TryParse(nameAsString, out nameAsInt);
      
      Console.WriteLine(outcome2); // False
      Console.WriteLine(nameAsInt); // 0




    /*
    Using Out
    We can use out parameters in our own methods as well. 
    In this example, Yell() converts phrase to uppercase and sets a boolean variable to true:

    The out parameter must have the out keyword and its expected type
    The out parameter must be set to a value before the method ends
    When calling the method, don’t forget to use the out keyword as well:
    */

        string message = "garrrr";
        Yell(message, out bool flag);
        // returns "GARRRR" and flag is true
    }


    static string Yell(string phrase, out bool wasYellCalled)
    {
        wasYellCalled = true;
        return phrase.ToUpper();
    }


	}
}




// There are other methods that accept methods as arguments, which you will encounter later on. For now, you need to understand that we can use a method’s name like a variable, e.g. IsEven is a variable representing the method IsEven(). We pass this variable to another method, like Array.Exists(), which will probably invoke that method-argument at least once within its own body.


/*
Array.Find() is another method that takes an array and a method as arguments. Array.Find() calls the method on each element of the array and returns the first element for which the method returns true.

An array adjectives and method IsLong() are defined for you. Call Array.Find() with these two arguments to find the first element in adjectives that is “long”.

Store the returned string in a variable named firstLongAdjective.
*/

namespace AlternateExpressions
{
  class Program
  {
  	// Method to be used as second argument
   	public static bool IsLong(string word)
    {
      return word.Length > 8;
    }
      
    static void Main(string[] args)
    {
      // Array to be used as first argument
      string[] adjectives = {"rocky", "mountainous", "cosmic", "extraterrestrial"};
     
      // Call Array.Find() and 
      // Pass in the array and method as arguments
      string firstLongAdjective = Array.Find(adjectives, IsLong);
      
      Console.WriteLine($"The first long word is: {firstLongAdjective}.");
    }
  }
}



bool hasEvenNumber = Array.Exists(numbers, (int num) => num % 2 == 0 );
/*
What makes a lambda expression unique is that it is an anonymous method: it has no name.

Generally lambda expressions with one expression (like the above example) take this form. They use the fat arrow, no curly braces, and no semicolon (;):

(input-parameters) => expression
*/

//Here’s an example of the second structure, which checks if any element in numbers is a multiple of 12 and greater than 20:

bool hasBigDozen = Array.Exists(numbers, (int num) => {
  bool isDozenMultiple = num % 12 == 0;
  bool greaterThan20 = num > 20;
  return isDozenMultiple && greaterThan20;
});


Shorter Lambda Expressions
Time to put on our detective caps: using deductive reasoning, we can make our lambda expression even shorter. Here’s what we have to start:

bool hasEvenNumbers = Array.Exists(numbers, (int num) => num % 2 == 0 );
The type of num is int. It’s great to be explicit like this to avoid errors, but some developers wouldn’t include int. To them, it’s obvious! Here’s their reasoning:

The modulo operator (%) is only used with numbers, so num must be a number
The result of the operation num % 2 is compared to the integer 0. We can only compare similar types, so num must also be an integer!
Therefore, we can remove int without causing any errors:

bool hasEvenNumbers = Array.Exists(numbers, (num) => num % 2 == 0 );
When there is just one parameter in a lambda expression, we don’t need the parentheses around the parameter either:

bool hasEvenNumbers = Array.Exists(numbers, num => num % 2 == 0 );


/*

Do...While Loop
Similar to the while loop, a do...while loop will continue running until a stopping condition is met. One key difference is that no matter what, a do...while loop will always run once.

For Each Loop
There’s one more way to give looping instructions to a computer. We define a sequence of values and tell the computer to repeat the instructions for each item in the sequence.

foreach (type element in sequence)
{
  statement;
}
The foreach loop is used to iterate over collections, such as an array.

Here’s an example array of notes:

string[] melody = { "a", "b", "c", "c", "b" };
and the loop would look like:

foreach (string note in melody)
{
  PlayMusic(note);
}


CONTINUE
The continue keyword is used to bypass portions of code. It will ignore whatever comes after it in the loop and then will go back to the top and start the loop again.

int bats = 10;
 
for (int i = 0; i <= 10; i++)
{
  if (i < 9)
  {  
    continue;
  }
  // this will be skipped until i is no longer less than 9
  Console.WriteLine(i);
}
Here, the program starts in the for loop, then hits the if statement. Since there is a continue in the if statement, it will bypass the Console.WriteLine() statement until the condition in the if statement is no longer true. So while the loop starts at 0, nothing will print to the console until i is equal to 9.

Nested Loops

You should only use return if you need to exit a method, because it will break out of all loops. If you only want to break out of one loop and not exit a method, use break.

*/


In C#, arrays are a collection of values that all share the same data type. You could have an array of type string that contains a list of your favorite songs, or an array of type int that stores a collection of user ids.

Similar to defining a variable for one piece of data, when we define a variable to hold an array we also have to specify the type:

Like a variable, we can define and initialize an array at the same time, by specifying the values we want to store in it:

int[] plantHeights = { 3, 4, 6 };

To declare and initialize an array at the same time, after the array declaration we use the equal sign to denote we’re storing a value to the array, then write out the numbers we’re putting in the array, separated by commas , and enclosed in curly braces {}.

You may also see arrays defined and initialized using a new keyword:

int[] plantHeights = new int[] { 3, 4, 6 };
The new keyword signifies that we are instantiating a new array from the array class. We’ll cover classes and instantiation in another lesson, but for now you can just think of it as another way to create an array.

In fact, if you decide to define an array and then initialize it later (rather in one line like above) you must use the new keyword:

// Initial declaration
int[] plantHeights;
 
// This works
plantHeights = new int[] { 3, 4, 6 };   
 
// This will cause an error
// plantHeights = { 3, 4, 6 }; 