import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { Provider } from 'react-redux';
import routes from './routes';
import store from './store/store';
import { AuthProvider } from './hooks/useAuth';

const rootElement = document.getElementById('root') as HTMLElement;

const router = createBrowserRouter(routes);

const root = ReactDOM.createRoot(rootElement);

root.render(
    <AuthProvider>
        <Provider store={store}>
            <RouterProvider router={router} />
        </Provider>
    </AuthProvider>
);
