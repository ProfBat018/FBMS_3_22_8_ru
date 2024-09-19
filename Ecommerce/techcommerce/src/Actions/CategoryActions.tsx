
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

    const categoryMap = new Map<number, HierarchicalCategory>();

    // Создаем пустые категории в карте, используя id
    categories.forEach((category) => {
        categoryMap.set(category.id, {
            id: category.id,
            name: category.name,
            subcategories: []
        });
    });

    // Заполняем иерархию подкатегорий
    categories.forEach((category) => {
        const cat = categoryMap.get(category.id);
        if (category.parentCategoryId) {
            const parentCat = categoryMap.get(category.parentCategoryId);
            if (parentCat && cat) {
                parentCat.subcategories.push(cat);
            }
        }
    });

    // Создаем итоговый массив корневых категорий
    return Array.from(categoryMap.values()).filter(cat => cat.subcategories.length > 0);
}

export default GetAllCategories;