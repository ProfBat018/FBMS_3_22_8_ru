import React, { useState, useEffect } from "react";

export default function StateExample2() {
  const [userInput, setuserInput] = useState("");
  const [renders, setRenders] = useState(0);

  useEffect(() => {
    setRenders(renders + 1);
  });

  return (
    <div>
      <input
        value={userInput}
        onChange={(event) => setuserInput(event.target.value)}
      />
      <p>The componrt rendered {renders} times</p>
    </div>
  );
}
