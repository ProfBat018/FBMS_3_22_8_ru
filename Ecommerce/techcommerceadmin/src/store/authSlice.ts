import { createSlice, createAsyncThunk, PayloadAction } from '@reduxjs/toolkit';
import {DecodedToken, LoginDTO, RegisterDTO, UserData} from "../models/auth.dto";
import { login} from '../actions/authActions';
import {jwtDecode} from "jwt-decode";


interface AuthState {
    user: UserData | null;
    isModalOpen: boolean;
    loading:boolean
    error: string | null;
}

const initialState: AuthState = {
    user: null,
    isModalOpen: false,
    error: null,
    loading: false
};


interface LoginResponseDTO {
    accessToken: string, 
    refreshToken: string,
    username: string,
}

export const loginUser = createAsyncThunk(
    'auth/loginUser',
    async (user: LoginDTO, { rejectWithValue, dispatch }) => {
        try {
            const response = await login(user);
            
            localStorage.setItem('accessToken', response.accessToken);
            localStorage.setItem('refreshToken', response.refreshToken);
            
            return {
                accessToken: response.accessToken,
                refreshToken: response.refreshToken,
                username: response.username,
            };

        } catch (error) {
            return rejectWithValue(`Login failed: ${error?.toString()}`);
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
        logout: function (state) {
            if (state.user != null) {
            state.user.isAuthenticated = false;
            state.user.accessToken = null;
            state.user.refreshToken = null;
            state.error = null;
            localStorage.removeItem('accessToken');
            localStorage.removeItem('refreshToken');
            }
        }
    },
    extraReducers: (builder) => {
        builder 
            .addCase(loginUser.pending, (state) => {
                state.loading = true; 
                state.error = null; 
            })
            .addCase(loginUser.fulfilled, (state, action: PayloadAction<LoginResponseDTO>) => {
                state.user = { 
                    isAuthenticated: true,
                    accessToken: action.payload.accessToken,
                    refreshToken: action.payload.refreshToken,
                    username: action.payload.username,
                };
                state.loading = false; 
            })
            .addCase(loginUser.rejected, (state, action) => {
                state.loading = false; 
                state.user = null; 
                state.error = action.payload as string; 
            });
    }
});

export const { logout, clearError } = authSlice.actions;
export default authSlice.reducer;
