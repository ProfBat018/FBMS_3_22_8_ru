//#region Exception handling

// Исключения в JavaScript, по сути такие же, как и в других языках программирования.
// В JavaScript исключения обрабатываются с помощью конструкции try...catch.

// try...catch

//// Объект ошибки содержит следующие свойства:
//// name - имя ошибки.
//// message - текстовое сообщение об ошибке.
//// stack - стек вызовов.

// try {
//   throw new Error("Whoops!");
// } catch (e) {
//   console.log(e.message);
//   console.log(e.name);
//   console.log(e.stack);
// }

// try {
//   throw 404; // так лучше не делать
// } catch (e) {
//   console.log(e);
// }

//// Чтобы создать свою ошибку, можно использовать новый класс

// class MyError extends Error {
//   constructor(message) {
//     super(message); // делегирование конструктора
//     this.name = this.constructor.name;
//   }

//   showFullInfo() {
//     return `${this.name}: ${this.message}`;
//   }
// }

// try {
//   throw new MyError("My custom error!");
// } catch (e) {
//   console.log(e.showFullInfo());
//   console.log(e.name);
// }

//// finally - выполняется всегда, независимо от того, было ли исключение или нет

//#endregion

//#region Functions

//// параметры функции

// function showMessage(from, text) {
//   console.log(`${from}: ${text}`);
// }

// showMessage("Ann", "Hello!");

//// Параметры по умолчанию

// function showMessage(from, text = "no text") {
//   console.log(`${from}: ${text}`);
// }

// showMessage("Ann");

//// Оператор spread

// function showName(firstName, lastName, ...rest) {
//   console.log(`${firstName} ${lastName}`);
//   console.log(rest);
// }

// showName("Ann", "Smith", "London", "UK");

// свойство arguments

// function showName() {
//   console.log(arguments);
// }
// showName("Ann", "Smith", "London", "UK");

// let a = function () {
//   console.log("Hello!");
// };

// let b = () => {
//   console.log("Hello!");
// };

// a();
// b();

// let obj = {
//   name: "Ann",
//   showName: function () {
//     console.log(this.name);
//   },
//   showName2: () => {
//     console.log(this.name);
//   },
// };

// obj.showName();
// obj.showName2();

// (function aloha() {
//   let a = 5;
//   console.log("Aloha!");
// })();

//#endregion

//#region Closures

// Замыкание - это функция, которая ссылается на свободные переменные в своей области видимости.

// function createCounter() {
//   let counter = 0;

//   return function () {
//     return ++counter;
//   };
// }

// let counter = createCounter();

// console.log(counter());
// console.log(counter());
// console.log(counter());

//// call & apply & bind

// let obj = {
//   name: "Ann",
//   showName: function () {
//     console.log(this.name);
//   },
// };

// // call

// let obj2 = {
//   name: "Bob",
// };

// obj.showName.call(obj2, 5);



//// apply 

// let obj = {
//   name: "Ann",
//   showName: function (n1, n2, n3) {
//     console.log(this.name);
//     console.log(n1, n2, n3);
//     console.log(arguments);
//   },
// };

// let obj2 = {
//   name: "Bob",
// };


// obj.showName.apply(obj2, [5, 6, 7]);


//// bind

let obj = {
  name: "Ann",
  showName: function () {
    console.log(this.name); 
  },
};

let obj2 = {
  name: "Bob",
};

let showName = obj.showName.bind(obj2);

showName();