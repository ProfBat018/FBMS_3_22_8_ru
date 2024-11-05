import React, { createContext, useContext, useState, useEffect } from 'react';
import axios from "axios";
import {LoginResponseDTO} from "../models/auth.dto";

interface AuthContextProps {
  isAuthenticated: boolean;
  login: (username: string, password: string) => Promise<LoginResponseDTO>;
  logout: () => void;
}

const AuthContext = createContext<AuthContextProps>({
  isAuthenticated: false,
  login: async () => ({ username: '', password: '' }),
  logout: () => {},
});

export const useAuth = () => useContext(AuthContext);

export const AuthProvider: React.FC<{ children: React.ReactNode }> = ({ children }) => {
  const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
  const login = async (username: string, password: string): Promise<LoginResponseDTO> => {
    const response = await axios.post<LoginResponseDTO>('https://localhost:7227/api/v1/auth/login', { username, password }, { withCredentials: true });

    if (response.status == 200) {
    setIsAuthenticated(true);
    }

    return response.data;
  };

  const logout = () => {
    setIsAuthenticated(false);
  };

  useEffect(() => {
  }, [isAuthenticated]);
  

  return (
      <AuthContext.Provider value={{ isAuthenticated, login, logout }}>
        {children}
      </AuthContext.Provider>
  );
};
