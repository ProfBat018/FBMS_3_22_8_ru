import { configureStore } from '@reduxjs/toolkit';

import authReducer from './authSlice';
import modalReducer from './modalSlice';
import productReducer from './productsSlice';

const store = configureStore({
    reducer: {
        auth: authReducer,
        modal: modalReducer,
        products: productReducer
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
