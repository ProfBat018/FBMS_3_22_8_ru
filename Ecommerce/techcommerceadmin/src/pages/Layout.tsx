import React from 'react';
import Auth from './Auth';
import Main from './Main';
import { useAuth } from '../hooks/useAuth';

const Layout = () => {
  const { isAuthenticated } = useAuth();

  return (
    <div>
      {isAuthenticated ? <Main /> : <Auth />}
    </div>
  );
};

export default Layout;
