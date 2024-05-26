interface ITransport {
    speed: number;
    move(): void;
}

class Car implements ITransport {
    speed: number;
    move(): void {
        throw new Error("Method not implemented.");
    }
   
}

type User = {
    name: string;
    age: number;
    email: string;
  
  };
  