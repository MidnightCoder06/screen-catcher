/*
TypeScript generics allow you to write the reusable and generalized form of functions, classes, and interfaces.
Suppose you need to develop a function that returns a random element in an array of numbers.
The following getRandomNumberElement() function takes an array of numbers as its parameter and returns a random element from the array:
*/

function getRandomNumberElement(items: number[]): number {
    let randomIndex = Math.floor(Math.random() * items.length);
    return items[randomIndex];
}

let numbers = [1, 5, 7, 4, 2, 9];
console.log(getRandomNumberElement(numbers));

// Assuming that you need to get a random element from an array of strings. This time, you may come up with a new function:

function getRandomStringElement(items: string[]): string {
    let randomIndex = Math.floor(Math.random() * items.length);
    return items[randomIndex];
}

let colors = ['red', 'green', 'blue'];
console.log(getRandomStringElement(colors));


/*
Later you may need to get a random element in an array of objects. 
Creating a new function every time you want to get a random element from a new array type is not scalable.

One solution for this issue is to set the type of the array argument as any[]. 
By doing this, you need to write just one function that works with an array of any type.
*/

function getRandomAnyElement(items: any[]): any {
    let randomIndex = Math.floor(Math.random() * items.length);
    return items[randomIndex];
}

let numbers2 = [1, 5, 7, 4, 2, 9];
let colors2 = ['red', 'green', 'blue'];

console.log(getRandomAnyElement(numbers2));
console.log(getRandomAnyElement(colors2));



/*
This solution works fine. However, it has a drawback.
It doesn’t allow you to enforce the type of the returned element. In other words, it isn’t type-safe.
A better solution to avoid code duplication while preserving the type is to use generics.

TypeScript generics come to rescue
The following shows a generic function that returns the random element from an array of type T:
*/

function getRandomElement<T>(items: T[]): T {
    let randomIndex = Math.floor(Math.random() * items.length);
    return items[randomIndex];
}

/*
This function uses type variable T. The T allows you to capture the type that is provided at the time of calling the function. 
Also, the function uses the T type variable as its return type.

This getRandomElement() function is generic because it can work with any data type including string, number, objects,…
By convention, we use the letter T as the type variable. However, you can freely use other letters such as A, B C, …

Calling a generic function
The following shows how to use the getRandomElement() with an array of numbers:
*/

let moreNumbers = [1, 5, 7, 4, 2, 9];
let randomEle = getRandomElement<number>(moreNumbers); // getRandomElement() function is also type-safe. 
// For example, if you assign the returned value to a string variable, you’ll get an error:
// TypeScript compiler set the value of T automatically based on the type of argument that you pass into
    // ... so you actually don't have to put <number>
console.log(randomEle);

/*
Generic functions with multiple types
The following illustrates how to develop a generic function with two type variables U and V:
*/

function merge<U, V>(obj1: U, obj2: V) {
    return {
        ...obj1,
        ...obj2
    };
}

/*
The merge() function merges two objects with the type U and V. 
It combines the properties of the two objects into a single object.

Type inference infers the returned value of the merge() function 
as an intersection type of U and V, which is U & V.

The following illustrates how to use the merge() function that merges two objects:
*/

let result = merge(
    { name: 'John' },
    { jobTitle: 'Frontend Developer' }
);

console.log(result); // { name: 'John', jobTitle: 'Frontend Developer' }

// The merge() function expects two objects. 
// However, it doesn’t prevent you from passing a non-object like this:
let john = merge(
    { name: 'John' },
    25
);

console.log(john); // { name: 'John' }

/*
TypeScript doesn’t issue any error.
Instead of working with all types, you may want to add a constraint to the merge() function so that it works with objects only.
To do this, you need to list out the requirement as a constraint on what U and V types can be.
In order to denote the constraint, you use the extends keyword. For example:
*/

function mergeTwo<U extends object, V extends object>(obj1: U, obj2: V) {
    return {
        ...obj1,
        ...obj2
    };
}

/*
Because the mergeTwo() function is now constrained, it will no longer work with all types. 
Instead, it works with the object type only.

let franco = mergeTwo(
    { name: 'John' },
    25
);

Argument of type '25' is not assignable to parameter of type 'object'.
*/

// Use extends keyof to constrain a type that is the property of another object.

function prop<T, K>(obj: T, key: K) {
    // return obj[key]; -> Type 'K' cannot be used to index type 'T'
}

function propTwo<T, K extends keyof T>(obj: T, key: K) {
    return obj[key];
}

let valueResponse = propTwo({ name: 'Jackson' }, 'name');
console.log(valueResponse); // Jackson


// Classes 

// A generic class has a generic type parameter list in an angle brackets <> that follows the name of the class:
class classNameOne<T>{
    //... 
}

// TypeScript allows you to have multiple generic types in the type parameter list. For example:    
class classNameTwo<K,T>{
    //...
}

// The generic constraints are also applied to the generic types in the class:
type TypeA = {
    name: string;
    age: number;
}

class classNameThree<T extends TypeA>{
    //...
}

// The following shows a complete generic Stack class called Stack<T>:
class Stack<T> {
    private elements: T[] = [];
    private maxSize: number;

    constructor(size: number) {
        this.maxSize = size
    }

    isEmpty(): boolean {
        return this.elements.length === 0;
    }

    isFull(): boolean {
        return this.elements.length === this.maxSize;
    }

    push(element: T): void {
        if (this.elements.length === this.maxSize) {
            throw new Error('The stack is overflow!');
        }
        this.elements.push(element);
    }

    pop(): T | undefined {
        if (this.elements.length == 0) {
            throw new Error('The stack is empty!');
        }
        return this.elements.pop();
    }
}

// The following creates a new stack of numbers:
let stackOfNumbers = new Stack<number>(5);

/////////////////////

/*
Generic Interfaces
A generic interface has generic type parameter list in an angle brackets <> following the name of the interface:
*/

// 1) Generic interfaces that describe object properties
    // The following show how to declare a generic interface that consists of two members key and value with the corresponding types K and V:

interface Pair<K, V> {
    key: K;
    value: V;
}

// Now, you can use the Pair interface for defining any key/value pair with any type. For example:
let month: Pair<string, number> = {
    key: 'Jan',
    value: 1
};

console.log(month);




// 2) Generic interfaces that describe methods
    // The following declares a generic interface with two methods add() and remove():

interface Collection<T> {
    add(o: T): void;
    remove(o: T): void;
}

// And this List<T> generic class implements the Collection<T> generic interface:
class List<T> implements Collection<T>{
    private items: T[] = [];

    add(o: T): void {
        this.items.push(o);
    }
    remove(o: T): void {
        let index = this.items.indexOf(o);
        if (index > -1) {
            this.items.splice(index, 1);
        }
    }
}

let list = new List<number>();

for (let i = 0; i < 10; i++) {
    list.add(i);
}


// 3) Generic interfaces that describe index types
    // The following declares an interface that describes an index type:

interface Options<T> {
    [name: string]: T
}

let inputOptions: Options<boolean> = {
    'disabled': false,
    'visible': true
};
