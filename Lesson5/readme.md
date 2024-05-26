# Utility Types

#### Partial

```typescript
interface User {
  name: string;
  age: number;
  email: string;
}

function createUser(user: Partial<User>): User {
  return {
    name: "John Doe",
    age: 30,
    email: "john.doe@example.com",
    ...user,
  };
}

const newUser = createUser({ name: "Jane Doe" });

console.log(newUser);
```

#### Pick

```typescript
interface User {
  name: string;
  age: number;
  email: string;
}

type UserBasicInfo = Pick<User, "name" | "email">;

const user: UserBasicInfo = {
  name: "John Doe",
  email: "jogn@doe.example",
};

console.log(user);
```

#### Omit

```typescript
interface User {
  name: string;
  age: number;
  email: string;
}

type UserBasicInfo = Omit<User, "age">;

const user: UserBasicInfo = {
  name: "John Doe",
  email: "john@doe.com",
};
```

#### Readonly

```typescript
class Car {
  readonly make: string;
  readonly model: string;

  constructor(make: string, model: string) {
    this.make = make;
    this.model = model;
  }
}

const car = new Car("Toyota", "Corolla");

console.log(car.make);

car.make = "Honda"; // Error: Cannot assign to 'make' because it is a read-only property.
```

#### Record

```typescript
interface CatInfo {
  age: number;
  breed: string;
}

type CatName = "miffy" | "boris" | "mordred";

const cats: Record<CatName, CatInfo> = {
  miffy: { age: 10, breed: "Persian" },
  boris: { age: 5, breed: "Maine Coon" },
  mordred: { age: 16, breed: "British Shorthair" }
};
```

#### Parameters

```typescript
type T0 = Parameters<() => string>;
// type T0 = []

type T1 = Parameters<(s: string) => void>;
// type T1 = [s: string]

type T2 = Parameters<<T>(arg: T) => T>;
// type T2 = [arg: unknown]

declare function f1(arg: { a: number; b: string }): void;
type T3 = Parameters<typeof f1>;
// type T3 = [arg: {
//     a: number;
//     b: string;
// }]

type T4 = Parameters<any>;
// type T4 = unknown[]

type T5 = Parameters<never>;
// type T5 = never

type T6 = Parameters<string>;
// ^ Type 'string' does not satisfy the constraint '(...args: any) => any'.

type T7 = Parameters<Function>;
// ^ Type 'Function' does not satisfy the constraint '(...args: any) => any'.
```

#### Awaited

```typescript
type A = Awaited<Promise<string>>;

type A = string;

type B = Awaited<Promise<Promise<number>>>;

type B = number;

type C = Awaited<boolean | Promise<number>>;

type C = number | boolean;



```

# Namespaces

```typescript
namespace MyNamespace {
  class MyClass {
    private name: string;
    constructor(name: string) {
      this.name = name;
    }
    public getName(): string {
      return this.name;
    }
  }

  export default MyClass;
}

const myClass = new MyNamespace.MyClass("John Doe");

console.log(myClass.getName());
```
