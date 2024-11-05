// authActions.ts
import authApiClient from '../interceptors/authInterceptor';
import { LoginDTO, LoginResponseDTO } from '../models/auth.dto';


export const login = async (user: LoginDTO): Promise<LoginResponseDTO> => {
    const response = await authApiClient.post('/Auth/Login', user);
    return response.data;
};


export const logout = async (): Promise<void> => {
    await authApiClient.post('/Auth/Logout');
};


export const getCurrentUser = async () => {
    const response = await authApiClient.get('/Auth/CurrentUser');
    return response.data;
};
