/*

A module executes within its own scope, not in the global scope. 
It means that when you declare variables, functions, classes, interfaces, etc., in a module, 
they are not visible outside the module unless you explicitly export them using export statement.

On the other hand, if you want to access variables, functions, classes, etc., from a module, 
you need to import them using the import statement.

*/

export interface ValidatorOne {
    isValid(s: string): boolean
}

////

interface ValidatorTwo {
    isValid(s: string): boolean
}

export { ValidatorTwo };

////

interface ValidatorThree {
    isValid(s: string): boolean
}

export { ValidatorThree as StringValidator };