type alphanumeric = string | number;

function typeofExample(a: alphanumeric, b: alphanumeric) {
    if (typeof a === 'number' && typeof b === 'number') {
        return a + b;
    }

    if (typeof a === 'string' && typeof b === 'string') {
        return a.concat(b);
    }

    throw new Error('Invalid arguments. Both arguments must be either numbers or strings.');
}

/*
instanceof
Similar to the typeof operator, TypeScript is also aware of the usage of the instanceof operator.
For example:
*/

// First, declare the Customer and Supplier classes.

class Customer {
    isCreditAllowed(creditScore?: number): boolean {
      if (creditScore) {
        return creditScore > 700 ? true : false
      }
      return false
    }
}

class Supplier {
    isReliable(delays: number): boolean {
       return delays < 2 ? true : false
    }
}

// Second, create a type alias BusinessPartner which is a union type of Customer and Supplier

type BusinessPartner = Customer | Supplier;

// Third, declare a function signContract() that accepts a parameter with the type BusinessPartner.

function signContract(partner: BusinessPartner, creditScore?: number, delays?: number) : string {
    let message: string;
    // Finally, check if the partner is an instance of Customer or Supplier
    if (partner instanceof Customer) {
        message = partner.isCreditAllowed(creditScore) ? 'Sign a new contract with the customer' : 'Credit issue';
        return message;
    }

    if (partner instanceof Supplier) {
        message = partner.isReliable(5) ? 'Sign a new contract the supplier' : 'Need to evaluate further';
        return message;
    }

    /*
    in
    The in operator carries a safe check for the existence of a property on an object. You can also use it as a type guard. For example:
    */
   if ('isCreditAllowed' in partner) {
       console.log('here is an example of the in operator')
   }

   
}



