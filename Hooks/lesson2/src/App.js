import "./App.css";
import RefExample from "./RefExample";
import RefExample2 from "./RefExample2";
import StateExample from "./StateExample";
import StateExample2 from "./StateExample2";
import ContextProblem from "./ContextProblem";
import ContextSolution from "./ContextSolution";
import { createContext } from "react";
import { MemoExample } from "./";
import { withoutMemo } from "./withoutMemo";

export const ThemeContext = createContext();

function App() {
  let cars = [
    { make: "Ford", model: "Fusion", price: 45000 },
    { make: "Chevy", model: "Bolt", price: 40000 },
    { make: "Tesla", model: "Model 3", price: 60000 },
  ];

  return (
    <div className="App">
      {/* <StateExample /> */}
      {/* <RefExample /> */}

      {/* <StateExample2 /> */}
      {/* <RefExample2 /> */}

      {/* <ContextProblem /> */}

      {/* <ThemeContext.Provider value="dark">
        <ContextSolution />
      </ThemeContext.Provider> */}

      <withoutMemo data={cars} />
      {/* <MemoExample data={cars} /> */}
    </div>
  );
}

export default App;
