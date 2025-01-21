// import {add, subtract} from './math.mjs';
// const { add, subtract } = require("./math");

// console.log(add(1, 2)); // 3
// console.log(subtract(2, 1)); // 1

// global.foo = () => {
//   console.log("foo");
// };

// console.log(add(1, 2)); // foo 3

// const EventEmitter = require("events");

// class MyEmitter extends EventEmitter {}

// const myEmitter = new MyEmitter();

// myEmitter.on("event", () => {
//   console.log("an event occurred!");
// });

// myEmitter.emit("event");

// console.log("Start");

// const foo = (callback) => {
//   console.log("Foo started...");
//   callback();
//   console.log("Foo ended...");
// };

// foo(() => {
//   console.log("Callback");
// });

// console.log("End");

// console.log("Start");

// const fetchRes = fetch("https://jsonplaceholder.typicode.com/todos/1");

// fetchRes
//   .then((response) => {
//     console.log(`Status: ${response.status}`);
//     response.json();
//   })
//   .then((json) => {
//     console.log("JSON");
//     console.log(json);
//   })
//   .catch((error) => console.error(error));

// console.log("End");

console.log("Start");

async function foo() {
  console.log("Async Foo started...");

  const fetchRes = await fetch("https://jsonplaceholder.typicode.com/todos/1");

  console.log(`Status: ${fetchRes.status}`);

  const json = await fetchRes.json();

  console.log(`JSON: ${json}`);

  console.log("Async Foo ended...");
}

foo();

console.log("End");
