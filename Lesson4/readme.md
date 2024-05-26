# Classes and all about OOP in TS 

## Classes

На счет классов тут все просто. В TS классы работают также как и в других языках программирования. 
```typescript

class Car {
    make: string,
    model: string,
    year: date,

    constructor(make: string, model: string, year: date) {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    getCarInfo() {
        return `Car: ${this.make} ${this.model} ${this.year}`;
    }
}

``` 

### Inheritance

```typescript

class Transport {
    make: string,
    model: string,
    year: date,

    constructor(make: string, model: string, year: date) {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    getTransportInfo() {
        return `Car: ${this.make} ${this.model} ${this.year}`;
    }
}

class Car extends Transport {
    volume: number;
    constructor(make: string, model: string, year: date, volume: number) {
        this.volume = volume;
        super(make, model, year);
    }
}

```

### Interface implementation and class inheritance

```typescript

interface ITransport {
  make: string;
  model: string;
  year: number;
  getTransportInfo(): string;
}

class Car implements ITransport {
  hp: number;
  volume: number;

  make: string;
  model: string;
  year: number;

  getTransportInfo(): string {
    throw new Error("Method not implemented.");
  }

  constructor (hp: number, volume: number, make: string, model: string, year: number) {
    this.hp = hp;
    this.volume = volume;
    this.make = make;
    this.model = model;
    this.year = year;
  }
}

class Taxi extends Car {
  constructor(hp: number, volume: number, make: string = 'Toyota', model: string = 'Camry', year: number = 2010) {
    super(hp, volume, make, model, year);
  }
}

let taxi: ITransport = new Taxi(100, 1.6);

console.log(taxi.make);


interface ITransport {
  make: string;
  model: string;
  year: number;
  getTransportInfo(): string;
}

class Car {
  hp: number;
  volume: number;

  getTransportInfo(): string {
    throw new Error("Method not implemented.");
  }

  constructor(
    hp: number,
    volume: number,
    make: string,
    model: string,
    year: number
  ) {
    this.hp = hp;
    this.volume = volume;
  }
}

class Taxi extends Car implements ITransport { // class Taxi : ITransport, Car 
  constructor(
    hp: number,
    volume: number,
    make: string = "Toyota",
    model: string = "Camry",
    year: number = 2010
  ) {
    super(hp, volume, make, model, year);
  }
  make: string;
  model: string;
  year: number;
}

let taxi: ITransport = new Taxi(100, 1.6);

console.log(taxi.make);

```

### Abstract classes

Асбтрактные классы это классы, которые не могут быть созданы напрямую, а могут быть только унаследованы. 
```typescript

abstract class Transport {
    make: string,
    model: string,
    year: date,

    constructor(make: string, model: string, year: date) {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    abstract getTransportInfo(): string;
}

class Car extends Transport {
    volume: number;
    constructor(make: string, model: string, year: date, volume: number) {
        this.volume = volume;
        super(make, model, year);
    }

    getTransportInfo() {
        return `Car: ${this.make} ${this.model} ${this.year}`;
    }
}

```

### Static methods

```typescript

class Car {
    make: string,
    model: string,
    year: date,

    constructor(make: string, model: string, year: date) {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    static getCarInfo(car: Car) {
        return `Car: ${car.make} ${car.model} ${car.year}`;
    }
}

let car = new Car('Toyota', 'Camry', 2010);

console.log(Car.getCarInfo(car));

```

### Getters and Setters

```typescript

class Car {
    make: string,
    model: string,
    year: date,

    constructor(make: string, model: string, year: date) {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    get carInfo() {
        return `Car: ${this.make} ${this.model} ${this.year}`;
    }

    set carInfo(carInfo: string) {
        let parts = carInfo.split(' ');
        this.make = parts[0];
        this.model = parts[1];
        this.year = parts[2];
    }
}

let car = new Car('Toyota', 'Camry', 2010);

console.log(car.carInfo);

car.carInfo = 'BMW X5 2015';

```

### Access modifiers

```typescript

class Car {
    private make: string,
    protected model: string,
    public year: date,

    constructor(make: string, model: string, year: date) {
        this.make = make;
        this.model = model;
        this.year = year;
    }

    get carInfo() {
        return `Car: ${this.make} ${this.model} ${this.year}`;
    }

    set carInfo(carInfo: string) {
        let parts = carInfo.split(' ');
        this.make = parts[0];
        this.model = parts[1];
        this.year = parts[2];
    }
}

```

### Readonly modifier

```typescript

class Car {
    readonly make: string,
    readonly model: string,
    readonly year: date,

    constructor(make: string, model: string, year: date) {
        this.make = make;
        this.model = model;
        this.year = year;
    }
}

let car = new Car('Toyota', 'Camry', 2010);

car.make = 'BMW'; // Error

```

### Generics 

Обобщения в TS, такие же как и в C#. 

```typescript

class DataStorage<T> {
    private data: T[] = [];

    addItem(item: T) {
        this.data.push(item);
    }

    removeItem(item: T) {
        this.data.splice(this.data.indexOf(item), 1);
    }

    getItems() {
        return [...this.data];
    }
}
```

### Generic constraints

```typescript

interface ILength {
    length: number;
}

function getLength<T extends ILength>(arg: T): number {
    return arg.length;
}


```

### Decorators 

Декораторы в TS это специальные функции, которые могут быть применены к классам, методам, аксессорам и свойствам. По идее это аналог атрибутов в C#. 
```typescript


function enumerable(value: boolean) {
  return function (
    target: any,
    propertyKey: string,
    descriptor: PropertyDescriptor
  ) {
    descriptor.enumerable = value;
  };
}

class Greeter {
  greeting: string;
  constructor(message: string) {
    this.greeting = message;
  }

  @enumerable(false)
  greet() {
    return "Hello, " + this.greeting;
  }
}
```
