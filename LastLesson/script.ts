// type MyReadonly<T> = {
//   readonly [P in keyof T]: T[P]; // Mapped Type
// };

// let obj = { x: 10, y: 20 };

// let readonlyObj: MyReadonly<typeof obj> = obj;

// console.log(readonlyObj);

// class Transport {}
// class Car extends Transport {}

// type Extends<T, U> = T extends U ? T : U;

// type A = Extends<Car, Transport>; // Car
// type B = Extends<Transport, Car>; // Car
// type C = Extends<number, Transport>; // Transport

// type MyReadonly<T> = {
//   readonly [P in keyof T]: T[P]; // Mapped Type
// };

// let obj = { x: 10, y: 20 };

// let readonlyObj: MyReadonly<typeof obj> = obj;

// console.log(readonlyObj);

// type Age = 42;

// let age1: Age = 42; // ok
// let age2: Age = 43; // error

// import * as A from "./module";

// let animal: A.Animal = A.createAnimal();

// import { Animal, createAnimal } from "./module";

// let animal: Animal = createAnimal();

import { Animals } from "./elvin";

namespace N1 {
  let animal: Animals.Animal = Animals.createAnimal();
}

namespace N2 {
  let animal: Animals.Animal = Animals.createAnimal();
}
