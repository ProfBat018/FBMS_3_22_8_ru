import React, {useState} from 'react';
import {ProductDTO} from '../Models/ProductDTO';
import {GetAllProducts} from '../Actions/ProductActions';
import {useLocation, useParams} from "react-router-dom";

interface ProductProps {
    categoryName?: string
}

const Products = () => {

    // Получаем параметр categoryName из URL
    const {category} = useParams<{ category?: string }>();

    // Присваиваем 'All' если categoryName undefined
    const categoryName = category ?? 'All';

    const location = useLocation();

    // Извлечение состояния
    const {categoryData} = location.state || {};

    // Используем состояние для продуктов
    const [products, setProducts] = useState<ProductDTO[] | undefined>(undefined);


    // Получаем продукты из API
    const {products: fetchedProducts, isLoading, isError} = GetAllProducts(categoryName);

    if (isLoading) {
        return (
            <div className="flex justify-center items-center h-64">
                <div className="w-16 h-16 border-4 border-blue-500 border-dotted rounded-full animate-spin"></div>
            </div>
        );
    }
    if (isError) {
        return <div className="text-center text-red-500">Error fetching products</div>;
    }

    // Если продуктов нет
    if (!fetchedProducts || fetchedProducts.length === 0) {
        return <div className="text-center text-gray-500">No products available</div>;
    }

    return (
        <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6 p-4">
            {fetchedProducts.map((product) => (
                <div
                    key={product.name}
                    className="bg-white shadow-md rounded-lg p-4 hover:shadow-lg transition-shadow duration-300"
                >
                    <h3 className="text-lg font-bold text-gray-800">{product.name}</h3>
                    <p className="text-gray-600 mt-2">{product.description}</p>
                    <p className="text-gray-900 font-semibold mt-4">${product.price.toFixed(2)}</p>
                    <button
                        className="mt-4 bg-blue-500 text-white px-4 py-2 rounded hover:bg-blue-600 transition-colors duration-300">
                        Add to Cart
                    </button>
                </div>
            ))}
        </div>
    );

};

export default Products;
