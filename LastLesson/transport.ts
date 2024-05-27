import { Transport } from './transport';

class Car extends Transport {
  constructor(public make: string, public model: string) {
    super();
  }
}