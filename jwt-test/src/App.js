import { IoMagnet } from "react-icons/io5";
import "./App.css";
import { Link, Route, Routes } from "react-router-dom";
import { useEffect, useState } from "react";

import Navbar from "./Navbar";

import { Outlet } from "react-router-dom";
import { createContext } from "react";

export const authContext = createContext();
function App() {

  const [authState, setAuthState] = useState(false);

  useEffect(() => {
    if (localStorage.getItem("accessToken")) {
      setAuthState(true);
    }
  }, [authState]);

  return (
    <div className="App">
      <authContext.Provider value={{ authState, setAuthState }}>
        <header>
          <Navbar/>
        </header>
        <main>
          <Outlet />
        </main>
      </authContext.Provider>
    </div>
  );
}

export default App;
