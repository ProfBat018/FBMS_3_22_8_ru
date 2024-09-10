import React, {useState, useEffect} from 'react';
import Navbar from "./Navbar";
import {Outlet} from "react-router-dom";
const Layout = () => {

    const [categories, setCategories] = useState([]);




    return (
        <>
            <Navbar />
            <main>
                <Outlet />
            </main>
        </>
    );
};

export default Layout;