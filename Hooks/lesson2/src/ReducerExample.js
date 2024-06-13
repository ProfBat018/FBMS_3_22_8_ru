import React from "react";
import { useReducer } from "react";

export default function ReducerExample() {
  const [count, dispatch] = useReducer(counterHandler, 0);

  function counterHandler(state, action) {
    switch (action.type) {
      case "increment":
        return state + 1;
      case "decrement":
        return state - 1;
      default:
        return state;
    }
  }

  return (
    <div>
      <h1>Count: {count}</h1>
      <button onClick={() => dispatch({ type: "increment" })}>Increment</button>
      <button onClick={() => dispatch({ type: "decrement" })}>Decrement</button>
    </div>
  );
}
