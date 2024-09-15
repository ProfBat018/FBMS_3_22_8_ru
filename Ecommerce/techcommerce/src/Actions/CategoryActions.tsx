
import useSWR from "swr";
import axios from "axios";
import {CategoryDTO} from "../Models/CategoryDTOs";


const fetcher = (url: string) => axios.get(url).then(res => res.data);

const GetAllCategories = () => {
    const { data, error, isLoading } = useSWR<CategoryDTO[]>('http://localhost:5040/Category/All', fetcher);

    return {
        categories: data,
        isLoading,
        isError: error,
    };
};

export default GetAllCategories;