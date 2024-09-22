import React, {useRef, useState, useEffect} from 'react';
import {Dialog} from '@headlessui/react';
import {FontAwesomeIcon} from '@fortawesome/react-fontawesome';
import {faSignInAlt, faSun, faMoon, faBars, faTimes} from '@fortawesome/free-solid-svg-icons';
import {Link, useNavigate} from 'react-router-dom';
import {login, register} from '../Actions/AuthActions';
import {useDispatch, useSelector} from "react-redux";
import {closeModal, openModal} from "../Store/ModalSlice";
import {
    loadCategories,
    resetCategories,
    setActiveCategory,
    setActiveSubCategory,   
} from "../Store/CategorySlice";
import {toggleTheme} from "../Store/ThemeSlice";
import {RootState} from "../Store/Store";
import {loginUser, registerUser} from "../Store/AuthSlice";
import {AppDispatch} from "../Store/Store";
import {toggleMenu} from "../Store/MenuSlice";


interface NavbarProps {
    onLogin: (res: boolean) => void;
}


// тут должен был быть Store, но мне лень 
const Navbar: React.FC<NavbarProps> = ({onLogin}) => {
    
    const dispatch = useDispatch<AppDispatch>();

    const navigateTo = useNavigate();
    const [isDropdownOpen, setIsDropdownOpen] = useState(false);
    
    const { darkTheme } = useSelector((state: RootState) => state.theme);

    const isMenuOpen = useSelector((state: RootState) => state.menu.isMenuOpen);
    const { isModalOpen, modalContent } = useSelector((state: RootState) => state.modal);

    
    const { isAuthenticated } = useSelector((state: RootState) => state.auth);

    const usernameRef = useRef<HTMLInputElement>(null);
    const passwordRef = useRef<HTMLInputElement>(null);
    const confirmPasswordRef = useRef<HTMLInputElement>(null);
    const emailRef = useRef<HTMLInputElement>(null);
  
    const { categories, loading, error, activeCategory, activeSubCategory } = useSelector((state: RootState) => state.categories);

    useEffect(() => {
        dispatch(loadCategories());

        console.log(categories);
    }, [dispatch]);
    
    const handleCategoryClick = (categoryId: number) => {
        navigateTo(`/Products`, { state: { categoryId } });
    };

    const handleMouseEnterCategory = (categoryName: string) => {
        dispatch(setActiveCategory(categoryName));
    };

    const handleMouseEnterSubCategory = (subCategoryName: string) => {
        dispatch(setActiveSubCategory(subCategoryName));
    };
   const handleMouseLeave = () => {
        dispatch(resetCategories())
    };
    const toggleThemeHandler = () => {
        dispatch(toggleTheme());
    };

    const renderModalContent = () => {
        switch (modalContent) {
            case 'login':
                return (
                    <>
                        <Dialog.Title className="text-xl font-bold mb-4">Log In</Dialog.Title>
                        <div className="space-y-4">
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

                            <div className="flex justify-between text-sm">
                                <button
                                    type="button"
                                    className="text-blue-500 hover:underline"
                                    onClick={() => dispatch(openModal('forgotPassword'))}
                                >
                                    Forgot password?
                                </button>
                                <button
                                    type="button"
                                    className="text-blue-500 hover:underline"
                                    onClick={() => dispatch(openModal('register'))}
                                >
                                    Not registered yet?
                                </button>
                            </div>

                            <button
                                onClick={() => {
                                    const username = usernameRef.current?.value || '';
                                    const password = passwordRef.current?.value || '';
                                    dispatch(loginUser({ username, password }));
                                }}
                                className="w-full bg-black-950 text-white px-4 py-2 rounded hover:bg-black-800"
                            >
                                Log In
                            </button>
                        </div>
                    </>
                );
            case 'register':
                return (
                    <>
                        <Dialog.Title className="text-xl font-bold mb-4">Register</Dialog.Title>
                        <div className="space-y-4">
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
                                onClick={() => {
                                    const username = usernameRef.current?.value || '';
                                    const password = passwordRef.current?.value || '';
                                    const email = emailRef.current?.value || '';
                                    const confirmPassword = confirmPasswordRef.current?.value || '';
                                    dispatch(registerUser({ username, password, confirmPassword, email }));
                                }}
                                className="w-full bg-black-950 text-white px-4 py-2 rounded hover:bg-black-800"
                            >
                                Register
                            </button>

                            <button
                                type="button"
                                className="mt-2 text-blue-500 hover:underline"
                                onClick={() => dispatch(openModal('login'))}
                            >
                                Already have an account? Log In
                            </button>
                        </div>
                    </>
                );
            case 'forgotPassword':
                return (
                    <>
                        <Dialog.Title className="text-xl font-bold mb-4">Forgot Password</Dialog.Title>
                        <div className="space-y-4">
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
                                onClick={() => dispatch(openModal('login'))}
                            >
                                Back to Log In
                            </button>
                        </div>
                    </>
                );
            default:
                return null;
        }
    };

    return (
        <nav className="flex relative items-center justify-between p-4 bg-black-950 text-white">
            <div className="flex items-center space-x-4">
                <a href="/" className="text-xl font-bold">TechCommerce</a>
                <div className="hidden sm:flex space-x-4">
                    <Link to="/" className="block py-2 text-white hover:text-gray-300">Home</Link>
                    <div
                        className="relative"
                        onMouseLeave={handleMouseLeave}
                    >
                        <button
                            onClick={() => handleCategoryClick(0)}
                            onMouseEnter={() => setIsDropdownOpen(true)}
                            className="block py-2 text-white hover:text-gray-300"
                        >
                            Categories
                        </button>
                        {(categories.length > 0 && isDropdownOpen) && (
                            <div onMouseLeave={() => setIsDropdownOpen(false)}
                                 className="absolute left-0 mt-2 w-48 bg-black-950 text-white shadow-lg">
                                {categories.map((category) => (
                                    <div
                                        key={category.name}
                                        className="relative"
                                        onMouseEnter={() => handleMouseEnterCategory(category.name)}
                                    >
                                        <button
                                            onClick={() => {handleCategoryClick(category.id)}}
                                            className="block px-4 py-2 hover:bg-gray-700"
                                        >
                                            {category.name}
                                        </button>
                                        {activeCategory === category.name && category.subcategories.length > 0 && (
                                            <div
                                                className="absolute left-full top-0 mt-2 w-48 bg-black-950 text-white shadow-lg">
                                                {category.subcategories.map((subcat) => (
                                                    <div
                                                        key={subcat.name}
                                                        className="relative"
                                                        onMouseEnter={() => handleMouseEnterSubCategory(subcat.name)}
                                                    >
                                                        <button
                                                           onClick={() => handleCategoryClick(subcat.id)}
                                                            className="block px-4 py-2 hover:bg-black-1000"
                                                        >
                                                            {subcat.name}
                                                        </button>
                                                        {activeSubCategory === subcat.name && subcat.subcategories.length > 0 && (
                                                            <div
                                                                className="absolute left-full top-0 mt-2 w-48 bg-black-950 text-white shadow-lg">
                                                                {subcat.subcategories.map((subSubcat) => (
                                                                    <button
                                                                        key={subSubcat.name}
                                                                      onClick={() => handleCategoryClick(subSubcat.id)}
                                                                        className="block px-4 py-2 hover:bg-gray-700"
                                                                    >
                                                                        {subSubcat.name}
                                                                    </button>
                                                                ))}
                                                            </div>
                                                        )}
                                                    </div>
                                                ))}
                                            </div>
                                        )}
                                    </div>
                                ))}
                            </div>
                        )}
                    </div>
                    <Link to="/about" className="block py-2 text-white hover:text-gray-300">About Us</Link>
                </div>

                <button
                    onClick={() => dispatch(toggleMenu())}
                    className="sm:hidden hover:text-gray-300"
                >
                    <FontAwesomeIcon icon={isMenuOpen ? faTimes : faBars}/>
                </button>

            </div>

            <div className="flex items-center space-x-4">
                <button
                    onClick={() => dispatch(openModal('login'))}
                    className="hover:text-gray-300"
                >
                    <FontAwesomeIcon icon={faSignInAlt}/>
                </button>

                <button
                    onClick={() => dispatch(toggleTheme())}
                    className="hover:text-gray-300"
                >
                    <FontAwesomeIcon icon={darkTheme ? faSun : faMoon}/>
                </button>
            </div>

            {isMenuOpen && (
                <div className={`absolute top-16 left-0 right-0 bg-black p-4 transition-transform duration-300 ${
                    isMenuOpen ? 'translate-y-0' : '-translate-y-full'
                }`}>
                    <Link to="/" className="block py-2 text-white hover:text-gray-300">Home</Link>
                    <a className="block py-2 text-white hover:text-gray-300">Categories</a>
                    <Link to="/about" className="block py-2 text-white hover:text-gray-300">About Us</Link>
                </div>
            )}

            <Dialog open={isModalOpen} onClose={() => dispatch(closeModal())}
                    className="fixed z-10 inset-0 overflow-y-auto">
                <div className="flex items-center justify-center min-h-screen px-4">
                    <Dialog.Overlay className="fixed inset-0 bg-black opacity-30"/>

                    <div className="bg-white dark:bg-gray-800 p-6 rounded-lg shadow-lg max-w-md w-full z-20">
                        {renderModalContent()}
                    </div>
                </div>
            </Dialog>
        </nav>
    );
};

export default Navbar;
