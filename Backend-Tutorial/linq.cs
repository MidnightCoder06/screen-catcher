using System;
/*
Often times we use LINQ with generic collections (like lists), so you may see both namespaces imported into a file:
*/
using System.Collections.Generic;
using System.Linq; // To use LINQ in a file, add this line to the top


/*
LINQ works for complex selections and transformations, and it works on local and remote data sources. 
Each selection/transformation is called a query, and LINQ gives us new syntax and methods to write them.

Imagine LINQ like an add-on to C# and .NET. Once you import the LINQ features, you can write new syntax, like:
*/
string[] names = { "Tiana", "Dwayne", "Helena" };
var filteredNames = from n in names
  where n.Contains("a")
  select n;

// And you can use new methods on collections, like Where():

var shortNames = names.Where(n => n.Length < 4);



namespace LearnLinqOne
{
  class Program
  {
    static void Main()
    {
      List<string> heroes = new List<string> { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };
      
      // Approach 1: without LINQ
      List<string> longLoudHeroes = new List<string>();
      
      foreach (string hero in heroes)
      {
        if (hero.Length > 6)
        {
          string formatted = hero.ToUpper();
          longLoudHeroes.Add(formatted);
        }
      }
      
      // Approach 2: with LINQ
      var longLoudHeroes2 = from h in heroes
            where h.Length > 6
            select h.ToUpper();
      
      // Printing...
      Console.WriteLine("Your long loud heroes are...");
      
      foreach (string hero in longLoudHeroes2)
      {
        Console.WriteLine(hero);
      }
    }
  }
}

/////

/*
Since the single value type and/or the parameter type T is not always known, 
it’s common to store a query’s returned value in a variable of type var.

var is just an implicitly typed variable — we let the C# compiler determine the actual type for us. 

In LINQ, you can write queries in two ways: in query syntax and method syntax.
*/


namespace LearnLinqTwo
{
  class Program
  {
    static void Main()
    {
      List<string> heroes = new List<string> { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };


      // Query syntax looks like a multi-line sentence. If you’ve used SQL, you might see some similarities
      var shortHeroes = from h in heroes
        where h.Length < 8
        select h;
      
      foreach(string hero in shortHeroes)
      {
        Console.WriteLine(hero);
      }
        /*
        D. Va
        Lucio
        Mercy
        Pharah
        */

        // Method syntax looks like plain old C#. We make method calls on the collection we are querying:
        var longHeroes = heroes.Where(n => n.Length > 8);
        Console.WriteLine(longHeroes.Count()); // 2

      
    }
  }
}


namespace LearnLinqThree
{
  class Program
  {
    static void Main()
    {
      string[] heroes = { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };

      // Query syntax
      var queryResult = from x in heroes
                        where x.Contains("a")
                        select $"{x} contains an 'a'";
      
      // Method syntax
      var methodResult = heroes
        .Where(x => x.Contains("a"))
        .Select(x => $"{x} contains an 'a'");
     
      // Printing...
      Console.WriteLine("queryResult:");
      foreach (string s in queryResult)
      {
        Console.WriteLine(s);
      }
      /*
        queryResult:
        D. Va contains an 'a'
        Pharah contains an 'a'
        Reinhardt contains an 'a'
      */
      
      Console.WriteLine("\nmethodResult:");
      foreach (string s in methodResult)
      {
        Console.WriteLine(s);
      }
      /*
        methodResult:
        D. Va contains an 'a'
        Pharah contains an 'a'
        Reinhardt contains an 'a'
      */
    }
  }
}

/*

Basic Query Syntax
A basic LINQ query, in query syntax, has three parts:

string[] heroes = { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };
 
var shortHeroes = from h in heroes
  where h.Length < 8
  select h;
The from operator declares a variable to iterate through the sequence. In this case, h is used to iterate through heroes.
The where operator picks elements from the sequence if they satisfy the given condition. The condition is normally written like the conditional expressions you would find in an if statement. In this case, the condition is h.Length < 8.
The select operator determines what is returned for each element in the sequence. In this case, it’s just the element itself.
The from and select operators are required, where is optional. In this next example, select is used to make a new string starting with “Hero: “ for each element:

var heroTitles = from hero in heroes
  select $"HERO: {hero.ToUpper()};
Each element in heroTitles would look like "HERO: D. VA", "HERO: LUCIO", etc.

*/

/*

Basic Method Syntax: Where
In method syntax, each query operator is written as a regular method call.

In the last exercise we selected every element with a length under 8. Here it is in method syntax:

string[] heroes = { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };
var shortHeroes = heroes.Where(h => h.Length < 8);
The where operator is written as the method Where(), which takes a lambda expression as an argument. Remember that lambda expressions are a quick way to write a method. In this case, the method returns true if h is less than 8 characters long.

Where() calls this lambda expression for every element in heroes. If it returns true, then the element is added to the resulting collection.

For example, the shortHeroes sequence from above would be:

[ D. Va, Lucio, Mercy, Pharah ]

To transform each element in a sequence — like writing them in uppercase — we can use the select operator. In method syntax it’s written as the method Select(), which takes a lambda expression:

string[] heroes = { "D. Va", "Lucio", "Mercy", "Soldier 76", "Pharah", "Reinhardt" };
var loudHeroes = heroes.Select(h => h.ToUpper());
We can combine Select() with Where() in two ways:

Use separate statements:
var longHeroes = heroes.Where(h => h.Length > 6);
var longLoudHeroes = longHeroes.Select(h => h.ToUpper());

Chain the expressions:
var longLoudHeroes = heroes
.Where(h => h.Length > 6)
.Select(h => h.ToUpper());

As with most of LINQ, the choice is up to you!

In the first option, we use two variable names and two statements. You can tell there are two separate statements by counting the semi-colons.

In the second option, we use one variable name and one statement.

If we must use method-syntax, we prefer the second option (chaining) because it is easier to read and write. You can imagine each line like a step in a conveyor belt, filtering and transforming the sequence as it goes.

*/


/*


As you get into more advanced LINQ queries and learn new operators, you’ll get a feel for what works best in each situation. 
For now, we generally follow these rules:

For single operator queries, use method syntax.
For everything else, use query syntax.


*/

// where isn't always needed in the method syntax
// var capitalizedHeroes = heroes.Select(h => $"Introducing...{h.ToUpper()}");


