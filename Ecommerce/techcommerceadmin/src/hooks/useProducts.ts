import useSWR from 'swr';
import { ProductsRequestDTO, ProductsResponseDTO } from '../models/product.dto';
import { fetchProductsData } from '../actions/productActions';

const fetcher = async (url: string) => {
    
    var token = localStorage.getItem('accessToken');

    const response = await fetch(url, {
        method: 'GET', 
        headers: {
            'Content-Type': 'application/json', 
            'Authorization': `Bearer ${token}` 
        },
    });
    
    if (!response.ok) {
        throw new Error('Network response was not ok');
    }
    return response.json();
};

export const useProducts = (params: ProductsRequestDTO) => {
    const { page, pageSize } = params;

    const { data, error } = useSWR<ProductsResponseDTO>(
        `http://localhost:5040/api/admin/products/all/${page}/${pageSize}`,
        fetcher
    );

    return {
        products: data?.items || [],
        totalCount: data?.totalCount || 0,
        totalPages: data?.totalPages || 0,
        hasPreviousPage: data?.hasPreviousPage || false,
        hasNextPage: data?.hasNextPage || false,
        loading: !error && !data,
        error
    };
};
