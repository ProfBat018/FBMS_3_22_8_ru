import axios from 'axios';
import { AddProductRequestDTO, ImageResponseDTO, ProductsRequestDTO, ProductsResponseDTO } from "../models/product.dto";

const api = axios.create({
    baseURL: 'http://localhost:5040/api/admin/products',
});

export const fetchProductsData = async (page: number, pageSize: number): Promise<ProductsResponseDTO> => {
    try {
        const response = await api.get(`/all/${page}/${pageSize}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const fetchProductsByCategory = async (categoryId: number, page: number, pageSize: number): Promise<ProductsResponseDTO> => {
    try {
        const response = await api.get(`/all/category/${categoryId}/${page}/${pageSize}`);
        return response.data;
    } catch (error) {
        throw error;
    }
};

export const uploadImageToBlob = async (file: File): Promise<ImageResponseDTO> => {
    const formData = new FormData();
    formData.append('file', file);

    try {
        const response = await api.post('/image/add', formData, {
            headers: {
                'Content-Type': 'multipart/form-data',
            },
        });

        return response.data as ImageResponseDTO; 
    } catch (error) {
        throw error;
    }
};


export const addNewProduct = async (productDto: AddProductRequestDTO, file: File): Promise<void> => {
    const imageResponse = await uploadImageToBlob(file);

    try {
        const response = await api.post('/add', {
            ...productDto,
            imageUrl: imageResponse.message,
        });

        return response.data;
    } catch (error) {
        throw error;
    }
};
