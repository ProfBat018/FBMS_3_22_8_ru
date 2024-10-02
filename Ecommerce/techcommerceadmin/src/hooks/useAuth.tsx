import React, { createContext, useContext, useState, useEffect } from 'react';

interface AuthContextProps {
  isAuthenticated: boolean;
  login: (token: string) => void;
  logout: () => void;
}

const AuthContext = createContext<AuthContextProps>({
  isAuthenticated: false,
  login: () => {},
  logout: () => {},
});

export const useAuth = () => useContext(AuthContext);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
  const [initialLoad, setInitialLoad] = useState<boolean>(true);


  useEffect(() => {
    const token = localStorage.getItem('accessToken');
    if (token) {
      setIsAuthenticated(true);
    }
    setInitialLoad(false);
  }, []);

  const login = (token: string) => {

    localStorage.setItem('accessToken', token);
    setIsAuthenticated(true);
  };

  const logout = () => {

    localStorage.removeItem('accessToken');
    setIsAuthenticated(false);
  };

  useEffect(() => {
  }, [isAuthenticated]);

  if (initialLoad) {
    return null; 
  }

  return (
      <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
        {children}
      </AuthContext.Provider>
  );
};
