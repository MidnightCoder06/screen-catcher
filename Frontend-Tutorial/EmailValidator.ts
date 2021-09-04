import { ValidatorOne } from './Validator';
import type {alphanumeric} from './UtilityTypes';
import * as allTheFunctions from './UtilityFunctions';
import { lion as lionSpeaks } from './UtilityFunctionsTwo';
import Kanye from './UtilityFunctionsThree';


class EmailValidator implements ValidatorOne {
    isValid(s: string): boolean {
        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        return emailRegex.test(s);
    }
}

let email = 'john.doe@typescripttutorial.net';
let validator = new EmailValidator();
let result = validator.isValid(email);



export { EmailValidator };

/*

TypeScript allows each module to have one default export. 
To mark an export as a default export, you use the default keyword.

Named Exports
*can use multiple values
*must use the exported name when importing

Default Exports
*export a single value
*can use any name when importing 

*/

console.log(lionSpeaks())
console.log(allTheFunctions.cow())
console.log(allTheFunctions.goat())
console.log(allTheFunctions.dog())
console.log(Kanye())

function sayHello(name: alphanumeric) {
    return `Hi there ${name}`
}
sayHello('George')


console.log(result);