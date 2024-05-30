import React from "react";
import { useNavigate } from "react-router-dom";

export default function Navbar() {
  const navigate = useNavigate();

  function goToHome() {
    navigate("/home");
  }

  function goToAbout() {
    navigate("/about");
  }

  function goToContact() {
    navigate("/contact");
  }

  return (
    <nav class="flex items-center justify-between flex-wrap bg-green-500 p-6">
      <ul class="flex items-center flex-shrink-0 text-white mr-6">
        <button
          class="block lg:hidden sm:block focus:outline-none"
          id="burger"
          aria-label="Menu"
          aria-expanded="false"
        ></button>

        <li class="mr-6">
          <a onClick={goToHome} class="hover:text-white">
            Home
          </a>
        </li>
        <li class="mr-6">
          <a onClick={goToAbout} class="hover:text-white">
            About
          </a>
        </li>
        <li class="mr-6">
          <a onClick={goToContact} class="hover:text-white">
            Contact
          </a>
        </li>
      </ul>
    </nav>
  );
}
