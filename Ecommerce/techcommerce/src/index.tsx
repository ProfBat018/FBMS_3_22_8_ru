import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from 'react-query';
import { Provider } from 'react-redux'; // Импортируем Provider из react-redux
import Routes from './Routes';
import store from "./Store/Store";

// Define the type for the element you are mounting to
const rootElement = document.getElementById('root') as HTMLElement;

const router = createBrowserRouter(Routes);
const queryClient = new QueryClient();

const root = ReactDOM.createRoot(rootElement);

root.render(
    <Provider store={store}> {/* Оборачиваем все приложение в Provider */}
        <QueryClientProvider client={queryClient}>
            <RouterProvider router={router} />
        </QueryClientProvider>
    </Provider>
);
