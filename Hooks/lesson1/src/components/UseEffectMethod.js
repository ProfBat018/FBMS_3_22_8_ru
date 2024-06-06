import React, { useState, useEffect } from "react";

function UseEffectMethod() {
  const [count, setCount] = useState(0);

  useEffect(() => {
    console.log(`You clicked ${count} times`);
  }, [count]);

  return (
    <div>
      <h1>{count}</h1>
      <button style={{ height: "100px" }} onClick={() => setCount(count + 1)}>
        Increment
      </button>
    </div>
  );
}

export default UseEffectMethod;
