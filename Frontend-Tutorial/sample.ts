// https://www.valentinog.com/blog/typescript/

// An interface in TypeScript is like a contract. 
// Or put it another way an interface is like a "model" for your entity.
// an interface in TypeScript is the shape of something, most of the times a complex object.

interface Link {
  url: string;
  description?: string;
  id?: number;
  // [index: string]: string | number | undefined;
}

// Extending an interface means borrowing its properties and widening them for code reuse.
interface TranslatedLink extends Link {
  language: string;
}

// you can define your own custom types 
type Authenticated = boolean | number | string;

function filterByTerm(input: Link[], searchTerm: string = "fallback value") {
  if (!searchTerm) throw Error("searchTerm cannot be empty");
  if (!input.length) throw Error("input cannot be empty");
  const regex = new RegExp(searchTerm, "i");
  return input.filter(function(arrayElement) {
    return arrayElement.url.match(regex);
  });
}

const term: string = "java"

const sampleTransaltedLink = {
  url: "www.valentinog.com/typescript/",
  description: "example of a transalted link",
  id: 1,
  language: "fr"
}

filterByTerm(
  [{ url: "string1", id:  1234}, { url: "string2" }, { url: "string3", description: "lit content" }, sampleTransaltedLink],
  term
);


function sampleTwo(name: string): string {
  console.log(name)
  return name
}

sampleTwo("the goat")
