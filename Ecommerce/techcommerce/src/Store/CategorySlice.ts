import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import GetAllCategories, {transformCategories} from "../Actions/CategoryActions";
import {CategoryDTO, HierarchicalCategory} from "../Models/CategoryDTOs";

interface CategoryState {
    categories: HierarchicalCategory[]; // Определите тип Category
    loading: boolean;
    error: string | null;
    activeCategory: string | null;
    activeSubCategory: string | null;
}

const initialState: CategoryState = {
    categories: [],
    loading: false,
    error: null,
    activeCategory: null,
    activeSubCategory: null,
};

    export const loadCategories = createAsyncThunk('categories/load', async () => {
    
        const category = await GetAllCategories();

        console.log(category);
        return transformCategories(category); // Верните данные категорий
    });

const categorySlice = createSlice({
    name: 'categories',
    initialState,
    reducers: {
        setActiveCategory(state, action: PayloadAction<string>) {
            state.activeCategory = action.payload;
            state.activeSubCategory = null; // Reset subcategory when main category is selected
            state.loading = true;
            state.error = null;
        },
        setActiveSubCategory(state, action: PayloadAction<string>) {
            state.activeSubCategory = action.payload;
            state.loading = false;
        },
        resetCategories(state) {
            state.activeCategory = null;
            state.activeSubCategory = null;
            state.loading = false;
        }
    },
    extraReducers: (builder) => {
        builder
            .addCase(loadCategories.pending, (state) => {
                state.loading = true; // Устанавливаем состояние загрузки
                state.error = null;   // Сбрасываем ошибки
            })
            .addCase(loadCategories.fulfilled, (state, action) => {
                state.categories = action.payload; // Обновляем категории
                state.loading = false; // Устанавливаем состояние загрузки в false
            })
            .addCase(loadCategories.rejected, (state, action) => {
                state.loading = false; // Завершаем загрузку
                state.error = action.error.message || 'Failed to load categories'; // Обрабатываем ошибку
            });
    }
});



export const { setActiveCategory, setActiveSubCategory, resetCategories } = categorySlice.actions;
export default categorySlice.reducer;
