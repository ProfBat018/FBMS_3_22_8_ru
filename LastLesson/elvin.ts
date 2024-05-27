export namespace Animals {
  export class Animal {
    name: string;
    breed: string;

    constructor(name: string, breed: string) {
      this.name = name;
      this.breed = breed;
    }

    display() {
      console.log(`Name: ${this.name}, Breed: ${this.breed}`);
    }
  }

  export function createAnimal(): Animal {
    return new Animal("Dog", "Husky");
  }
}
