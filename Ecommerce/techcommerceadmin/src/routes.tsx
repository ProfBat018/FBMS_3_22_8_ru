import Layout from './pages/Layout';
import Main from './pages/Main';
import ProductsAll from './pages/ProductsAll';
import ProductsAdd from './pages/ProductsAdd';
import CategoriesAll from './pages/CategoriesAll';
import CategoriesAdd from './pages/CategoriesAdd';
import UsersAll from './pages/UsersAll';
import UsersAdd from './pages/UsersAdd';
import React from "react";
import Products from "./pages/Products";

const routes = [
    {
        path: "/",
        element: <Layout/>,
        children: [
            {
                path: "Products",
                element: <Products/>,
                children: [
                    {path: "All", element: <ProductsAll/>},
                    {path: "Add", element: <ProductsAdd/>}
                ]
            },
            {
                path: "Categories",
                children: [
                    {path: "All", element: <CategoriesAll/>},
                    {path: "Add", element: <CategoriesAdd/>}
                ]
            },
            {
                path: "Users",
                children: [
                    {path: "All", element: <UsersAll/>},
                    {path: "Add", element: <UsersAdd/>}
                ]
            }
        ]
    }


];

export default routes;
