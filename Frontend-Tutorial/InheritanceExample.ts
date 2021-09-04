/* 

extends -> is for classes
implements -> is for interfaces 

A class can reuse the properties and methods of another class. This is called inheritance in TypeScript.
The class which inherits properties and methods is called the child class. 
And the class whose properties and methods are inherited is known as the parent class. 
These names come from the nature that children inherit genes from parents.

Inheritance allows you to reuse the functionality of an existing class without rewriting it.
JavaScript uses prototypal inheritance, not classical inheritance like Java or C#. 
ES6 introduces the class syntax that is simply the syntactic sugar of the prototypal inheritance. 
TypeScript supports inheritance like ES6.

*/

class Baller {

    litLevel: number
    // Use super() in the constructor of the child class to call the constructor of the parent class.
    constructor(litLevel: number) {
        this.litLevel = litLevel
    }

    getLitLevel() {
        return this.litLevel
    }
}

// To inherit a class, you use the extends keyword. For example the following Employee class inherits the Person class:
class Jean extends Baller {
    /*
    you need to initialize these properties in the constructor of the Employee class by calling its parent class’ constructor.
    To call the constructor of the parent class in the constructor of the child class, you use the super() syntax. 
    */
   constructor(litLevel: number, distanceFromThrone: number) {
       super(litLevel);
   }
}

/*
Because the Jean class inherits properties and methods of the Baller class, you can call the getLitLevel() method on the Jean object as follows:
*/
let jimmy = new Jean(10, 2)
console.log(jimmy.getLitLevel()) // if you remove the () you get -> [Function (anonymous)]


// Method overriding

/*
If you want the child class to have its own version of the getLitLevel() method, you can define it like this:
*/

class George extends Baller {
   constructor(litLevel: number, nameCommonalityLevel: number) {
       super(litLevel);
   }

   getLitLevel() {
    // In the getLitLevel() method, we called the getLitLevel() method of the parent class using the syntax super.methodInParentClass().
    return super.getLitLevel() + 12
    //return 5
   }
}