import React, { useState, useEffect } from 'react';
import { ProductDTO } from '../Models/ProductDTO';
import { GetAllProducts } from '../Actions/ProductActions';
import {useLocation, useParams} from "react-router-dom";

const Products = () => {
    const location = useLocation();
    const categoryId = location.state?.categoryId;
    
    const [currentPage, setCurrentPage] = useState(1);
    const [pageSize] = useState(10); 
    
    const { products: fetchedProducts, isLoading, isError } = GetAllProducts(categoryId, { page: currentPage, pageSize });
        
    useEffect(() => {
        console.log(fetchedProducts) 
    }, [fetchedProducts]);

    
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
    
    if (!fetchedProducts || !Array.isArray(fetchedProducts.items) || fetchedProducts.totalCount === 0) {
        return <div className="text-center text-gray-500">No products available</div>;
    }

    const totalPages = fetchedProducts.totalPages;

    const handlePageChange = (page: number) => {
        if (page >= 1 && page <= totalPages) {
            setCurrentPage(page);
        }
    };

    return (
        <div>
            <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-3 lg:grid-cols-4 gap-6 p-4">
                {fetchedProducts.items.map((product: ProductDTO) => (
                    <div
                        key={product.id} // Use a unique identifier if available
                        className="bg-white shadow-md rounded-lg p-4 hover:shadow-lg transition-shadow duration-300"
                    >
                        <img src={product.imageUrl}></img>
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

            {/* Pagination Controls */}
            <div className="flex justify-center mt-4">
                <button
                    className={`px-4 py-2 mx-1 ${currentPage === 1 ? 'opacity-50 cursor-not-allowed' : 'bg-blue-500 text-white hover:bg-blue-600'}`}
                    onClick={() => handlePageChange(currentPage - 1)}
                    disabled={currentPage === 1}
                >
                    Previous
                </button>

                {Array.from({ length: totalPages }, (_, index) => (
                    <button
                        key={index + 1}
                        className={`px-4 py-2 mx-1 ${currentPage === index + 1 ? 'bg-blue-700 text-white' : 'bg-gray-200 text-gray-800 hover:bg-blue-500 hover:text-white'}`}
                        onClick={() => handlePageChange(index + 1)}
                    >
                        {index + 1}
                    </button>
                ))}

                <button
                    className={`px-4 py-2 mx-1 ${currentPage === totalPages ? 'opacity-50 cursor-not-allowed' : 'bg-blue-500 text-white hover:bg-blue-600'}`}
                    onClick={() => handlePageChange(currentPage + 1)}
                    disabled={currentPage === totalPages}
                >
                    Next
                </button>
            </div>
        </div>
    );
};

export default Products;
