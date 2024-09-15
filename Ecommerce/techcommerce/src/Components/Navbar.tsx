import React, { useRef, useState, useEffect } from 'react';
import { Dialog } from '@headlessui/react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import{ faSignInAlt, faSun, faMoon, faBars, faTimes } from '@fortawesome/free-solid-svg-icons';
import { Link, useNavigate } from 'react-router-dom';
import { login, register } from '../Actions/AuthActions';
import {CategoryDTO} from "../Models/CategoryDTOs";
import {LoginDTO, RegisterDTO} from "../Models/AuthDTOs";


const Navbar = ({ onLogin, categories }: { onLogin: (res: boolean) => void, categories: CategoryDTO[] }) => {
    const [isModalOpen, setIsModalOpen] = useState<boolean>(false);
    const [isMenuOpen, setIsMenuOpen] = useState<boolean>(false);
    const [darkTheme, setDarkTheme] = useState<boolean>(true);
    const [modalContent, setModalContent] = useState<'login' | 'register' | 'forgotPassword'>('login'); // Логин по умолчанию
    const [errorLabel, setErrorLabel] = useState<string>('');
  
    // Используем useRef для хранения значения username и password
    const usernameRef = useRef<HTMLInputElement>(null);
    const passwordRef = useRef<HTMLInputElement>(null);
    const confirmPasswordRef = useRef<HTMLInputElement>(null);
    const emailRef = useRef<HTMLInputElement>(null);

    const navigateTo = useNavigate();
    
    useEffect(() => {
        if (usernameRef.current) {
            usernameRef.current.value = '';
        }
        if (passwordRef.current) {
            passwordRef.current.value = '';
        }
    }, [modalContent])
    
    const toggleTheme = () => {
        setDarkTheme(!darkTheme);
        if (darkTheme) {
            document.documentElement.classList.remove('dark');
        } else {
            document.documentElement.classList.add('dark');
        }
    };

    // Обработчик для логина
    const handleLogin = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();
        const username = usernameRef.current?.value || '';
        const password = passwordRef.current?.value || '';

        const user: LoginDTO = {
            username, password
        };

        const res = login(user);
        
        res.then(response => {
            localStorage.setItem('accessToken', response.accessToken);
            localStorage.setItem('refreshToken', response.refreshToken);
            onLogin(true);
            
            navigateTo('/home');
            setIsModalOpen(false);
                
        }).catch(error => {
            onLogin(false);
            setErrorLabel(error.response.data.error);
        });
    };

    const handleRegister = (e: React.FormEvent<HTMLFormElement>) => {
        e.preventDefault();

        const username = usernameRef.current?.value || '';
        const password = passwordRef.current?.value || '';
        const email = emailRef.current?.value || '';
        const confirmPassword = confirmPasswordRef.current?.value || '';
        

        const user: RegisterDTO = {
            username, password, confirmPassword , email
        };
        console.log(user);
        const res = register(user);
        
        res.then(()=> {
            setModalContent('login');
        }).catch((error) => {
            setErrorLabel(error.response.data.error);
        });

    }
    
    // Функция для рендера содержимого модального окна
    const renderModalContent = () => {
        switch (modalContent) {
            case 'login':
                return (
                    
                    <>
                        <Dialog.Title className="text-xl font-bold mb-4">Log In</Dialog.Title>
                        <form className="space-y-4" onSubmit={handleLogin}>
                            <div>
                                <label htmlFor="username" className="block text-sm font-medium text-gray-700 dark:text-gray-300">
                                    Username
                                </label>
                                <input
                                    ref={usernameRef}
                                    id="username"
                                    type="text"
                                    className="mt-1 p-2 block w-full border border-gray-300 dark:border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
                                />
                            </div>

                            <div>
                                <label htmlFor="password" className="block text-sm font-medium text-gray-700 dark:text-gray-300">
                                    Password
                                </label>
                                <input
                                    ref={passwordRef}
                                    id="password"
                                    type="password"
                                    className="mt-1 p-2 block w-full border border-gray-300 dark:border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
                                />
                            </div>

                            <div className="flex justify-between text-sm">
                                <button
                                    type="button"
                                    className="text-blue-500 hover:underline"
                                    onClick={() => setModalContent('forgotPassword')}
                                >
                                    Forgot password?
                                </button>
                                <button
                                    type="button"
                                    className="text-blue-500 hover:underline"
                                    onClick={() => setModalContent('register')}
                                >
                                    Not registered yet?
                                </button>
                            </div>

                            <button
                                type="submit"
                                className="w-full bg-black-950 text-white px-4 py-2 rounded hover:bg-black-800"
                            >
                                Log In
                            </button>
                        </form>

                       <p className="text-red-700">{errorLabel}</p>
                    </>
                );
            case 'register':
                return (
                    <>
                        <Dialog.Title className="text-xl font-bold mb-4">Register</Dialog.Title>
                        <form className="space-y-4" onSubmit={handleRegister}>
                            <div>
                                <label htmlFor="username"
                                       className="block text-sm font-medium text-gray-700 dark:text-gray-300">
                                    Username
                                </label>
                                <input
                                    ref={usernameRef}
                                    id="username"
                                    type="text"
                                    className="mt-1 p-2 block w-full border border-gray-300 dark:border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
                                />
                            </div>

                            <div>
                                <label htmlFor="email"
                                       className="block text-sm font-medium text-gray-700 dark:text-gray-300">
                                    Email
                                </label>
                                <input
                                    ref={emailRef}
                                    id="email"
                                    type="email"
                                    className="mt-1 p-2 block w-full border border-gray-300 dark:border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
                                />
                            </div>

                            <div>
                                <label htmlFor="password"
                                       className="block text-sm font-medium text-gray-700 dark:text-gray-300">
                                    Password
                                </label>
                                <input
                                    ref={passwordRef}
                                    id="password"
                                    type="password"
                                    className="mt-1 p-2 block w-full border border-gray-300 dark:border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
                                />
                            </div>

                            <div>
                                <label htmlFor="confirm"
                                       className="block text-sm font-medium text-gray-700 dark:text-gray-300">
                                    Confirm Password
                                </label>
                                <input
                                    ref={confirmPasswordRef}
                                    id="confirm"
                                    type="password"
                                    className="mt-1 p-2 block w-full border border-gray-300 dark:border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
                                />
                            </div>
                            <button
                                type="submit"
                                className="w-full bg-black-950 text-white px-4 py-2 rounded hover:bg-black-800"
                            >
                                Register
                            </button>

                            <button
                                type="button"
                                className="mt-2 text-blue-500 hover:underline"
                                onClick={() => setModalContent('login')}
                            >
                                Already have an account? Log In
                            </button>
                        </form>
                    </>
                );
            case 'forgotPassword':
                return (
                    <>
                        <Dialog.Title className="text-xl font-bold mb-4">Forgot Password</Dialog.Title>
                        <form className="space-y-4">
                            <div>
                                <label htmlFor="email"
                                       className="block text-sm font-medium text-gray-700 dark:text-gray-300">
                                    Email
                                </label>
                                <input
                                    id="email"
                                    type="email"
                                    className="mt-1 p-2 block w-full border border-gray-300 dark:border-gray-600 rounded-md shadow-sm focus:ring-blue-500 focus:border-blue-500"
                                />
                            </div>

                            <button
                                type="submit"
                                className="w-full bg-black-950 text-white px-4 py-2 rounded hover:bg-black-800"
                            >
                                Reset Password
                            </button>

                            <button
                                type="button"
                                className="mt-2 text-blue-500 hover:underline"
                                onClick={() => setModalContent('login')}
                            >
                                Back to Log In
                            </button>
                        </form>
                    </>
                );
            default:
                return null;
        }
    };

    return (
        <nav className="flex relative items-center justify-between p-4 bg-black-950 text-white">
            {/* Логотип и навигационные ссылки */}
            <div className="flex items-center space-x-4">
                <a href="/" className="text-xl font-bold">TechCommerce</a>
                <div className="hidden sm:flex space-x-4">
                    <Link to="/" className="block py-2 text-white hover:text-gray-300">Home</Link>
                    <a className="block py-2 text-white hover:text-gray-300">Categories</a>
                    <Link to="/about" className="block py-2 text-white hover:text-gray-300">About Us</Link>
                </div>

                <button
                    onClick={() => setIsMenuOpen(!isMenuOpen)}
                    className="sm:hidden hover:text-gray-300"
                >
                    <FontAwesomeIcon icon={isMenuOpen ? faTimes : faBars}/>
                </button>
                
            </div>

            {/* Кнопки логина и смены темы */}
            <div className="flex items-center space-x-4">
                <button
                    onClick={() => setIsModalOpen(true)}
                    className="hover:text-gray-300"
                >
                <FontAwesomeIcon icon={faSignInAlt} />
                </button>

                <button
                    onClick={toggleTheme}
                    className="hover:text-gray-300"
                >
                    <FontAwesomeIcon icon={darkTheme ? faSun : faMoon} />
                </button>
            </div>

            {/* Mobile menu */}
            {isMenuOpen && (
                <div   className={`absolute top-16 left-0 right-0 bg-black p-4 transition-transform duration-300 ${
                    isMenuOpen ? 'translate-y-0' : '-translate-y-full'
                }`}>
                    <Link to="/" className="block py-2 text-white hover:text-gray-300">Home</Link>
                    <a className="block py-2 text-white hover:text-gray-300">Categories</a>
                    <Link to="/about" className="block py-2 text-white hover:text-gray-300">About Us</Link>
                </div>
            )}

            <Dialog open={isModalOpen} onClose={() => setIsModalOpen(false)} className="fixed z-10 inset-0 overflow-y-auto">
                <div className="flex items-center justify-center min-h-screen px-4">
                    <Dialog.Overlay className="fixed inset-0 bg-black opacity-30" />

                    {/* Модальное окно */}
                    <div className="bg-white dark:bg-gray-800 p-6 rounded-lg shadow-lg max-w-md w-full z-20">
                        {renderModalContent()}
                    </div>
                </div>
            </Dialog>
        </nav>
    );
};

export default Navbar;
