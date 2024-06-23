import React from "react";
import Navbar from "./Navbar";
import { Outlet } from "react-router-dom";

export default function Home() {
  return (
    <div>
      <header>
        <Navbar />
      </header>
      <Outlet />
    </div>
  );
}
