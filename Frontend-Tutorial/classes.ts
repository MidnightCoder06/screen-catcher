
/*
TypeScript provides the readonly modifier that allows you to mark the properties of a class immutable. 
The assignment to a readonly property can only occur in one of two places:
- In the property declaration.
- In the constructor of the same class.
*/

class Person {
    // these are instance variables - unique to each instance of the class 
    private ssn: string;
    readonly birthDate: Date;
    firstName: string;
    lastName: string;

    constructor(ssn: string, birthDate: Date, firstName: string, lastName: string) {
        this.ssn = ssn;
        this.birthDate = birthDate;
        this.firstName = firstName;
        this.lastName = lastName;
    }

    getFullName(): string {
        return `${this.firstName} ${this.lastName}`;
    }
}

let personOne = new Person('171-28-0926', new Date(2001, 4, 14), 'John','Doe');
console.log(personOne.getFullName());

let personTwo = new Person('262-432-8971', new Date(2004, 6, 12), 'Jimmy', 'Jam')
console.log(personTwo.getFullName());
// console.log(person.ssn) -> Property 'ssn' is private and only accessible within class 'Person'.
// person.birthDate = new Date(1991, 12, 25); -> Cannot assign to 'birthDate' because it is a read-only property.

/*
Access Modifiers

Access modifiers change the visibility of the properties and methods of a class. 
TypeScript provides four access modifiers:

private
protected
public
readonly
*/

/*
The private modifier
The private modifier limits the visibility to the same-class only. 
When you add the private modifier to a property or method, you can access that property or method within the same class. 
Any attempt to access private properties or methods outside the class will result in an error at compile time.
*/

/*
The public modifier
The public modifier allows class properties and methods to be accessible from all locations. 
If you don’t specify any access modifier for properties and methods, they will take the public modifier by default.
*/

/*
The protected modifier
The protected modifier allows properties and methods of a class to be accessible within same class and within subclasses.

When a class (child class) inherits from another class (parent class), it is a subclass of the parent class.
The TypeScript compiler will issue an error if you attempt to access the protected properties or methods from anywhere else.
To add the protected modifier to a property or a method, you use the protected keyword. 
*/

// note that declaring the instance variables is optional 
class Car {
    // When you consider the visibility of properties and methods, 
    // it is a good practice to start with the least visible access modifier, which is private.
    constructor(private insurance_policy: string, protected license_number: number, public color: string) {
        this.license_number = license_number;
        this.insurance_policy = insurance_policy;
        this.color = color;
    }

    changeCarColor(newColor: string): void {
        this.color = newColor
    }
}

/*
Instance variable

In object-oriented programming with classes, an instance variable is a variable defined in a class, 
for which each instantiated object of the class has a separate copy, or instance. 
An instance variable has similarities with a class variable, but is non-static.

... A class variable is any variable declared with the static modiefer of which a single copy exists, 
regardless of how many instances of the class exist
They are declared outside of a method, constructor or other block.
*/

/*
Static properties
Unlike an instance property, a static property is shared among all instances of a class.

To declare a static property, you use the static keyword. 
To access a static property, you use the className.propertyName syntax. For example:
*/

class Employee {
    // In this example, the headcount is a static property that initialized to zero. 
    // Its value is increased by 1 whenever a new object is created.
    static headcount: number = 0;
    // private static headcount: number = 0;
    // ^  its value cannot be changed outside of the class without creating a new Employee object.
    // Property 'headcount' is private and only accessible within class 'Employee'. -> is the error that would be thrown 

    constructor(
        private name: string,
        private jobTitle: string) 
        {
            Employee.headcount++;
        }
    
    /*
    Static methods
    Similar to the static property, a static method is also shared across instances of the class. 
    To declare a static method, you use the static keyword before the method name. For example:
    */
    
   // add the getHeadcount() static method that returns the value of the headcount static property.
    public static getHeadcount() {
        return Employee.headcount;
    }
}

let joe = new Employee('George', 'software engineer')
// console.log(joe.headcount) // error: Property 'headcount' is a static member of type 'Employee'.
// To call a static method, you use the className.staticMethod() syntax. For example:
console.log(Employee.headcount) // 1
let frank = new Employee('Jackson', 'solutions enginer')
console.log(Employee.headcount) // 2
Employee.headcount = 8;
console.log(Employee.headcount) // 8


//////////////


