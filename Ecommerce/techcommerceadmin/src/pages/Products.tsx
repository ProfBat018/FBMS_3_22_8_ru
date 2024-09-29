import React, {useEffect} from 'react';
import {Outlet} from "react-router-dom";

const Products = () => {
   return (
       <>
           <h1>Products page</h1>
           <Outlet/>
       </>
   );
};

export default Products;
