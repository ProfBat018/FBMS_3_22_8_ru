// interface ITransport {
//   make: string;
//   model: string;
//   year: number;
//   getTransportInfo(): string;
// }

// class Car implements ITransport {
//   hp: number;
//   volume: number;

//   make: string;
//   model: string;
//   year: number;

//   getTransportInfo(): string {
//     throw new Error("Method not implemented.");
//   }

//   constructor (hp: number, volume: number, make: string, model: string, year: number) {
//     this.hp = hp;
//     this.volume = volume;
//     this.make = make;
//     this.model = model;
//     this.year = year;
//   }
// }

// class Taxi extends Car {
//   constructor(hp: number, volume: number, make: string = 'Toyota', model: string = 'Camry', year: number = 2010) {
//     super(hp, volume, make, model, year);
//   }
// }

// let taxi: ITransport = new Taxi(100, 1.6);

// console.log(taxi.make);

// interface ITransport {
//   make: string;
//   model: string;
//   year: number;
//   getTransportInfo(): string;
// }

// class Car {
//   hp: number;
//   volume: number;

//   getTransportInfo(): string {
//     throw new Error("Method not implemented.");
//   }

//   constructor(
//     hp: number,
//     volume: number,
//     make: string,
//     model: string,
//     year: number
//   ) {
//     this.hp = hp;
//     this.volume = volume;
//   }
// }

// class Taxi extends Car implements ITransport { // class Taxi : ITransport, Car
//   constructor(
//     hp: number,
//     volume: number,
//     make: string = "Toyota",
//     model: string = "Camry",
//     year: number = 2010
//   ) {
//     super(hp, volume, make, model, year);
//   }
//   make: string;
//   model: string;
//   year: number;
// }

// let taxi: ITransport = new Taxi(100, 1.6);

// console.log(taxi.make);

// abstract class Transport {
//   make: string;
//   model: string;
//   year: number;
//   abstract getTransportInfo(): string;
// }

// class Car extends Transport {

//     constructor(make: string, model: string, year: number) {
//         super();
//         this.make = make;
//         this.model = model;
//         this.year = year;
//     }

//     getTransportInfo(): string {
//         throw new Error("Method not implemented.");
//     }
// }

// interface ILength {
//     length: number;
// }

// function getLength<T extends ILength>(arg: T): number {
//     return arg.length;
// }

// function enumerable(value: boolean) {
//   return function (
//     target: any,
//     propertyKey: string,
//     descriptor: PropertyDescriptor
//   ) {
//     console.log(target);
//     descriptor.enumerable = value;
//   };
// }

// class Greeter {
//   greeting: string;
//   constructor(message: string) {
//     this.greeting = message;
//   }

//   @enumerable(false)
//   greet() {
//     return "Hello, " + this.greeting;
//   }
// }

// let greeter = new Greeter("world");

// console.log(greeter.greet()); // "Hello, world"

// sealed decorator

function sealed(constructor: Function) {
  Object.seal(constructor);
  Object.seal(constructor.prototype);
}

@sealed
class Greeter {
  greeting: string;
  constructor(message: string) {
    this.greeting = message;
  }
  greet() {
    return "Hello, " + this.greeting;
  }
}


