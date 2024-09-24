import Layout from './pages/Layout';
import Home from './pages/Home';
import React, { Children } from 'react';
import Main from './pages/Main';
import Products from './pages/Products';
import Categories from './pages/Categories';
import Users from './pages/Users';


const routes = [
    {
        path: "/",
        element: <Layout />,
        children: [
            {
                path: "/index",
                element: <Main/>,
                children: [
                    {
                        path: 'Products',
                        element: <Products/>
                    },
                    {
                        path: 'Categories',
                        element: <Categories/>
                    },
                    {
                        path: 'Users',
                        element: <Users/>
                    }
                ]
            }
        ]
    }
];

export default routes;