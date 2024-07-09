import React from "react";
import { useNavigate } from "react-router-dom";
import { useState, useRef, useEffect } from "react";

import axios from "axios";

export default function Register() {

  const emailRef = useRef();
  const passwordRef = useRef();
  const confirmRef = useRef();
  const navigate = useNavigate();


  const registerByFetchApi = async (e) => {
    e.preventDefault();

    const userName = emailRef.current.value;
    const password = passwordRef.current.value;
    const confirm = confirmRef.current.value;

    console.log(userName, password, confirm);

    if (password !== confirm) {
      console.log("Passwords do not match");
      return;
    }
    try {
      const response = await fetch("http://localhost:7266/api/Auth/Register", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({ userName, password }),
      });

      const data = await response.json();

      if (data.error) {
        console.log(data.error);
      } else {
        console.log(data);



        navigate("../login", { state: { userName: userName } });
      }
    } catch (error) {
      console.log(error);
    }
  };
  const registerByAxios = async () => {
    const userName = emailRef.current.value;
    const password = passwordRef.current.value;
    const confirm = confirmRef.current.value;

    console.log(userName, password, confirm);

    if (password !== confirm) {
      console.log("Passwords do not match");
      return;
    }

    try {
      const response = await axios.post(
        "https://localhost:7266/api/Auth/Register",
        {
          userName,
          password,
        },
        {
          headers: {
            "Content-Type": "application/json",
          },
        }
      );

      const data = response.data;

      if (data.error) {
        console.log(data.error);
      } else {
        console.log(data);
      }
    } catch (error) {
      console.log(error);
    }
  };




  return (
    <div className="flex min-h-full flex-col justify-center px-6 py-12 lg:px-8">
      <div className="sm:mx-auto sm:w-full sm:max-w-sm">
        <img
          className="mx-auto h-10 w-auto"
          src="https://tailwindui.com/img/logos/mark.svg?color=indigo&shade=600"
          alt="Your Company"
        />
        <h2 className="mt-10 text-center text-2xl font-bold leading-9 tracking-tight text-gray-900">
          Register
        </h2>
      </div>

      <div className="mt-10 sm:mx-auto sm:w-full sm:max-w-sm">
        <form
          className="space-y-6"
          onSubmit={registerByFetchApi}
          method="POST"
        >
          <div>
            <label
              htmlFor="email"
              className="block text-sm font-medium leading-6 text-gray-900"
            >
              Email address
            </label>
            <div className="mt-2">
              <input
                ref={emailRef}
                id="email"
                name="email"
                type="email"
                autoComplete="email"
                required
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
              />
            </div>
          </div>

          <div>
            <div className="flex items-center justify-between">
              <label
                htmlFor="password"
                className="block text-sm font-medium leading-6 text-gray-900"
              >
                Password
              </label>
            </div>
            <div className="mt-2">
              <input
                ref={passwordRef}
                id="password"
                type="password"
                autoComplete="current-password"
                required
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
              />
            </div>
          </div>

          <div>
            <div className="flex items-center justify-between">
              <label
                htmlFor="password"
                className="block text-sm font-medium leading-6 text-gray-900"
              >
                Confirm Password
              </label>
            </div>
            <div className="mt-2">
              <input
                ref={confirmRef}
                id="confirmpassword"
                type="password"
                autoComplete="current-password"
                required
                className="block w-full rounded-md border-0 py-1.5 text-gray-900 shadow-sm ring-1 ring-inset ring-gray-300 placeholder:text-gray-400 focus:ring-2 focus:ring-inset focus:ring-indigo-600 sm:text-sm sm:leading-6"
              />
            </div>
          </div>

          <div>
            <button
              type="submit"
              className="flex w-full justify-center rounded-md bg-indigo-600 px-3 py-1.5 text-sm font-semibold leading-6 text-white shadow-sm hover:bg-indigo-500 focus-visible:outline focus-visible:outline-2 focus-visible:outline-offset-2 focus-visible:outline-indigo-600"
            >
              Sign Up
            </button>
          </div>
        </form>

        <p className="mt-10 text-center text-sm text-gray-500">
          Already a member?
          <a
            onClick={() => navigate("/login")}
            style={{ cursor: "pointer" }}
            className="font-semibold leading-6 text-indigo-600 hover:text-indigo-500"
          >
            Sign in
          </a>
        </p>
      </div>
    </div>
  );
}