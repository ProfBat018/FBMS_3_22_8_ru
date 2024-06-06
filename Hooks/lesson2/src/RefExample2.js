import React, { useState, useEffect, useRef } from "react";

export default function RefExample2() {
  const [userInput, setuserInput] = useState("");
  const renders = useRef(1);

  useEffect(() => {
    console.log(userInput);
    renders.current = renders.current + 1;
  });

  return (
    <>
      <input
        value={userInput}
        onChange={(event) => setuserInput(event.target.value)}
      />
      <p>The componrt rendered {renders.current} times</p>
    </>
  );
}
