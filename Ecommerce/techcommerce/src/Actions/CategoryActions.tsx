
import useSWR from "swr";
import axios from "axios";
import {CategoryDTO, HierarchicalCategory} from "../Models/CategoryDTOs";


const fetcher = (url: string) => axios.get(url).then(res => res.data);

const GetAllCategories = (isAuthenticated: boolean) => {
    const { data, error, isLoading } = useSWR<CategoryDTO[]>(isAuthenticated ? 'http://localhost:5040/Category/All': null, fetcher);

    return {
        categories: data,
        isLoading,
        isError: error,
    };
};

export function transformCategories(categories: CategoryDTO[] | undefined): HierarchicalCategory[] {
    if (!categories) {
        return [];
    }

    const categoryMap = new Map<string, HierarchicalCategory>();

    // Создаем пустые категории в карте
    categories.forEach((category) => {
        categoryMap.set(category.name, {
            name: category.name,
            subcategories: []
        });
    });

    // Заполняем иерархию подкатегорий
    categories.forEach((category) => {
        const cat = categoryMap.get(category.name);
        if (category.parentCategory) {
            const parentCat = categoryMap.get(category.parentCategory.name);
            if (parentCat && cat) {
                parentCat.subcategories.push(cat);
            }
        }
    });

    // Создаем итоговый массив корневых категорий
    return Array.from(categoryMap.values()).filter(cat => cat.subcategories.length > 0);
}

export default GetAllCategories;