import React, { Component } from "react";

class UseEffectClass extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0,
    };
  }

  componentDidMount() {
    console.log(`ComponentMount`);
  }

  componentDidUpdate() {
    console.log(`You clicked ${this.state.count} times`);
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

export default UseEffectClass;
