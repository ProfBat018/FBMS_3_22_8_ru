import Btn from "./components/btn";
import Navbar from "./components/navbar";
import Home from "./components/home";
import About from "./components/about";
import Contact from "./components/contact";

import { useState } from "react"; // это hook, который отслеживает состояние компонента

function App() {
  const [page, setPage] = useState("home");

  function goToHome() {
    setPage("home");
  }

  function goToAbout() {
    setPage("about");
  }

  function goToContact() {
    setPage("contact");
  }

  return (
    <div className="App">
      <header className="App-header">
        <Navbar
          goToHome={goToHome}
          goToAbout={goToAbout}
          goToContact={goToContact}
        />
      </header>
      <main>
        {page === "home" && <Home />}
        {page === "about" && <About />}
        {page === "contact" && <Contact />}
      </main>
    </div>
  );
}

export default App;
