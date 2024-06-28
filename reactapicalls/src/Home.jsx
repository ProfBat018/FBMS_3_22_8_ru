import React from "react";
import Navbar from "./Navbar";
import { Outlet } from "react-router-dom";

export default function Home() {
  return (
    <div>
      <header>
        <Navbar />
      </header>
      <main>
        <Outlet />
        {/* Этот тег нужен для привязывания дочерних 
        элементов. Работает точно как ContentControl в WPF.
         */}
      </main>
      <footer>
        <div className="bg-black text-white text-center p-4">
          <p>© 2021 React. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}
