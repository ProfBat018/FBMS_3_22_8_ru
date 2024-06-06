import "./App.css";
import RefExample from "./RefExample";
import RefExample2 from "./RefExample2";
import StateExample from "./StateExample";
import StateExample2 from "./StateExample2";
import ContextProblem from "./ContextProblem";
import ContextSolution from "./ContextSolution";
import { createContext } from "react";

export const ThemeContext = createContext();

function App() {
  return (
    <div className="App">
      {/* <StateExample /> */}
      {/* <RefExample /> */}

      {/* <StateExample2 /> */}
      {/* <RefExample2 /> */}

      {/* <ContextProblem /> */}

      <ThemeContext.Provider value="dark">
        <ContextSolution />
      </ThemeContext.Provider>
    </div>
  );
}

export default App;
