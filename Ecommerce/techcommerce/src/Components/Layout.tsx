import React, {useState, useEffect} from 'react';
import Navbar from './Navbar'
import {Outlet} from "react-router-dom";
import Error from "./Error";
import {ErrorDTO, ErrorTypes} from "../Models/ErrorDTOs";
import {ToastContainer, toast} from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import {DecodedToken} from "../Models/AuthDTOs";
import {jwtDecode} from "jwt-decode";

const ToastNotifier: React.FC<{ message: string; type: "success" | "error" }> = ({message, type}) => {
    useEffect(() => {
        toast(message, {
            position: "top-right",
            autoClose: 5000,
            type: type,
        });
    }, [message, type]);

    return null;
};

const Layout: React.FC = () => {
    const [isAuthenticated, setIsAuthenticated] = useState<boolean>(false);
    const [toastMessage, setToastMessage] = useState<string | null>(null);
    const [toastType, setToastType] = useState<"success" | "error" | null>(null);

    const handleLogin = (result: boolean) => {
        setIsAuthenticated(result);

        if (result) {
            const token = localStorage.getItem('accessToken');
            const decodedToken: DecodedToken | null = token ? jwtDecode<DecodedToken>(token) : null;

            const decodedUsername = decodedToken?.["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"] ?? 'User';

            setToastMessage(`Hello, ${decodedUsername}!`);
            setToastType("success");
        } else {
            setToastMessage("Login failed!");
            setToastType("error");
        }
    };

    return (
        <>
            <Navbar onLogin={handleLogin}/>
            <main>
                <Outlet/>
            </main>
            <ToastContainer/>
            {toastMessage && toastType && <ToastNotifier message={toastMessage} type={toastType}/>}
        </>

    );
};

export default Layout;
