import { createSlice } from '@reduxjs/toolkit';

interface ThemeState {
    darkTheme: boolean;
}

const initialState: ThemeState = {
    darkTheme: true,
};

const themeSlice = createSlice({
    name: 'theme',
    initialState,
    reducers: {
        toggleTheme(state) {
            state.darkTheme = !state.darkTheme;
            if (state.darkTheme) {
                document.documentElement.classList.add('dark');
            } else {
                document.documentElement.classList.remove('dark');
            }
        },
    },
});

export const { toggleTheme } = themeSlice.actions;
export default themeSlice.reducer;
