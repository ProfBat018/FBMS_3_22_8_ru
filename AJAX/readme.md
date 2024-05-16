# AJAX - Asyncronous JavaScript and XML

Чтобы пройти его надо сперва разобраться с асинхроноостью в JS. Тут все не так просто, как в C# например.

Нужно начать с того, что асинхронность в JS реализуется с помощью колбеков. Колбек - это функция, которая передается в качестве аргумента в другую функцию. Когда функция, в которую передается колбек, завершает свою работу, она вызывает колбек.

Вот пример callback функции:

```js
function calculate(a, b, callback) {
  let result = a + b;
  callback(result);
}

calculate(2, 3, (result) => {
  console.log(result);
});
```

В этом примере функция calculate принимает два числа и колбек. Она складывает числа и передает результат в колбек. При вызове функции calculate передается анонимная функция, которая выводит результат в консоль.

Можно задать ризонный вопрос ?

### Как это связано с асинхронностью ?

Все просто. Когда вы делаете запрос на сервер, JS не ждет ответа, а продолжает выполнять код. Когда ответ приходит, вызывается колбек.

### Немного подкапотных моментов

В JS нет такой системы асинхронности как в том же самом C#. Javascript по умолчанию асинхронен. Также тут нет многопоточности. Все асинхронные операции выполняются в одном потоке. Это значит, что если одна операция занимает много времени, все остальные операции будут ждать ее завершения. Вы должны понимать что ваш код запускается внутри браузера, соответственно мы не можем просить больше потоков. `Node.js` например в свою очередь
извлек движок `V8` и добавил к нему `libuv` - библиотеку для работы с асинхронными операциями. Реализовано это на языке `C++`.

Вместо привычного нам класса `Task` тут есть класс `Promise` который представляет собой объект, который может быть в состоянии ожидания, выполнения или отклонения.

### Пример использования Promise

```js
let res = fetch("https://jsonplaceholder.typicode.com/posts");

console.log(`Start of fetch`);

res
  .then((response) => {
    return response.json();
  })
  .then((data) => {
    console.log(data);
  })
  .catch((error) => {
    console.log(error);
  });
```

Функция fetch возращает `Promise`, ровно так же как и `result.json()`. У этого объекта есть методы `then` и `catch`. `then` вызывается, когда `Promise` переходит в состояние `resolved`, а `catch` вызывается, когда `Promise` переходит в состояние `rejected`.

Тут есть один момент, который стоит упомянуть. `Promise` не может быть отменен. Если вам нужно отменить запрос, вам придется использовать `AbortController`:

```js
let controller = new AbortController();
let signal = controller.signal;

fetch("https://jsonplaceholder.typicode.com/posts", { signal })
  .then((response) => {
    return response.json();
  })
  .then((data) => {
    console.log(data);
  })
  .catch((error) => {
    console.log(error);
  });

controller.abort();
```

Тут также есть ключевое слово `async` и `await`. `async` используется для определения асинхронной функции, а `await` используется для ожидания выполнения промиса.

```js
async function fetchData() {
  let response = await fetch("https://jsonplaceholder.typicode.com/posts");
  let data = await response.json();
  console.log(data);
}

fetchData();
```

## Garbage Collection in JS

В JS есть механизм сборки мусора. Он автоматически удаляет объекты, которые больше не используются. Это позволяет избежать утечек памяти.
Интересный момент заключается в том, что работает этот механизм почти так же как и в C#. В JS есть `Mark-and-sweep` алгоритм. Он работает следующим образом:

1. **Mark** - алгоритм помечает все объекты, на которые есть ссылки.
2. **Sweep** - алгоритм удаляет все объекты, на которые нет ссылок.

Вот пример утечки памяти:

```js
let element = document.getElementById("element");

function doSomething() {
  let element = document.getElementById("element");
  // do something
}

setInterval(() => {
  doSomething();
}, 1000);
```

В этом примере функция `doSomething
` создает новую переменную `element` каждый раз, когда вызывается. Это приводит к утечке памяти, так как старые объекты не удаляются.

## Interlinked objects

```javascript
function marry(man, woman) {
  woman.husband = man;
  man.wife = woman;

  return {
    father: man,
    mother: woman,
  };
}

let john = { name: "John" };
let ann = { name: "Ann" };

let family = marry(john, ann);

```

![Interlinked objects](./assets/Screenshot%202024-05-16%20at%2009.22.11.png)

![Interlinked objects](./assets/Screenshot%202024-05-16%20at%2009.26.26.png)

![Interlinked objects](./assets/Screenshot%202024-05-16%20at%2009.27.27.png)


