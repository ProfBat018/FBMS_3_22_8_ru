import React, { createContext, useContext, useState, useEffect, ReactNode } from 'react';
import { CategoryDTO } from "../Models/CategoryDTOs";
import GetAllCategories from "../Actions/CategoryActions";

interface CategoryContextProps {
    categories: CategoryDTO[] | undefined;
}

const CategoryContext = createContext<CategoryContextProps | undefined>(undefined);

export const CategoryProvider: React.FC<{ children: ReactNode }> = ({ children }) => {
    const [categories, setCategories] = useState<CategoryDTO[] | undefined>(undefined);
    const { categories: fetchedCategories, isLoading, isError } = GetAllCategories(true);

    useEffect(() => {
        if (!isLoading && !isError && fetchedCategories) {
            setCategories(fetchedCategories);
        }
    }, [fetchedCategories, isLoading, isError]);

    if (isLoading) {
        return <div>Loading...</div>;
    }

    if (isError) {
        return <div>Error loading categories</div>;
    }

    return (
        <CategoryContext.Provider value={{ categories }}>
            {children}
        </CategoryContext.Provider>
    );
};

export const useCategories = (): CategoryDTO[] | undefined => {
    const context = useContext(CategoryContext);
    if (context === undefined) {
        throw new Error('useCategories must be used within a CategoryProvider');
    }
    return context.categories;
};
 