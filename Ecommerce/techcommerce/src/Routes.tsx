import Home from './Components/Home'
import AboutUs from "./Components/AboutUs";
import Layout from "./Components/Layout";
import React from 'react';


const routes = [
    {
        path: "/",
        element: <Layout />,
        children: [
            {
                index: true,
                element: <Home />
            },
            {

                path: 'about',
                element: <AboutUs />
            },
            {
                path: 'home',
                element: <Home />
            }
        ]
    }
];

export default routes;