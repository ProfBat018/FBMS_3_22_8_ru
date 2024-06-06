import { useState } from "react";
import ReactDOM from "react-dom/client";

export default function ContextProblem() {
  const [user, setUser] = useState("Jesse Hall");


  return (
    <>
      <h1>{`Hello ${user}!`}</h1>
      <Component2 user={user} />
    </>
  );
}

    export function Component2({ user }) {
    return (
        <>
        <h1>Component 2</h1>
        <Component3 user={user} />
        </>
    );
    }

    export function Component3({ user }) {
    return (
        <>
        <h1>Component 3</h1>
        <Component4 user={user} />
        </>
    );
    }

    export function Component4({ user }) {
    return (
        <>
        <h1>Component 4</h1>
        <Component5 user={user} />
        </>
    );
    }

    export function Component5({ user }) {
    return (
        <>
        <h1>Component 5</h1>
        <h2>{`Hello ${user} again!`}</h2>
        </>
    );
    }
