import useSWR from 'swr';
import { CategoryDTO, HierarchicalCategory, categories } from "../models/categories.dto";

const fetcher = async (url: string) => {
    const token = localStorage.getItem('accessToken');

    const response = await fetch(url, {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': `Bearer ${token}`
        },
    });

    if (!response.ok) {
        throw new Error('Ошибка при загрузке категорий');
    }
    return response.json();
};

export const transformCategories = (categories: CategoryDTO[]): HierarchicalCategory[] => {
    const categoryMap = new Map<number, HierarchicalCategory>();

    categories.forEach((category) => {
        categoryMap.set(category.id, {
            id: category.id,
            name: category.name,
            subcategories: []
        });
    });

    categories.forEach((category) => {
        const cat = categoryMap.get(category.id);
        if (category.parentCategoryId) {
            const parentCat = categoryMap.get(category.parentCategoryId);
            if (parentCat && cat) {
                parentCat.subcategories.push(cat);
            }
        }
    });

    return Array.from(categoryMap.values()).filter(cat => cat.subcategories.length > 0);
};

export const useCategories = () => {
    const { data, error, isLoading } = useSWR<CategoryDTO[]>('http://localhost:5040/api/admin/categories/all', fetcher);

    return {
        categories: data ? transformCategories(data) : [],
        loading: isLoading,
        error
    };
};
