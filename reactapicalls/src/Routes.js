import Home from "./Home";
import About from "./About";
import Contact from "./Contact";
import Login from "./Login";
import Register from "./Register";
import Movies from "./Movies";
import Rating from "./Rating";
import MovieList from "./MovieList";


const homeChildren = [
  {
    path: "about",
    element: <About />,
  },
  {
    path: "contact",
    element: <Contact />,
  },
  {
    path: "login",
    element: <Login />,
  },
  {
    path: "register",
    element: <Register />,
  },
  {
    path: "movies",
    element: <Movies />,
  },
  {
    path: "rating",
    element: <Rating />,
  }
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
  {
    path: "/movielist",
    element: <MovieList />,
  }
];

export default routes;