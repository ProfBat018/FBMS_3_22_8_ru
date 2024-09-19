import axios from "axios";
import useSWR from "swr";
import {CategoryDTO} from "../Models/CategoryDTOs";
import {PaginatedListDTO, ProductDTO, ProductSearchDTO} from "../Models/ProductDTO";
import { log } from "console";

const fetcher = (url: string) => axios.get(url).then(res => res.data);


export const GetAllProducts = (categoryId: number, searchData: ProductSearchDTO | undefined) => {
    if (!searchData) {
        searchData = {
            page: 1,
            pageSize: 10
        };
    }
    

    let url = `http://localhost:5040/Products/All/${categoryId}`;
    
    if (categoryId == 0) {
        url = `http://localhost:5040/Products/All/${searchData.page}/${searchData.pageSize}`;
    }

    console.log(url);
    

    const { data, error, isLoading } = useSWR<PaginatedListDTO<ProductDTO>>(url, fetcher);

    return {
        products: data,
        isLoading,
        isError: error,
    };   
}