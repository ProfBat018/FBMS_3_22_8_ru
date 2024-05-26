# Type Inference

`Type inference` - это процесс, который позволяет компилятору определить тип переменной на основе значения, которое ей присваивается. То есть в `typescript` не обязательно указывать тип переменной, так как компилятор сам определит его.

```typescript
let x = 10; // x: number

let y = "Hello"; // y: string
```

# Type compatibility

`Type compatibility` - это процесс, который позволяет использовать переменные с разными типами в разных частях программы.

```typescript
interface Point {
  x: number;
  y: number;
}

let p1: Point = { x: 10, y: 20 };
let p2: { x: number; y: number; z: number } = p1;

console.log(p2.x);
```

# Union types

`Union types` - это процесс, который предоставляет несколько типов для переменной.

```typescript
let x: number | string = 10;

x = "Hello";
```

# Intersection types

`Intersection types` - это процесс пересечения двух типов.

```typescript
interface A {
  x: number;
  y: number;
}

interface B {
  x: number;
  z: number;
}

let c: A & B = { x: 10, y: 20, z: 30 };
```

# Type aliases

`Type aliases` - это процесс, который позволяет использовать переменные с разными типами в разных частях программы.

```typescript
// Пример из SQL запроса

// select name as FirstName, age as Age from users

type Name = string;
type Age = number;
type User = { name: Name; age: Age };

const user: User = { name: "John", age: 30 };
```

# keyof operator

`keyof operator` - это ключевое слово, которое позволяет получить все ключи объекта.

```typescript
interface User {
  name: string;
  age: number;
  location: string;
}

type UserKeys = keyof User; // "name" | "age" | "location"

const key: UserKeys = "name";
```

# typeof & instanceof

`typeof & instanceof` - это ключевые слова, которые позволяют проверить тип переменной.

```typescript
const x = 10;

if (typeof x === "number") { // GetType().Name
  console.log("x is a number");
}

class Foo {
  bar() {}
}

const a = new Foo();

if (a instanceof Foo) {
  console.log("foo is an instance of Foo");
}
```


# Non-null assertion operator

`Non-null assertion operator` - это оператор, который позволяет убедиться, что переменная не равна `null`.

```typescript

let x: number | null = 10; // int? x = 10;

console.log(x! + 10); 

```

## Satisfies keyword 

`Satisfies keyword` - это ключевое слово, которое позволяет проверить, удовлетворяет ли переменная определенному типу.

```typescript

type A = { x: number; y: number };

const a = { x: 10, y: 20, z: 30 };

if (a satisfies A) {
  console.log("a satisfies A");
}
```



