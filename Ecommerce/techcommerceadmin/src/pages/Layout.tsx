import React, {useEffect} from 'react';
import Auth from './Auth';
import Main from './Main';
import { useAuth } from '../hooks/useAuth';
import {log} from "next/dist/server/typescript/utils";

const Layout = () => {
  const { isAuthenticated } = useAuth();
  
  return (
    <div>
      {isAuthenticated ? <Main /> : <Auth />}
    </div>
  );
};

export default Layout;
