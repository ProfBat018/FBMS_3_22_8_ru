import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import { login, register } from "../Actions/AuthActions";
import { LoginDTO, RegisterDTO } from "../Models/AuthDTOs";

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
            // Диспатчим действия для закрытия модального окна и навигации
            dispatch(closeModal());

            return response;
        } catch (error) {
            return rejectWithValue('Login failed');
        }
    }
);

export const registerUser = createAsyncThunk('auth/registerUser', async (user: RegisterDTO, { rejectWithValue }) => {
    try {
        await register(user);
        return;
    } catch (error) {
        return rejectWithValue('Registration failed');
    }
});

const authSlice = createSlice({
    name: 'auth',
    initialState,
    reducers: {
        logout(state) {
            state.isAuthenticated = false;
            state.accessToken = null;
            state.refreshToken = null;
            state.error = null;
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
        },
        openModal(state) {
            state.isModalOpen = true;
        },
        closeModal(state) {
            state.isModalOpen = false;
            
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
            .addCase(registerUser.fulfilled, (state) => {
                state.error = null;
            })
            .addCase(registerUser.rejected, (state, action) => {
                state.error = action.payload as string;
            });
    }
});

export const { logout, openModal, closeModal } = authSlice.actions;
export default authSlice.reducer;
