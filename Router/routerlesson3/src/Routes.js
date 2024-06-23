import { Children } from "react";

import Home from "./Home";
import About from "./About";
import Pricing from "./Pricing";
import Products from "./Products";
import Blog from "./Blog";
import Login from "./Login";
import Register from "./Register";

const homeChildren = [
  {
    path: "login",
    component: <Login />,
  },
  {
    path: "register",
    component: <Register />,
  },
];

const routes = [
  {
    path: "/",
    component: <Home />,
    children: homeChildren,
  },
  {
    path: "/home",
    component: <Home />,
    children: homeChildren,
  },
  {
    path: "/about",
    component: <About />,
  },
  {
    path: "/pricing",
    component: <Pricing />,
  },
  {
    path: "/products",
    component: <Products />,
  },
  {
    path: "/blog",
    component: <Blog />,
  },
];

export default routes;
