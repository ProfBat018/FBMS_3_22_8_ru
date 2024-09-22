import { createSlice, PayloadAction } from '@reduxjs/toolkit';

interface MenuState {
    isMenuOpen: boolean;
}

const initialState: MenuState = {
    isMenuOpen: false,
};

const menuSlice = createSlice({
    name: 'menu',
    initialState,
    reducers: {
        setMenu(state, action: PayloadAction<boolean>) {
            state.isMenuOpen = action.payload;
        },
        toggleMenu(state) {
            state.isMenuOpen = !state.isMenuOpen;
        }
    }
});

export const { setMenu, toggleMenu } = menuSlice.actions;
export default menuSlice.reducer;
