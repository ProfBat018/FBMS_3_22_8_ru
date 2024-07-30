import "./index.css";
import React from "react";
import ReactDOM from "react-dom/client";
import routes from "./Routes";
import { createBrowserRouter, RouterProvider } from "react-router-dom";

const router = createBrowserRouter(routes);

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(<RouterProvider router={router} />);