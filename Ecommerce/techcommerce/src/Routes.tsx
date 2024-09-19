import Home from './Components/Home'
import AboutUs from "./Components/AboutUs";
import Layout from "./Components/Layout";
import React from 'react';
import Products from "./Components/Products";


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
            },
            {
                path: 'products',
                element: <Products/>
            }
        ]
    }
];

export default routes;