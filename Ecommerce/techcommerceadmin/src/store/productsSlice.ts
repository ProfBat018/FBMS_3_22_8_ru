import {createSlice, createAsyncThunk, PayloadAction} from '@reduxjs/toolkit';
import {ProductDTO, ProductsRequestDTO, ProductsResponseDTO} from '../models/product.dto';
import { getAllProducts } from '../actions/productActions';

export interface ProductsState {
    products: ProductDTO[];
    loading: boolean;
    error: string | null;
    pageNumber: number;
    pageSize: number;
    totalCount: number;
    totalPages: number;
    hasPreviousPage: boolean;
    hasNextPage: boolean;
}

const initialState: ProductsState = {
    products: [],
    loading: false,
    error: null,
    pageNumber: 1,
    pageSize: 10,
    totalCount: 0,
    totalPages: 0,
    hasPreviousPage: false,
    hasNextPage: false,
};

// Асинхронный thunk для загрузки продуктов
export const fetchProducts = createAsyncThunk(
    'products/fetchProducts',
    async ({ page, pageSize }: ProductsRequestDTO) => {
        const response = await getAllProducts({ page, pageSize });
        return response;
    }
);

const productsSlice = createSlice({
    name: 'products',
    initialState,
    reducers: {
        setPage(state, action) {
            state.pageNumber = action.payload;
        },
        setPageSize(state, action) {
            state.pageSize = action.payload;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(fetchProducts.pending, (state) => {
                state.loading = true;
                state.error = null;
            })
            .addCase(fetchProducts.fulfilled, (state, action: PayloadAction<ProductsResponseDTO>) => {
                const { items, totalCount, pageNumber, pageSize, totalPages, hasPreviousPage, hasNextPage } = action.payload;
                state.products = items;
                state.totalCount = totalCount;
                state.pageNumber = pageNumber;
                state.pageSize = pageSize;
                state.totalPages = totalPages;
                state.hasPreviousPage = hasPreviousPage;
                state.hasNextPage = hasNextPage;
                state.loading = false;
            })
            .addCase(fetchProducts.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message || 'Ошибка загрузки';
            });
    },
});

export const { setPage, setPageSize } = productsSlice.actions;
export default productsSlice.reducer;
