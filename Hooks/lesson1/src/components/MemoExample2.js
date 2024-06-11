import React, { useState, useMemo } from "react";

// export default function MemoExample2() {
//   console.log("MemoExample2 rendered");
//   const [count, setCount] = useState(0);
//   let sum = processDiffItems();
//   return (
//     <div>
//       <h1>memoExample2</h1>

//       <button onClick={() => setCount(count + 1)}>Increment</button>
//       <h1>{count}</h1>

//       <h1>{sum}</h1>
//     </div>
//   );
// }
// const processDiffItems = () => {
//   console.log("processDiffItems started");
//   let sum = 0;
//   for (let i = 0; i < 1000000000; i++) {
//     sum += i;
//   }
//   return sum;
// };

const processDiffItems = () => {
  console.log("processDiffItems started");
  let sum = 0;
  for (let i = 0; i < 1000000000; i++) {
    sum += i;
  }
  return sum;
};

export default function MemoExample2() {
  console.log("MemoExample2 rendered");
  const [count, setCount] = useState(0);
  let sum = useMemo(() => processDiffItems(), []);

  return (
    <div>
      <h1>memoExample2</h1>

      <button onClick={() => setCount(count + 1)}>Increment</button>
      <h1>{count}</h1>

      <h1>{sum}</h1>
    </div>
  );
}
