import React from 'react';
import { AppDispatch } from '../store/store';
import { useDispatch } from 'react-redux';
import { openModal } from '../store/modalSlice';

const ForgotPassword: React.FC = () => {
  const dispatch = useDispatch<AppDispatch>();

  return (
    <div className="flex items-center justify-center min-h-screen bg-gray-900 p-4">
      <div className="bg-gray-800 text-white p-6 rounded-lg shadow-lg max-w-md w-full">
        <h2 className="text-2xl font-bold mb-4">Forgot Password</h2>
        <div className="mb-4">
          <label htmlFor="email" className="block text-sm font-medium mb-1">Email</label>
          <input
            id="email"
            type="email"
            className="w-full p-2 bg-gray-700 border border-gray-600 rounded-md focus:ring focus:ring-blue-500"
            placeholder="Enter your email"
          />
        </div>
        <button className="w-full bg-blue-600 text-white px-4 py-2 rounded hover:bg-blue-500 transition">
          Reset Password
        </button>
        <button
          type="button"
          className="mt-4 text-blue-400 hover:underline w-full text-center"
          onClick={() =>  dispatch(openModal("login"))}
        >
          Back to Log In
        </button>
      </div>
    </div>
  );
};

export default ForgotPassword;
