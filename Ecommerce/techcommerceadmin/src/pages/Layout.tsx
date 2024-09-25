import React, { useState } from 'react';
import Auth from './Auth';
import Main from './Main';

const Layout = () => {
  const [isAuthenticated, setIsAuthenticated] = useState(false);

  const onLogin = () => {
    setIsAuthenticated(true);
  };


  return (
    <div>
      {isAuthenticated ? <Main/> : <Auth onLogin={onLogin} />}
    </div>
  );
};

export default Layout;
