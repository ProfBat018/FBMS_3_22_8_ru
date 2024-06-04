# Hooks

`Hooks` - это функции, которые позволяют вам использовать состояние и другие возможности React без написания классов.

Для начала хотелось бы показать вам как происходит отслеживание сотсояния объектов с использованием классовых компонентов на примере обычного счетчика.

```jsx
import React, { Component } from "react";

class Counter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0,
    };
  }

  increment() {
    this.setState({
      count: this.state.count + 1,
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

## useState

`useState` - это Hook, который позволяет вам добавлять состояние React в функциональные компоненты.

Пример можете посмотреть в компоненте `Counter`:

## useEffect

`useEffect` - это Hook, который позволяет вам выполнять побочные эффекты в функциональных компонентах.

То есть `useEffect` - это аналогично `componentDidMount`, `componentDidUpdate` и `componentWillUnmount` в классовых компонентах.

с помощью него мы можем задавать элементы при рендеринге компонента, а также выполнять какие-то действия при изменении состояния.


Тут нам надо подробнее разобрать его разницу в классовых компонентах и функциональных.

Давайте напишем его на классовом компоненте:

```jsx
import React, { Component } from "react";

class Counter extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0,
    };
  }

  componentDidMount() {
    document.title = `You clicked ${this.state.count} times`;
  }

  componentDidUpdate() {
    document.title = `You clicked ${this.state.count} times`;
  }

  increment() {
    this.setState({
      count: this.state.count + 1,
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

```

В то же время в функциональных компонентах:

```jsx

import React, { useState, useEffect } from "react";

function Counter() {
  const [count, setCount] = useState(0);

  useEffect(() => {
    document.title = `You clicked ${count} times`;
  });

  return (
    <div>
      <h1>{count}</h1>
      <button onClick={() => setCount(count + 1)}>Increment</button>
    </div>
  );
}