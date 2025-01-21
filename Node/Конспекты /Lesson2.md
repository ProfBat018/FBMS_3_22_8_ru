# Темы урока:

- npm workspaces
- Error Handling
- - System Errors
- - User-Specified Errors
- - Assertion Errors
- - JS Errors
- Async Programming in Node.js
- - Event Emitter
- - Event Loop
- - Callbacks
- - Promises
- - Async/Await
- - Timers
- - setImmediate
- - process.nextTick

# npm workspaces

`npm workspaces` - это функция, которая позволяет вам управлять несколькими пакетами в одном репозитории. `npm workspaces` позволяет вам создавать зависимости между пакетами, что упрощает разработку и тестирование многопакетных проектов.

```json
{
  "name": "my-workspace",
  "version": "1.0.0",
  "workspaces": ["packages/*"],
  "dependencies": {
    "express": "^4.17.1"
  }
}
```

Тут неваожно вы пишите на `Node.js` или же на `React`. Если у вас есть несколько похожих проектов с одинаоковыми зависимостями, то `npm workspaces` поможет вам управлять ими.

Чтобы создать рабочее пространство, вам нужно создать файл `package.json` в корневом каталоге вашего проекта и добавить свойство `workspaces`, которое указывает на каталоги, содержащие ваши пакеты.

# Error Handling

`Error Handling` - это процесс обработки ошибок в вашем приложении. В Node.js ошибки могут возникать из различных источников, таких как системные ошибки, ошибки, указанные пользователем, ошибки утверждения и ошибки JavaScript.

## System Errors

`System Errors` - это ошибки, которые возникают при работе с системными ресурсами, такими как файловая система, сеть и процессы. В Node.js системные ошибки обычно генерируются как исключения, которые могут быть перехвачены с помощью блока `try...catch`.

```bash
EACCES - Permission denied
EADDRINUSE - Address already in use
ECONNRESET - Connection reset by peer
EEXIST - File exists
EISDIR - Is a directory
EMFILE - Too many open files in system
ENOENT - No such file or directory
ENOTDIR - Not a directory
ENOTEMPTY - Directory not empty
ENOTFOUND - DNS lookup failed
EPERM - Operation not permitted
EPIPE - Broken Pipe
ETIMEDOUT - Operation timed out
```

## User-Specified Errors

`User-Specified Errors` - это ошибки, которые создаются разработчиком приложения для обозначения ошибочных ситуаций. В Node.js пользовательские ошибки обычно создаются с помощью конструктора `Error`.

```js
class ApplicationError extends Error {
  constructor(message) {
    super(message);
    // name is set to the name of the class
    this.name = this.constructor.name;
  }
}

class ValidationError extends ApplicationError {
  constructor(message, cause) {
    super(message);
    this.cause = cause;
  }
}
```

## Assertion Errors

`Assertion Errors` - это ошибки, которые возникают при использовании утверждений в вашем коде. В Node.js утверждения обычно создаются с помощью функции `assert`. `Assert` - это модуль Node.js, который предоставляет функции для проверки условий и генерации ошибок, если условие не выполняется. По сути говоря, это быстрый способ проверки с пробросом ошибки.

```js
const assert = require("assert");

function add(a, b) {
  assert(typeof a === "number", "a must be a number");
  assert(typeof b === "number", "b must be a number");
  return a + b;
}
```

## JS Errors

`JS Errors` - это ошибки, которые возникают при выполнении JavaScript кода. В Node.js JavaScript ошибки обычно генерируются как исключения, которые могут быть перехвачены с помощью блока `try...catch`.

```js
try {
  throw new Error("Something went wrong");
} catch (error) {
  console.error(error.message);
}
```

```bash
EvalError
RangeError
ReferenceError
SyntaxError
TypeError
URIError
```

# Async Programming in Node.js

`Async Programming` - это способ программирования, который позволяет выполнять асинхронные операции без блокировки основного потока выполнения. В Node.js асинхронное программирование обычно выполняется с помощью колбэков, обещаний, асинхронных/ожидаемых функций и таймеров. Так как сам по себе Js и Node.js явля.тся однопоточными. Тут асинхронность реализуется за счет реактивности, а не многопоточности, хоть и в `Node.js` внедрен модуль `Libuv`, который позволяет работать с несколькими потоками.

