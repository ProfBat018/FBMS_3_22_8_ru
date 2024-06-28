import Home from "./Home";
import About from "./About";
import Contact from "./Contact";

const homeChildren = [
  {
    path: "about",
    element: <About />,
  },
  {
    path: "contact",
    element: <Contact />,
  },
];

const routes = [
  {
    path: "/",
    element: <Home />,
    children: homeChildren,
  },
  {
    path: "/home",
    element: <Home />,
    children: homeChildren,
  },
];

export default routes;
