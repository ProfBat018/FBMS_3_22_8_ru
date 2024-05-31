import React from "react";
import { useState } from "react"; // hook

export default function NewCounter(props) {
  const [counter, setCounter] = useState(
    props.default !== undefined ? props.default : 0
  );

  const increment = () => {
    setCounter(counter + 1);
  };

  const decrement = () => {
    setCounter(counter - 1);
  };

  return (
    <div className="flex">
      <button
        onClick={increment}
        className="group relative h-12 w-48 overflow-hidden rounded-lg bg-white text-lg shadow"
      >
        <div className="absolute inset-0 w-3 bg-[#00df9a] transition-all duration-[250ms] ease-out group-hover:w-full"></div>
        <span className="relative text-black group-hover:text-white">
          Counter
        </span>
      </button>

      <div className="flex items-center justify-center w-12 h-12 bg-[#00df9a] text-white text-lg font-bold rounded-lg ml-4">
        <p>{counter}</p>
      </div>
    </div>
  );
}
