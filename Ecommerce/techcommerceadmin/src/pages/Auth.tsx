import React, { useRef } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { loginUser, clearError } from "../store/authSlice";
import { openModal, closeModal } from '../store/modalSlice';
import { AppDispatch, RootState } from '../store/store';
import ForgotPassword from './ForgotPassword';

const Auth: React.FC<{onLogin: () => void}> = ({onLogin}) => {

  const usernameRef = useRef<HTMLInputElement>(null);
  const passwordRef = useRef<HTMLInputElement>(null);
  const dispatch = useDispatch<AppDispatch>();
  const error = useSelector((state: RootState) => state.auth.error);
  const isModalOpen = useSelector((state: RootState) => state.modal.isOpen);
  const modalContent = useSelector((state: RootState) => state.modal.modalContent);

  const handleLogin = async () => {
    const username = usernameRef.current?.value || '';
    const password = passwordRef.current?.value || '';

    const res = await dispatch(loginUser({ username, password }));

    if (res.payload) {
      onLogin();
    }
    
  };

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-900 p-4">

      {isModalOpen && modalContent === "forgotPassword" ? (
        <ForgotPassword/>
      ) : (
        <div className="bg-gray-800 text-white p-6 rounded-lg shadow-lg max-w-md w-full">
          <h2 className="text-2xl font-bold mb-4">Log In</h2>
          
          {error && (
            <div className="mb-4 text-red-500">
              {error}
              <button className="ml-2 text-blue-400" onClick={() => dispatch(clearError())}>
                X
              </button>
            </div>
          )}

          <div className="mb-4">
            <label htmlFor="username" className="block text-sm font-medium mb-1">Username</label>
            <input
              ref={usernameRef}
              id="username"
              type="text"
              className="w-full p-2 bg-gray-700 border border-gray-600 rounded-md focus:ring focus:ring-blue-500"
              placeholder="Enter your username"
            />
          </div>

          <div className="mb-4">
            <label htmlFor="password" className="block text-sm font-medium mb-1">Password</label>
            <input
              ref={passwordRef}
              id="password"
              type="password"
              className="w-full p-2 bg-gray-700 border border-gray-600 rounded-md focus:ring focus:ring-blue-500"
              placeholder="Enter your password"
            />
          </div>

          <button
            onClick={handleLogin}
            className="w-full bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-500 transition"
          >
            Log In
          </button>

          <div className="flex justify-between text-sm mt-4">
            <button
              type="button"
              className="text-blue-400 hover:underline"
              onClick={() =>  dispatch(openModal("forgotPassword"))}
            >
              Forgot password?
            </button>
          </div>
        </div>
      )}
    </div>
  );
};

export default Auth;
