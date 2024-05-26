namespace MyNamespace {
  export class MyClass {
    private name: string;
    constructor(name: string) {
      this.name = name;
    }
    public getName(): string {
      return this.name;
    }
  }

  export function foo(n1: number, n2: number) {
    console.log(n1 + n2);
  }
}
