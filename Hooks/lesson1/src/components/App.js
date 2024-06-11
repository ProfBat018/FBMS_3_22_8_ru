import "../styles/App.css";
import Counter from "./Counter";
import Navbar from "./Navbar";
import NewCounter from "./NewCounter";
import { useState } from "react";
import { useEffect } from "react";
import Card from "./Card";
import StyledComponent from "./StyledComponent";
import UseEffectClass from "./UseEffectClass";
import UseEffectMethod from "./UseEffectMethod";
import { withoutMemo } from "./withoutMemo";
import MemoExample2 from "./MemoExample2";

// function App() {
//   const [cars, setCars] = useState([]);

//   async function fetchCars() {
//     await fetch("http://localhost:5195/getcars", {
//       method: "GET",
//       headers: {
//         "Content-Type": "application/json",
//       },
//     }).then((res) => {
//       res.json().then((data) => {
//         setCars(data);
//       });
//     });
//   }

//   // useEffect(() => {
//   //   fetchCars();
//   // }, []);

//   return (
//     <div className="App">
//       <header>
//         <Navbar />
//       </header>
//       {/* <Counter default={5} /> */}
//       {/* <NewCounter /> */}

//       {/* <div className="flex flex-row sm:flex-col">
//         {cars.map((car) => (
//           <Card
//             key={(Math.random() + 1).toString(36).substring(7)}
//             make={car.make}
//             model={car.model}
//             imagePath={car.imagePath}
//             price={car.price}
//           />
//         ))}
//       </div>

//       */}

//       <StyledComponent />
//     </div>
//   );
// }

// export default App;

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

      {/* <withoutMemo data={cars} /> */}
      {/* <MemoExample data={cars} /> */}

      <MemoExample2 />
    </div>
  );
}

export default App;
