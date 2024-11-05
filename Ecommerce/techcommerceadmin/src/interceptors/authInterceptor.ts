// authInterceptor.ts
import axios from 'axios';
import Cookies from 'js-cookie';


const authApiClient = axios.create({
    baseURL: 'http://localhost:5040/api/v1', 
    withCredentials: true, 
});


const refreshTokenRequest = async () => {
    try {
        const response = await axios.post('/Auth/RefreshToken', {}, { withCredentials: true });
        const { accessToken } = response.data;
        Cookies.set('accessToken', accessToken, { secure: true, sameSite: 'Strict' });
        return accessToken;
    } catch (error) {
        console.error('Failed to refresh token:', error);
        throw error;
    }
};


authApiClient.interceptors.response.use(
    (response) => response,
    async (error) => {
        const originalRequest = error.config;

        if (error.response && error.response.status === 401 && !originalRequest._retry) {
            originalRequest._retry = true;  

            try {
                const newAccessToken = await refreshTokenRequest();
                originalRequest.headers['Authorization'] = `Bearer ${newAccessToken}`;
                return authApiClient(originalRequest);  
            } catch (err) {
                return Promise.reject(err);
            }
        }

        return Promise.reject(error);  
    }
);

export default authApiClient;
