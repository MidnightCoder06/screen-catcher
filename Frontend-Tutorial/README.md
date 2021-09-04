initialized package.json via `npm init -y`

dependencies: 
* npm i typescript

Run `tsc` in project directory to compile typescript into javascript.
Browsers don't understand javascript so this is necessary.

tsc stands for TypeScript compiler and whenever the compiler runs it will look for a file named tsconfig.json in the project folder.

* npm run tsc -- --init

The key target determines the desired JavaScript version, ES5 (or a newest release).

Depending on the level of "strictness" for tsconfig.json the compiler and the editor will comply if you don't add the appropriate type annotations to your code (more on this in a minute).

With strict set to true TypeScript enforces the maximum level of type checks on your code enabling amongst the other:

noImplicitAny true: TypeScript complains when variables do not have a defined type

alwaysStrict true: strict mode is a safe mechanism for JavaScript which prevents accidental global variables, default this binding, and more. When alwaysStrict is set true TypeScript emits "use strict" at the very top of every JavaScript file.

static checking in JavaScript, that is, "testing" the correctness of your code before it even runs.

execute js files via: `node file-name.js`
execute ts files via: `tsc helloworld.ts`

execute all ts files via: `npm run tsc`