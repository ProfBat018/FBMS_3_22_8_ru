import { createSlice, createAsyncThunk } from '@reduxjs/toolkit';
import axios from 'axios';


interface AuthState {
    isModalOpen: boolean;
    loading: boolean;
    error: string | null;
}

const initialState: AuthState = {
    isModalOpen: false,
    error: null,
    loading: false,
};

interface LoginResponseDTO {
    accessToken: string;
    refreshToken: string;
    username: string;
}

export const loginUser = createAsyncThunk<LoginResponseDTO, { username: string; password: string }>(
    'auth/loginUser',
    async ({ username, password }) => {
        const response = await axios.post('https://localhost:7227/api/v1/auth/login', { username, password });
        return response.data; 
    }
);

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        clearError(state) {
            state.error = null;
        },
        openModal(state) {
            state.isModalOpen = true;
        },
        closeModal(state) {
            state.isModalOpen = false;
        },
    },
    extraReducers: (builder) => {
        builder
            .addCase(loginUser.pending, (state) => {
                state.loading = true;
                state.error = null; 
            })
            .addCase(loginUser.fulfilled, (state, action) => {
                state.loading = false;
                state.error = null; 
                console.log('Login successful:', action.payload);
            })
            .addCase(loginUser.rejected, (state, action) => {
                state.loading = false;
                state.error = action.error.message || 'Login failed'; 
            });
    },
});

export const { clearError, openModal, closeModal } = authSlice.actions;
export default authSlice.reducer;
