import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { Provider } from 'react-redux'; 
import Routes from '../routes';
import store from "../store/store";

const rootElement = document.getElementById('root') as HTMLElement;

const router = createBrowserRouter(Routes);

const root = ReactDOM.createRoot(rootElement);

root.render(
    <Provider store={store}> 
            <RouterProvider router={router} />
    </Provider>
);
