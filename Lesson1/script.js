// Block vs Gloval vs Function Scope

// Block scope - это область видимости переменной, которая доступна только внутри блока кода, в котором она была объявлена.
// Global scope - это область видимости переменной, которая доступна в любом месте вашего кода.
// Function scope - это область видимости переменной, которая доступна только внутри функции, в которой она была объявлена.

//#region First
// let globalVar = "I am a global variable"; // Global scope

// function exampleFunction() {
//   let localVar = "I am a local variable"; // Function scope

//   if (true) {
//     let blockVar = "I am a block variable"; // Block scope
//     console.log(blockVar); // Output: I am a block variable
//   }

//   console.log(localVar); // Output: I am a local variable
//   console.log(blockVar); // Error: blockVar is not defined
//   console.log(globalVar); // Output: I am a global variable
// }

// console.log(globalVar); // Output: I am a global variable
// console.log(localVar); // Error: localVar is not defined

// var a = exampleFunction.call();

// console.log(a.localVar);

//#endregion

//#region Second

// function Func1() {
//   let localVar = "I am a local variable"; // Function scope

//   function Func2() {
//     let blockVar = "I am a block variable"; // Function scope

//     console.log(localVar); // Output: I am a local variable
//   }
//   Func2();
// }

// Func1();

//#endregion

//#region Third

/*
Object в JavaScript - это тип данных, который представляет собой коллекцию ключей и значений.

Встроенные типы данных в JavaScript:
1. Number
2. String
3. Boolean
3. Object
4. Function
5. Symbol
6. BigInt
7. Math 
8. Date
9. Array
10. RegExp
and more...
*/

// let person = {
//   name: "John",
//   age: 30,
//   isMarried: false,
//   sayHello: function () {
//     console.log(this.age);
//   },
//   sayHello2: () => {
//     console.log(this.age);
//   },
// };

// console.log(person.name); // Output: John

// person.sayHello(); // Output: 30
// person.sayHello2(); // Output: undefined

// var m = Math.PI;
// console.log(m);

// var s1 = Symbol("rustam");
// var s2 = Symbol("rustam");

// console.log(s1 === s2); // Output: false

// console.log(s1.description);

// var i1 = Number(1);
// var i2 = Number(1);

// console.log(i1 === i2); // Output: true

//#endregion

// Оператор typeof возвращает строку, указывающую тип операнда.

// console.log(typeof 1); // Output: number
// console.log(typeof "Hello"); // Output: string

//#region Прототипы объектов в JavaScript

/*
function Person(name, age) {
  this.name = name;
  this.age = age;
}

let person1 = new Person("John", 30);

console.log(person1); // Output: Person { name: 'John', age: 30 }

Person.prototype.sayHello = function () {
  console.log(`${this.name} says hello`);
};

person1.sayHello(); // Output: John says hello

// Пример 2

class Car {
  constructor(brand, model) {
    this.brand = brand;
    this.model = model;
  }

  display() {
    console.log(`${this.brand} ${this.model}`);
  }
}

let car1 = new Car("Ford", "Mustang");

console.log(car1); // Output: Car { brand: 'Ford', model: 'Mustang' }

Car.prototype.horn = function () {
  console.log("Beep Beep");
};

Car.prototype.a = 10;

car1.horn(); // Output: Beep Beep

*/
//#endregion


class Car {
  constructor(brand, model) {
    this.brand = brand;
    this.model = model;
  }

  display() {
    console.log(`${this.brand} ${this.model}`);
  }
}

let c1 = new Car("Ford", "Mustang");

c1.engine = "V8";
c1.accelerate = function () {
  console.log("Vroom Vroom");
};

console.log(c1.engine);
c1.accelerate();