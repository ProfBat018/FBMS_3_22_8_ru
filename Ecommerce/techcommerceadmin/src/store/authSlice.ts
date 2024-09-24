import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import { LoginDTO, RegisterDTO } from "../models/auth.dto";
import { login } from '../actions/authActions';
import { log } from 'console';


interface AuthState {
    isAuthenticated: boolean;
    accessToken: string | null;
    refreshToken: string | null;
    error: string | null;
    isModalOpen: boolean;
}

const initialState: AuthState = {
    isAuthenticated: false,
    accessToken: null,
    refreshToken: null,
    error: null,
    isModalOpen: false,
};

export const loginUser = createAsyncThunk(
    'auth/loginUser',
    async (user: LoginDTO, { rejectWithValue, dispatch }) => {
        try {
            const response = await login(user);
            localStorage.setItem('accessToken', response.accessToken);
            localStorage.setItem('refreshToken', response.refreshToken);
           
            return response;
        } catch (error) {
            return rejectWithValue('Login failed');
        }
    }
);


const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        clearError(state) {
            state.error = null;
          },
        logout(state) {
            state.isAuthenticated = false;
            state.accessToken = null;
            state.refreshToken = null;
            state.error = null;
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
        }
    },
    extraReducers: (builder) => {
        builder
            .addCase(loginUser.fulfilled, (state, action) => {
                state.isAuthenticated = true;
                state.accessToken = action.payload.accessToken;
                state.refreshToken = action.payload.refreshToken;
                state.error = null;
            })
            .addCase(loginUser.rejected, (state, action) => {
                state.isAuthenticated = false;
                state.error = action.payload as string;
            })
    }
});

export const { logout, clearError } = authSlice.actions;
export default authSlice.reducer;
