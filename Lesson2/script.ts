// interface User {
//   name: string;
//   age: number;
//   location: string;
// }

// type UserKeys = keyof User; // "name" | "age" | "location"

// const key: UserKeys = "age";

// console.log(key);

// type A = { x: number; y: number };

// const a = { x: 10, y: 20, z: 30 };

// if (a satisfies A) {
//   console.log("a satisfies A");
// }

// type Point = {
//   x: number;
//   y: number;
// };

// interface IPoint {
//   x: number;
//   y: number;
// }

// let p: Point = { x: 1, y: 2 };

// let ip: IPoint = { x: 1, y: 2 };

// p vs ip

// Тут интерфейсы, не совсем то же самое, что и в C# или Java.

// В TypeScript интерфейсы используются для описания формы объекта.
// Интерфейсы создают новый тип данных, который описывает форму объекта.

// В отличии от типов, от интерфейсов можно наследоваться.

// interface IPoint3D extends IPoint {
//   z: number;
// }

// class Point3D implements IPoint3D {
//   x: number;
//   y: number;
//   z: number;

//   constructor(x: number, y: number, z: number) {
//     this.x = x;
//     this.y = y;
//     this.z = z;
//   }
// }

// interface Point {
//   x: number;
//   y: number;
// }

// let p1: Point = { x: 10, y: 20 };
// let p2: { x: number; y: number } = p1;

// console.log(p2.x);

// interface User {
//   name: string;
//   age: number;
//   location: string;
// }

// type UserKeys = keyof User; // "name" | "age" | "location"


type A = { x: number; y: number };

const a = { x: 10, y: 20, z: 30 };

if (a satisfies A) {
  console.log("a satisfies A");
}

