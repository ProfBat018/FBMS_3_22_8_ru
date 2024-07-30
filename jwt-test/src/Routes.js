import Login from "./Login";
import Register from "./Register";
import Test from "./Test";
import App from "./App";
import LogOut from "./LogOut";

const routes = [
  {
    path: "/",
    element: <App />,
    children: [
      {
        path: "login",
        element: <Login />,
      },
      {
        path: "register",
        element: <Register />,
      },
      {
        path: "log-out",
        element: <LogOut />,
      },
      {
        path: "test",
        element: <Test />,
      },
    ],
  },
];

export default routes;