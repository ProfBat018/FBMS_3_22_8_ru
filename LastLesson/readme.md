# Advanced Types

## Mapped Types

В typescript есть возможность создавать новые типы на основе уже существующих. Это можно сделать с помощью mapped types.

```typescript
type MyReadonly<T> = {
  readonly [P in keyof T]: T[P]; // Mapped Type
};

let obj = { x: 10, y: 20 };

let readonlyObj: MyReadonly<typeof obj> = obj;

console.log(readonlyObj);
```

Как мы уже разбирали с вами на прошлом уроке в этом языке есть множество конструкция для копирования и видозменения уже существующих типов.

## Conditional Types

```typescript
type Extends<T, U> = T extends U ? T : U;

type A = Extends<string, any>; // type A is 'string'
type B = Extends<any, string>; // type B is 'string'
```

## Literal Types 

```typescript
type Age = 42;

let age: Age = 42; // ok
let age: Age = 43; // error
```


## Template Literal Types

```typescript
type World = "world";

type Greeting = `hello ${World}`;

let hello: Greeting = "hello world"; // ok
```

## Recursive Types

```typescript

type LinkedList<T> = {
  value: T;
  next: LinkedList<T> | null;
};

let list: LinkedList<number> = {
  value: 1,
  next: { value: 2, next: { value: 3, next: null } },
};

```