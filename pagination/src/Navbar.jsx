import "./Navbar.css";
import React, { useEffect, useState, useRef } from "react";
import { useNavigate } from "react-router-dom";
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome'
import { faSearch } from '@fortawesome/free-solid-svg-icons'

export default function Navbar(props) {
  const searchRef = useRef();

  const navigate = useNavigate();
  const [listItems, setListItems] = useState([
    { id: 1, text: "About" },
    { id: 2, text: "Contact" },
    { id: 3, text: "Login" },
    { id: 4, text: "Register" }
  ]);
  const isSignedIn = props.isSignedIn;

  useEffect(() => {
    if (isSignedIn) {
      setListItems([
        { id: 1, text: "About" },
        { id: 2, text: "Contact" },
        { id: 3, text: "Log Out" }, // Change "Login" to "Log Out" when signed in
      {id: 4, text: "Movies"}
      ]);
    } else {
      setListItems([
        { id: 1, text: "About" },
        { id: 2, text: "Contact" },
        { id: 3, text: "Login" },
        { id: 4, text: "Register" },
        {id: 5, text: "Movies"}
      ]);
    }
  }, [isSignedIn]);

  const navigateTo = (path) => {
    navigate(path);
  };

  return (
    <nav className="relative flex w-full flex-nowrap items-center justify-between bg-zinc-50 py-2 text-neutral-500 shadow-dark-mild hover:text-neutral-700 focus:text-neutral-700 dark:bg-neutral-700 lg:flex-wrap lg:justify-start lg:py-4" data-twe-navbar-ref>
      <div className="flex w-full flex-wrap items-center justify-between px-3">
        <div className="ms-2">
          <a onClick={() => navigateTo("/home")} className="text-xl text-black dark:text-white">
            Navbar
          </a>
        </div>
        <button
          className="block border-0 bg-transparent px-2 text-black/50 hover:no-underline hover:shadow-none focus:no-underline focus:shadow-none focus:outline-none focus:ring-0 dark:text-neutral-200 lg:hidden"
          type="button"
          data-twe-collapse-init
          data-twe-target="#navbarSupportedContent2"
          aria-controls="navbarSupportedContent2"
          aria-expanded="false"
          aria-label="Toggle navigation"
        >
          <span className="[&>svg]:w-7 [&>svg]:stroke-black/50 dark:[&>svg]:stroke-neutral-200">
            <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="currentColor">
              <path
                fillRule="evenodd"
                d="M3 6.75A.75.75 0 013.75 6h16.5a.75.75 0 010 1.5H3.75A.75.75 0 013 6.75zM3 12a.75.75 0 01.75-.75h16.5a.75.75 0 010 1.5H3.75A.75.75 0 013 12zm0 5.25a.75.75 0 01.75-.75h16.5a.75.75 0 010 1.5H3.75a.75.75 0 01-.75-.75z"
                clipRule="evenodd"
              />
            </svg>
          </span>
        </button>

        <div
          className="!visible mt-2 hidden flex-grow basis-[100%] items-center lg:mt-0 lg:!flex lg:basis-auto"
          id="navbarSupportedContent2"
          data-twe-collapse-item
        >
          <ul className="list-style-none me-auto flex flex-col ps-0 lg:mt-1 lg:flex-row" data-twe-navbar-nav-ref>
            {listItems.map((item) => (
              <li key={item.id} className="nav-item mb-4 ps-2 lg:mb-0 lg:pe-1 lg:ps-0" data-twe-nav-link-ref>
                <a
                  className="p-0 text-black/60 transition duration-200 hover:text-black/80 hover:ease-in-out focus:text-black/80 active:text-black/80 motion-reduce:transition-none dark:text-white/60 dark:hover:text-white/80 dark:focus:text-white/80 dark:active:text-white/80 lg:px-2"
                  onClick={() => navigateTo(`/home/${item.text.toLowerCase()}`)}
                  data-twe-nav-link-ref
                >
                  {item.text}
                </a>
              </li>
            ))}
          </ul>
        </div>

        <div className="relative mx-auto text-gray-600 lg:block hidden">
                <input
                ref={searchRef}
                    className="border-2 border-gray-300 bg-white h-10 pl-2 pr-8 rounded-lg text-sm focus:outline-none"
                    type="search" name="search" placeholder="Search"/>
                <button type="button" onClick={() =>  navigate(`/home/movies`, {state: {title: searchRef.current.value}})} className="absolute right-0 top-0 mt-3 mr-2">
                    <FontAwesomeIcon icon={faSearch} />
                </button>
            </div>
      </div>
    </nav>
  );
}
