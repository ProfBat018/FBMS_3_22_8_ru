import React from 'react';
import Navbar from '../pages/Navbar';
import { categories } from '../models/categories.dto';
import { Outlet } from 'react-router-dom';


const Main = () => {
    
    
  return (
    <div>
      <Navbar categories={categories}/>
      <div className="p-4">
        <Outlet/>
      </div>
    </div>
  );
};

export default Main;