/*
An abstract class is typically used to define common behaviors for derived classes to extend. 
Unlike a regular class, an abstract class cannot be instantiated directly.

To declare an abstract class, you use the abstract keyword:
*/

/*
Typically, an abstract class contains one or more abstract methods.

An abstract method does not contain implementation. It only defines the signature of the method without including the method body. 
An abstract method must be implemented in the derived class.

The following shows the Employee abstract class that has the getSalary() abstract method:
*/

// other classes come from an abstract class
abstract class ProffessionalAthlete {
    // The constructor declares the firstName and lastName properties.
    constructor(private firstName: string, private lastName: string, countryTaxRate: number) {
    }
    // The getSalary() method is an abstract method. 
    // The derived class will implement the logic based on the type of employee
    abstract getSalary(): number
    // The getFullName() and compensationStatement() methods contain detailed implementation. 
    // Note that the compensationStatement() method calls the getSalary() method.
    get fullName(): string {
        return `${this.firstName} ${this.lastName}`;
    }
    compensationStatement(): string {
        return `${this.fullName} makes ${this.getSalary()} a month.`;
    }
}

// Because the Employee class is abstract, you cannot create a new object from it. 
// The following statement causes an error:
// let nbaPlayer = new ProffessionalAthlete('Frank', 'Ocean');
// error TS2511: Cannot create an instance of an abstract class.

/*
In this FullTimeEmployee class, the salary is set in the constructor. Because the getSalary() is an abstract method of the Employee class, the FullTimeEmployee class needs to implement this method. In this example, it just returns the salary without any calculation.

The following shows the Contractor class that also inherits from the Employee class:

*/

class NbaPlayer extends ProffessionalAthlete{
    constructor(firstName: string, lastName: string, private countryTaxRate: number, private salary: number) {
        super(firstName, lastName, countryTaxRate);
    }
    getSalary(): number {
        // Property 'countryTaxRate' does not exist on type 'NbaPlayer'.
            // this error will occur if you add something to NbaPlayer constructor that is not in the ProfessionalAthlete constuctor 
            // or you don't have it as private but try to access it using 'this'

        // Property 'countryTaxRate' is private and only accessible within class 'ProffessionalAthlete'.
            // this error will occur if countryTaxRate is in the ProffessionalAthlete constructor but not the in the 'super' for NbaPlayer
        return this.salary * this.countryTaxRate;
    }
}

class NFLPlayer extends ProffessionalAthlete{
    constructor(firstName: string, lastName: string, private countryTaxRate: number, private salary: number) {
        super(firstName, lastName, countryTaxRate);
    }
    getSalary(): number {
        return this.salary * this.countryTaxRate + 500;
    }
}

let exampleOne = new NbaPlayer('Lebron', 'james', 0.4, 1000)
console.log(exampleOne.compensationStatement())
let exampleTwo = new NFLPlayer('Tom','Brady', 0.4,  1000)
console.log(exampleTwo.compensationStatement())

/*

Summary
Abstract classes cannot be instantiated.
An Abstract class has at least one abstract method.
To use an abstract class, you need to inherit it and provide the implementation for the abstract methods.

*/

/*
TypeScript Getters and Setters

The getters and setters allow you to control the access to the properties of a class.

For each property:

A getter method returns the value of the property’s value. A getter is also called an accessor.
A setter method updates the property’s value. A setter is also known as a mutator.
A getter method starts with the keyword get and a setter method starts with the keyword set.
*/

class Invididual {
     // have the access modifiers for these properties be private
    // the underscore is likely just semantics
    private _personality: string;
    private _birthPlace: string;

    public get personality() {
        return this._personality;
    }

    public set personality(moodChange: string) {
        if (moodChange === '') {
            throw new Error("moood field can't be left blank");
        }
        this._personality = moodChange;
    }

    public get birthPlace() {
        return this._birthPlace;
    }

    public set birthPlace(newIdentity: string) {
        if (!newIdentity) {
            throw new Error('Invalid entry - please enter a birthplace for your fake ID.');
        }
        this._birthPlace = newIdentity;
    }

    public personalInfor(): string {
        return `${this.personality} ${this.birthPlace}`;
    }
}

let sampleInvididual = new Invididual();

sampleInvididual.personality = 'Angry';
console.log(sampleInvididual.personality);

sampleInvididual.personality = 'Sad';
console.log(sampleInvididual.personality);
