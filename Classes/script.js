// const Person = class {
//     constructor(name, age) {
//         this.name = name;
//         this.age = age;
//     }
//     greet() {
//         console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
//     }
// }

// let person = new Person('John', 30);

// Difference between class expression and class declaration in JavaScript

// Class declaration

// class Person {
//     constructor(name, age) {
//         this.name = name;
//         this.age = age;
//     }

//     greet() {
//         console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
//     }
// }

// let person = new Person('John', 30);

// Class expression

// const Person = class {
//     constructor(name, age) {
//         this.name = name;
//         this.age = age;
//     }

//     greet() {
//         console.log(`Hello, my name is ${this.name} and I am ${this.age} years old.`);
//     }
// }

// let person = new Person('John', 30);

// In the above example, we have defined a class using class

// declaration and class expression. Both are similar in functionality but the main difference is that class declaration is hoisted and class expression is not hoisted.

// class Person {
//     constructor(name, age) {
//         this.name = name;
//         this.age = age;
//     }
//     static create(name, age) {
//         return new Person(name, age);
//     }
// }

// let person = Person.create('John', 30);

// console.log(person); // Person { name: 'John', age: 30 }

// class Person {
//   constructor(name, age) {
//     this._name = name;
//     this._age = age;
//   }
//   get name() { // Можно обращаться как к свойству, а не как к методу
//     return this._name;
//   }
//   set name(value) { // Можно обращаться как к свойству, а не как к методу
//     this._name = value;
//   }
// }

// let person = new Person("John", 30);

// console.log(person.name); // John

// person.name = "Elvin"; // person.name('Elvin');

// console.log(person.name); // Elvin


let sayHiMixin = {
    sayHi() {
      console.log(`Hello ${this.name}`);
    },
  };
  
  class User {
    constructor(name) {
      this.name = name;
    }
  }
  
  Object.assign(User.prototype, sayHiMixin);
  
  let user = new User("John");
  
  user.sayHi();