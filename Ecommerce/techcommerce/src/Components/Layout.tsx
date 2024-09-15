import React, {useEffect, useState} from 'react';
import Navbar from "./Navbar";
import {Outlet} from "react-router-dom";
import GetAllCategories from "../Actions/CategoryActions";
import Error from "./Error";
import {CategoryDTO} from "../Models/CategoryDTOs";
import {ErrorDTO, ErrorTypes} from "../Models/ErrorDTOs";
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';



const Layout = () => {
    const [isAuthenticated, setIsAuthenticated] = useState(false);
    const [categories, setCategories] = useState<CategoryDTO[] | undefined>(undefined);
    const [isLoading, setIsLoading] = useState<boolean>(false);
    const [isError, setIsError] = useState<boolean>(false);

    // Fetch categories data using the custom hook
    const {categories: fetchedCategories, isLoading: fetchLoading, isError: fetchError} = GetAllCategories();

    const handleLogin = (result: boolean )=> {
        setIsAuthenticated(result); // Update login status
        
        if (result) {
            toast(`Hello, !`, {
                position: "top-right",
                autoClose: 5000,
                type: "success",
            });
        } else {
            toast(`Hello, !`, {
                position: "top-right",
                autoClose: 5000,
                type: "error",
            });
        }
    };

    useEffect(() => {
        if (isAuthenticated) {
            setIsLoading(true);
            // Update categories data when authenticated
            if (fetchedCategories) {
                setCategories(fetchedCategories);
                setIsLoading(false);
            }
            if (fetchError) {
                setIsError(true);
                setIsLoading(false);
            }
        }
    }, [isAuthenticated, fetchedCategories, fetchError]);

    if (isLoading) {
        return (
            <div className="flex justify-center items-center min-h-screen">
                {/* Loading spinner */}
                <div className="w-16 h-16 border-4 border-blue-500 border-dotted rounded-full animate-spin"></div>
                <h6>Loading...</h6>
            </div>
        );
    }

    if (isError) {
        const error: ErrorDTO = {
                errorType: ErrorTypes.InternalServerError,
                errorCode: 500,
                errorMessage: `Can't fetch categories`
            };
        return <Error errorData={error}></Error>
    }

    return (
        <>
            <Navbar onLogin={handleLogin} categories={categories ?? []}/>
            <main>
         
                <Outlet/>
            </main>
            <ToastContainer />
        </>
    );
};

export default Layout;
