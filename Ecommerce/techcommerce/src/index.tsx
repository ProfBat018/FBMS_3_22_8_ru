import React from 'react';
import ReactDOM from 'react-dom/client';
import './index.css';
import { createBrowserRouter, RouterProvider } from 'react-router-dom';
import { QueryClient, QueryClientProvider } from 'react-query';
import Routes from './Routes';


// Define the type for the element you are mounting to
const rootElement = document.getElementById('root') as HTMLElement;

const router = createBrowserRouter(Routes);
const queryClient = new QueryClient();

const root = ReactDOM.createRoot(rootElement);

root.render(
    <QueryClientProvider client={queryClient}>
        <RouterProvider router={router} />
    </QueryClientProvider>
);
