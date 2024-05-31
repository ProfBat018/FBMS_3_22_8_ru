# Hooks 

`Hooks` - это функции, которые позволяют вам использовать состояние и другие возможности React без написания классов. 

Для начала хотелось бы показать вам как происходит отслеживание сотсояния объектов с использованием классовых компонентов на примере обычного счетчика.

```jsx
import React, { Component } from 'react';

class Counter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0
    };
  }

  increment() {
    this.setState({
      count: this.state.count + 1
    });
  }

  render() {
    return (
      <div>
        <h1>{this.state.count}</h1>
        <button onClick={() => this.increment()}>Increment</button>
      </div>
    );
  }
}

export default Counter;
```