## Event Emitter

`Event Emitter` - это объект, который генерирует события и позволяет другим объектам подписываться на эти события. В Node.js `Event Emitter` - это класс, который предоставляет методы для генерации событий и подписки на события. `Event Emitter` - это основной механизм Node.js для асинхронного программирования.

```js
const EventEmitter = require("events");

class MyEmitter extends EventEmitter {}

const myEmitter = new MyEmitter();

myEmitter.on("elvin", () => {
  console.log("an event occurred!");
});

myEmitter.emit("elvin");
```

## Event Loop

`Event Loop` - это механизм Node.js, который позволяет выполнять асинхронный код без блокировки основного потока выполнения. `Event Loop` - это цикл, который выполняется в основном потоке Node.js и обрабатывает события, такие как таймеры, колбэки и обещания. `Event Loop` - это основной механизм Node.js для асинхронного программирования. Вот иллюстрация работы `Event Loop`:

![](./loop.jpeg)

Для того чтобы подробнее разорбать давайте разбереся с каждым этапом:

- Timers
- Pending Callbacks
- Idle, Prepare
- Poll
- Check
- Close Callbacks

`Timers` - это таймеры, которые создаются с помощью функций `setTimeout` и `setInterval`. `Timers` - это асинхронные операции, которые выполняются после задержки.

`Pending Callbacks` - это колбэки, которые ожидают выполнения.

Напоминаю что `Callback` - это функция, которая передается в другую функцию в качестве аргумента и вызывается после завершения асинхронной операции. Вот пример:

```js
console.log("Start");

const foo = (callback) => {
  console.log("Foo started...");
  callback();
  console.log("Foo ended...");
};

foo(() => {
  console.log("Callback");
});

console.log("End");
```

`Idle, Prepare` - это асинхронные операции, которые выполняются перед выполнением операций ввода-вывода.

`Poll` - это этап, который выполняет операции ввода-вывода. `Poll` - это асинхронные операции, которые выполняются во время выполнения операций ввода-вывода.

`Check` - это этап, который выполняет колбэки, которые были добавлены с помощью функции `setImmediate`. `Check` - это асинхронные операции, которые выполняются после выполнения операций ввода-вывода.

`Close Callbacks` - это колбэки, которые были добавлены с помощью функции `close`. `Close Callbacks` - это асинхронные операции, которые выполняются после завершения работы.

## Promises

`Promises` - это объекты, которые представляют асинхронные операции и позволяют обрабатывать успешное выполнение или ошибку. В Node.js обещания обычно создаются с помощью конструктора `Promise`. `Promise` - это асинхронная операция, которая может быть выполнена или отклонена. Вот пример с функцией `fetch`:

```js
console.log("Start");

const fetchRes = fetch("https://jsonplaceholder.typicode.com/todos/1");

fetchRes
  .then((response) => response.json())
  .then((json) => console.log(json))
  .catch((error) => console.error(error));

console.log("End");
```

```js 

// resolve, reject - это функции, которые передаются в конструктор Promise

const promise = new Promise((resolve, reject) => {
  setTimeout(() => {
    resolve("Success!");
  }, 500);

  setTimeout(() => {
    reject("Error!");
  }, 1000);
});

```

```js
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
```

## setImmediate

`setImmediate` - это функция, которая гарантированно выполнится первым после завершения текущего цикла событий.

```js
const baz = () => console.log("baz");
const foo = () => console.log("foo");
const zoo = () => console.log("zoo");
const start = () => {
  console.log("start");
  setImmediate(baz);
  new Promise((resolve, reject) => {
    resolve("bar");
  }).then((resolve) => {
    console.log(resolve);
    process.nextTick(zoo);
  });
  process.nextTick(foo);
};
start();
```

## process.nextTick

`process.nextTick` - это функция, которая позволяет выполнить колбэк после завершения текущей операции. `process.nextTick` - это асинхронная операция, которая выполняется после завершения текущей операции. Разница между `process.nextTick` и `setImmediate` заключается в том, что `process.nextTick` выполняется перед выполнением операций ввода-вывода, а `setImmediate` выполняется после выполнения операций ввода-вывода.

```js

const bar = () => console.log("bar");


