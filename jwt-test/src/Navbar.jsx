import React from "react";
import {
  FaHome,
  FaServicestack,
  FaInfoCircle,
  FaEnvelope,
  FaCog,
} from "react-icons/fa";
import { TbHexagonLetterMFilled } from "react-icons/tb";
import { IoStatsChart } from "react-icons/io5";
import { FaCalendarAlt } from "react-icons/fa";
import { IoLogOutSharp } from "react-icons/io5";
import { FaUserAlt } from "react-icons/fa";
import { Link } from "react-router-dom";
import { useContext } from "react";
import { log } from "react-modal/lib/helpers/ariaAppHider";
import { authContext } from "./App";

const Navbar = () => {

  const context = useContext(authContext);

  if (context.authState) {
  return (
    <div className="h-full w-64 fixed top-0 left-0 bg-blue-800 p-4 flex flex-col justify-between">
      <div>
        <div className="flex justify-center mb-8">
          <TbHexagonLetterMFilled className="text-white w-20 h-20" />
        </div>
        <Link
          to="Test"
          className="block py-2.5 px-4 rounded transition duration-200 hover:bg-blue-700 text-white flex items-center"
        >
          <FaUserAlt className="mr-2" /> Test
        </Link>
        <Link
          to="log-out"
          className="block py-2.5 px-4 rounded transition duration-200 hover:bg-blue-700 text-white flex items-center"
        >
          <IoLogOutSharp className="mr-2" /> Log out
        </Link>
      </div>
      <div className="flex justify-center mb-8">
        <Link
          to="#settings"
          className="block p-4 rounded-full transition duration-200 hover:bg-gray-700 text-white"
        >
          <FaCog className="w-8 h-8" />
        </Link>
      </div>
    </div>
  );
    }
    return (
        <div className="h-full w-64 fixed top-0 left-0 bg-blue-800 p-4 flex flex-col justify-between">
          <div>
            <div className="flex justify-center mb-8">
              <TbHexagonLetterMFilled className="text-white w-20 h-20" />
            </div>
            <Link
              to="Login"
              className="block py-2.5 px-4 rounded transition duration-200 hover:bg-blue-700 text-white flex items-center"
            >
              <FaUserAlt className="mr-2" /> Login / SignUp
            </Link>
          </div>
          <div className="flex justify-center mb-8">
            <Link
              to="#settings"
              className="block p-4 rounded-full transition duration-200 hover:bg-gray-700 text-white"
            >
              <FaCog className="w-8 h-8" />
            </Link>
          </div>
        </div>
      );
};

export default Navbar;