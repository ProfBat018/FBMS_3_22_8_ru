import React, { createContext, useContext } from "react";
import { useState } from "react";
import { ThemeContext } from "./App";

const userContext = createContext();

export default function ContextSolution() {
  const theme = useContext(ThemeContext);

  console.log(theme);

  const [user, setUser] = useState("Jesse Hall");

  return (
    <>
      <h1 className={theme}>{`Hello ${user}!`}</h1>
      <userContext.Provider value={user}>
        <Component2 />
      </userContext.Provider>
    </>
  );
}

export function Component2() {
  const user = useContext(userContext);

  return (
    <>
      <h1>Component 2 {user}</h1>
      <Component3 />
    </>
  );
}

export function Component3() {
  const user = useContext(userContext);

  return (
    <>
      <h1>Component 3 {user}</h1>
      <Component4 />
    </>
  );
}

export function Component4() {
  const user = useContext(userContext);

  return (
    <>
      <h1>Component 4 {user}</h1>
      <Component5 />
    </>
  );
}

export function Component5() {
  const user = useContext(userContext);

  return (
    <>
      <h1>Component 5</h1>
      <h2>{`Hello ${user} again!`}</h2>
    </>
  );
}
