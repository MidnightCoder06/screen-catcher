/*
A function type has two parts: parameters and return type.
When declaring a function type, you need to specify both parts with the following syntax:
(parameter: type, parameter:type,...) => type
*/
let add: (x: number, y: number) => number;

add = function (x: number, y: number) {
    //return x.concat(y).length;
    //Property 'concat' does not exist on type 'number'
    return x + y;
};

// Notice that you cannot include default parameters in function type definitions -> will result in an error



/*

In JavaScript, you can call a function without passing any arguments even though the function specifies parameters.
Because the compiler thoroughly checks the passing arguments, you need to annotate optional parameters to instruct the compiler not to issue an error when you omit the arguments.
To make a function parameter optional, you use the ? after the parameter name. For example:
*/

// The optional parameters must appear after the required parameters in the parameter list.
function multiplly(a: number, b: number, c?: number): number {
    if (typeof c !== 'undefined') {
        return a * b * c
    } else {
        return a * b
    }
}

/*
Introduction to TypeScript default parameters
function name(parameter1=defaultValue1,...) {
   // do something
}
*/

function applyDiscount(price: number, discount: number = 0.05) {
    return price * (1 - discount);
}

// Like optional parameters, default parameters are also optional. It means that you can omit the default parameters when calling the function.
//console.log(applyDiscount(100));      // 95
//console.log(applyDiscount(100, .15)); // 85

/*
Optional parameters must come after the required parameters. 
However, default parameters don’t need to appear after the required parameters.

When a default parameter appears before a required parameter, 
you need to explicitly pass undefined to get the default initialized value.

*/

function hello(year: number = 1906, month: number): number {
    return month
}

let sample = hello(2019, 2)
let sample_two = hello(undefined, 5)
//let sample_three = hello(7) -> Expected 2 arguments, but got 1.

//console.log(sample) // 2
//console.log(sample_two) // 5

/*
TypeScript rest parameters allow you to represent an indefinite number of arguments as an array.

A rest parameter allows you a function to accept zero or more arguments of the specified type. In TypeScript, rest parameters follow these rules:

A function has only one rest parameter.
The rest parameter appears last in the parameter list.
The type of the rest parameter is an array type.
To declare a rest parameter, you prefix the parameter name with three dots and use the array type as the type annotation:

function fn(...rest: type[]) {
   //...
}

*/

function getTotal(...numbers: number[]): number {
    let total = 0;
    numbers.forEach((num) => total += num);
    return total;
}

//console.log(getTotal()); // 0
//console.log(getTotal(10, 20)); // 30
//console.log(getTotal(10, 20, 30)); // 60


/*

TypeScript function overloadings
*TypeScript function overloadings allow you to describe the relationship between parameter types and results of a function.

Note that TypeScript function overloadings are different from the function overloadings 
supported by other statically-typed languages such as C# and Java.

It’s possible to use a union type to define a range of types for function parameters and results:

function add(a: number | string, b: number | string): number | string {
    if (typeof a === 'number' && typeof b === 'number')
        return a + b;

    if (typeof a === 'string' && typeof b === 'string')
        return a + b;
}

However, the union type doesn’t express the relationship between the parameter types and results accurately.
The add() function tells the compiler that it will accept either numbers or strings and return a number or string. 
It fails to describe that the function returns a number when the parameters are numbers and return a string if the parameters are strings.
To better describe the relationships between the types used by a function, TypeScript supports function overloadings. For example:

*/

function addTheThings(a: number, b: number): number;
function addTheThings(a: string, b: string): string;
function addTheThings(a: any, b: any): any {
   return a + b;
}

/*

In this example, we added two overloads to the addTheThings() function. 
The first overload tells the compiler that when the arguments are numbers, the addTheThings() function should return a number. 
The second overload does the same but for a string.
Each function overload defines a combination of types supported by the addTheThings() function. 
It describes the mapping between the parameters and the result they return.

Now, when you call the addTheThings() function, the code editor suggests that there is an overload function available.

*/


/*
Function overloading with optional parameters
When you overload a function, the number of required parameters must be the same. 
If an overload has more parameters than the other, you have to make the additional parameters optional. For example:
*/

function sum(a: number, b: number): number;
function sum(a: number, b: number, c: number): number;
function sum(a: number, b: number, c?: number): number {
    if (c) return a + b + c;
    return a + b;
}

/*
The sum() function accepts either two or three numbers. The third parameter is optional. 
If you don’t make it optional, you will get an error
*/


/*
Method overloading
When a function is a property of a class, it is called a method. TypeScript also supports method overloading. For example:
*/

class Counter {
    private current: number = 0;
    count(): number;
    count(target: number): number[];
    count(target?: number): number | number[] {
        if (target) {
            let values = [];
            for (let start = this.current; start <= target; start++) {
                values.push(start);
            }
            this.current = target;
            return values;
        }
        return ++this.current;
    }
}

// The count() function can return a number or an array depending on the number of argument that you pass into it:

let counter = new Counter();

console.log(counter.count()); // return a number
console.log(counter.count(20)); // return an array

/*
Output:

1
[
   1,  2,  3,  4,  5,  6,  7,
   8,  9, 10, 11, 12, 13, 14,
  15, 16, 17, 18, 19, 20     
]
*/