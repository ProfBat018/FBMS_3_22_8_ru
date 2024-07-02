import React, { useEffect, useState } from "react";
import Navbar from "./Navbar";
import { Outlet, useLocation } from "react-router-dom";

export default function Home() {
  const location = useLocation();
  const [isSignedIn, setIsSignedIn] = useState(false);

  useEffect(() => {
    if (location.state != null) {
      setIsSignedIn(location.state.isSignedIn);
    }
  });

  return (
    <div>
      <header>
        <Navbar isSignedIn={isSignedIn} />
      </header>
      <main>
        <Outlet />
        {/* Outlet is used to render nested routes */}
      </main>
      <footer>
        <div className="bg-black text-white text-center p-4">
          <p>© 2021 React. All rights reserved.</p>
        </div>
      </footer>
    </div>
  );
}
