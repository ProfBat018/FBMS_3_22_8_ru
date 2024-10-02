import React, {useEffect, useState} from 'react';
import { Link } from "react-router-dom";
import {useAuth} from "../hooks/useAuth";

interface NavbarProps {
    categories: {
        name: string;
        subcategories?: string[];
    }[];
}

const Navbar: React.FC<NavbarProps> = ({ categories }) => {
    const [dropdownOpen, setDropdownOpen] = useState<string | null>(null);
    const [userMenuOpen, setUserMenuOpen] = useState(false);
    
    const { logout } = useAuth();
    
    const toggleDropdown = (category: string) => {
        setDropdownOpen(dropdownOpen === category ? null : category);
    };


    
    const handleLogout = () => {
        logout()
    };

    return (
        <nav className="bg-gray-800 text-white p-4 flex justify-between items-center shadow-lg">
            <ul className="flex space-x-6">
                {categories.map((category, index) => (
                    <li key={index} className="relative group">
                        <button
                            onClick={() => toggleDropdown(category.name)}
                            className="hover:underline font-semibold"
                        >
                            {category.name}
                        </button>

                        {dropdownOpen === category.name && category.subcategories && (
                            <ul className="absolute left-0 mt-2 bg-gray-700 rounded shadow-lg w-40">
                                {category.subcategories.map((subcategory, subIndex) => (
                                    <li key={subIndex}>
                                        <Link
                                            to={`/${category.name}/${subcategory}`}
                                            className="px-4 py-2 hover:bg-gray-600 cursor-pointer"
                                        >
                                            {subcategory}
                                        </Link>
                                    </li>
                                ))}
                            </ul>
                        )}
                    </li>
                ))}
            </ul>

            <div className="flex items-center space-x-6">
                <div
                    className="relative"
                    onClick={() => setUserMenuOpen(!userMenuOpen)}
                >
                    <button className="hover:underline font-semibold">User</button>
                    {userMenuOpen && (
                        <ul className="absolute right-0 mt-2 bg-gray-700 rounded shadow-lg w-32">
                            <li className="px-4 py-2 hover:bg-gray-600 cursor-pointer">
                                Profile
                            </li>
                            <li className="px-4 py-2 hover:bg-gray-600 cursor-pointer">
                                Settings
                            </li>
                        </ul>
                    )}
                </div>

                <button
                    onClick={handleLogout}
                    className="bg-red-600 px-4 py-2 rounded hover:bg-red-500 transition"
                >
                    Logout
                </button>
            </div>
        </nav>
    );
};

export default Navbar;
