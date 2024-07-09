import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import Routes from './Routes';
import { Provider } from 'react-redux';
import store from './store/index';

const root = ReactDOM.createRoot(document.getElementById('root'));
const router = createBrowserRouter(Routes);


 
root.render(
  <Provider store={store}>
    <RouterProvider router={router} />
  </Provider>
);


