import {ProductDTO, ProductsRequestDTO, ProductsResponseDTO} from "../models/product.dto";
import axios, {AxiosResponse} from "axios";


export const getAllProducts = async ({ page, pageSize }: ProductsRequestDTO): Promise<ProductsResponseDTO> => {
    const url = `http://localhost:5040/Products/All/${page}/${pageSize}`;

    try {
        const response: AxiosResponse<ProductsResponseDTO> = await axios.get(url);

        return response.data;
    } catch (error) {
        throw error; 
    }
};
