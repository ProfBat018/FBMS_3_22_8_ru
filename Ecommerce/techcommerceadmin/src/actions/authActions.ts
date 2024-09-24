
import axios, {AxiosResponse} from 'axios';
import {LoginDTO, RegisterDTO, TokenDTO} from "../models/auth.dto";
import { log } from 'console';

export const login = async (user: LoginDTO) => {

    const url = 'http://localhost:5046/api/v1/Auth/Login';
    
    try {
        const response: AxiosResponse<TokenDTO> = await axios.post(url, user);

        return response.data;
    } catch (error) {
        console.error('Error during login:', error);
        throw error;
    }
}
