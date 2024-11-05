
import axios from 'axios';


const productsApiClient = axios.create({
    baseURL: 'http://localhost:5040/api', 
    withCredentials: true, 
});


productsApiClient.interceptors.response.use(
    (response) => response,
    (error) => {
        console.error('Product request error:', error);
        return Promise.reject(error);  
    }
);

export default productsApiClient;
