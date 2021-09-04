/*
Enums
Enums allow us to define a set of named predefined constants. 
These are defined with the enum keyword. 
You can define a numeric or a string enum.
*/

enum MyStringEnum {
    ChoiceA = "A",
    ChoiceB = 2,
    // ChoiceC = true 
    // error -> Computed values are not permitted in an enum with string valued members.
}

/*
There are different mapping functions in Typescript: partial, nullable, pick, omit, record, extract, exclude, and ReturnType.
*/

// Type Checking and Assertions

/*
Instanceof
This operator can check for custom types not defined by Javascript. 
Below, we first write a custom type, make an instance of it, 
and check that it is indeed the right variable.
*/

class Dog {
    name: string;
    constructor(data: string) {
        this.name = data;
    }
}

class Cat {
    name: string;
    constructor(data: string) {
        this.name = data;
    }
}

let dog = new Dog('Rover')
let cat = new Cat('Billy')

if (dog instanceof Dog) {
    console.log(`${dog.name} is a dog`)
} else {
    console.log('not a dog')
}

if (cat instanceof Dog) {
    console.log('mutant!')
} else {
    console.log('a cat is not a dog')
}


/*
As Keyword
Use the as keyword after the name of the variable and end it with the desired datatype.
< > Operator
We can also cast our variables by using the < > operator. This has the same effect on our code but implements a simpler syntax.
*/

let str: any = 'This is a String'
let strLength = str.length; // this also works
//let strLength = (str as string).length
console.log(strLength)

let str_two: any = 'This is another String'
let str_two_length = (<string>str_two).length
console.log(str_two_length)

/*

Type Casting

JavaScript doesn’t have a concept of type casting because variables have dynamic types. 
However, every variable in TypeScript has a type. 
Type castings allow you to convert a variable from one type to another.
- you can use the as keyword or <> operator for type castings.

*/

/*
let areaCode: number 
let convertedAreaCode = areaCode as string;
let convertedAreaCodeTwo = <boolean>areaCode;

Conversion of type 'number' to type 'string' may be a mistake because neither type sufficiently overlaps with the other. 
If this was intentional, convert the expression to 'unknown' first.

Conversion of type 'number' to type 'boolean' may be a mistake because neither type sufficiently overlaps with the other. 
If this was intentional, convert the expression to 'unknown' first.
*/



/*
Type Assertions in TypeScript

Type assertions instruct the TypeScript compiler to treat a value as a specified type. 
It uses the as keyword to do so:

expression as targetType

A type assertion is also known as type narrowing. 
It allows you to narrow a type from a union type. Let’s see the following simple function:
*/

function getNetPrice(price: number, discount: number, format: boolean): number | string {
    let netPrice = price * (1 - discount);
    return format ? `$${netPrice}` : netPrice;
}

/*

The getNetPrice() function accepts price, discount, and format arguments and returns a value of the union type number | string.

If the format is true, the getNetPrice() returns a formatted net price as a string. Otherwise, it returns the net price as a number.

The following uses the as keyword to instruct the compiler that the value assigned to the netPrice is a string:

*/

let netPrice = getNetPrice(100, 0.05, true) as string;
console.log(netPrice);


// Similarly, the following uses the as keyword to instruct the compiler that the returned value of the getNetPrice() function is a number.

let netPriceTwo = getNetPrice(100, 0.05, false) as number;
console.log(netPrice);