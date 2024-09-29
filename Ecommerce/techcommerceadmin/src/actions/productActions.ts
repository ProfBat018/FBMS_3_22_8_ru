import axios, { AxiosResponse } from 'axios';
import {AddProductRequestDTO, ImageResponseDTO, ProductsRequestDTO, ProductsResponseDTO} from "../models/product.dto";


export const fetchProductsData = async (url: string): Promise<ProductsResponseDTO> => {
    const token = localStorage.getItem('accessToken');
    try {
        const response: AxiosResponse<ProductsResponseDTO> = await axios.get(url, {
            headers: {
                Authorization: `Bearer ${token}`,
            },
        });
        return response.data;
    } catch (error) {
        throw error;
    }
};



export const uploadImageToBlob = async (file: File): Promise<ImageResponseDTO> => {
    const formData = new FormData();
    formData.append('file', file);

    const response = await axios.post('http://localhost:5040/api/admin/products/image/add', formData, {
        headers: {
            'Content-Type': 'multipart/form-data',
            'Authorization': `Bearer ${localStorage.getItem('accessToken')}`
        }
    });

    return response.data as ImageResponseDTO; // Возвращаем данные как ImageResponseDTO
};


export const addNewProduct = async (productDto: AddProductRequestDTO, file: File): Promise<void> => {
    const imageResponse = await uploadImageToBlob(file); 


    const token = localStorage.getItem('accessToken');

    const response = await axios.post('http://localhost:5040/api/admin/products/add', {
        ...productDto,
        imageUrl: imageResponse.message, 
    }, {
        headers: {
            'Authorization': `Bearer ${token}`
        }
    });

    return response.data; 
};
