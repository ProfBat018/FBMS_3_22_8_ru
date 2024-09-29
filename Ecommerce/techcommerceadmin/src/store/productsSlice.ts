    // import {createSlice, createAsyncThunk, PayloadAction} from '@reduxjs/toolkit';
    // import {ProductDTO, ProductsRequestDTO, ProductsResponseDTO} from '../models/product.dto';
    // import { fetchProductsData } from '../actions/productActions';
    //
    // export interface ProductsState {
    //     products: ProductDTO[];
    //     loading: boolean;
    //     error: string | null;
    //     pageNumber: number;
    //     pageSize: number;
    //     totalCount: number;
    //     totalPages: number;
    //     hasPreviousPage: boolean;
    //     hasNextPage: boolean;
    // }
    //
    // const initialState: ProductsState = {
    //     pageNumber: 1,
    //     pageSize: 10,
    //   
    // };
    //
    //
    // const productsSlice = createSlice({
    //     name: 'products',
    //     initialState,
    //     reducers: {
    //         setPage(state, action) {
    //             state.pageNumber = action.payload;
    //         },
    //         setPageSize(state, action) {
    //             state.pageSize = action.payload;
    //         },
    //     }
    // });
    //
    // export const { setPage, setPageSize } = productsSlice.actions;
    // export default productsSlice.reducer;
