// interface User {
//   name: string;
//   age: number;
//   email: string;
// }

// function createUser(user: Partial<User>): User {
//   return {
//     name: "John Doe",
//     age: 30,
//     email: "john.doe@example.com",
//     ...user,
//   };
// }

// const newUser = createUser({ name: "Jane Doe" });

// console.log(newUser);

// --------------------------

// interface User {
//     name: string;
//     age: number;
//     email: string;
//   }

//   type UserBasicInfo = Pick<User, "name" | "email">;

//   const user: UserBasicInfo = {
//     name: "John Doe",
//     email: "jogn@doe.example"};

//   console.log(user);

// type T0 = Parameters<() => string>;
// // type T0 = []

// type T1 = Parameters<(s: string) => void>;
// // type T1 = [s: string]

// type T2 = Parameters<<T>(arg: T) => T>;
// // type T2 = [arg: unknown]

// declare function f1(arg: { a: number; b: string }): void;
// type T3 = Parameters<typeof f1>;
// // type T3 = [arg: {
// //     a: number;
// //     b: string;
// // }]

// type T4 = Parameters<any>;
// // type T4 = unknown[]

// type T5 = Parameters<never>;
// // type T5 = never

// type T6 = Parameters<string>;
// // ^ Type 'string' does not satisfy the constraint '(...args: any) => any'.

// type T7 = Parameters<Function>;
// // ^ Type 'Function' does not satisfy the constraint '(...args: any) => any'.

// function foo(n1: number, n2: number) {

// }

// type T8 = Parameters<typeof foo>;
// // type T8 = [n1: number, n2: number]

// --------------------------

// class Car {
//   make: string;
//   model: string;

//   constructor(make: string, model: string) {
//     this.make = make;
//     this.model = model;
//   }
// }

// type T2 = InstanceType<typeof Car>;

// let car: T2 = new Car("Toyota", "Corolla");

// console.log(car);

// --------------------------

// Awaited Type

type AwaitedString = Awaited<Promise<string>>;

function jsonStringifyAsync(obj: any): Promise<string> {
    return new Promise((resolve, reject) => {
      try {
        const jsonString = JSON.stringify(obj);
        resolve(jsonString);
      } catch (error) {
        reject(error);
      }
    });
  }

  // Пример использования
  async function main() {
    const obj = { name: "Alice", age: 30, city: "Wonderland" };
    try {
      let jsonString: AwaitedString = await jsonStringifyAsync(obj);
     
    } catch (error) {
      console.error("Error stringifying JSON:", error);
    }
  }

  main();

// --------------------------

// const myClass = new MyNamespace.MyClass("John Doe");

// console.log(myClass.getName());


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