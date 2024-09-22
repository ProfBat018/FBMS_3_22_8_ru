import { configureStore } from '@reduxjs/toolkit';

import authReducer from './AuthSlice';
import themeReducer from './ThemeSlice';
import modalReducer from './ModalSlice';
import menuReducer from "./MenuSlice";
import categoryReducer from './CategorySlice';

const store = configureStore({
    reducer: {
        auth: authReducer,
        theme: themeReducer,
        modal: modalReducer,
        categories: categoryReducer,
        menu: menuReducer
    },
});

export type RootState = ReturnType<typeof store.getState>;
export type AppDispatch = typeof store.dispatch;

export default store;
