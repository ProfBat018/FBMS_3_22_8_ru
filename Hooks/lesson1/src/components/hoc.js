import React from "react";
import Counter from "./Counter";

const counterWithHOC = (WrappedComponent) => {
  return class extends React.Component {
    state = {
      count: 0,
    };

    increment = () => {
      this.setState((prevState) => {
        return {
          count: prevState.count + 1,
        };
      });
    };

    decrement = () => {
      this.setState((prevState) => {
        return {
          count: prevState.count - 1,
        };
      });
    };

    render() {
      return (
        <WrappedComponent
          count={this.state.count}
          increment={this.increment}
          decrement={this.decrement}
        />
      );
    }
  };
};

export default counterWithHOC(Counter);
