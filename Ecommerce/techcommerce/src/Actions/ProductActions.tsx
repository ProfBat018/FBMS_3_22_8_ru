import axios from "axios";
import useSWR from "swr";
import {CategoryDTO} from "../Models/CategoryDTOs";
import {ProductDTO} from "../Models/ProductDTO";

const fetcher = (url: string) => axios.get(url).then(res => res.data);


export const GetAllProducts = (categoryName: string) => {

    console.log(categoryName);
    let url = `http://localhost:5040/Products/All/${categoryName}`;
    
    if (categoryName === 'All') {
        url = `http://localhost:5040/Products/All`;
    }
    const { data, error, isLoading } = useSWR<ProductDTO[]>(url, fetcher);

    return {
        products: data,
        isLoading,
        isError: error,
    };   
}