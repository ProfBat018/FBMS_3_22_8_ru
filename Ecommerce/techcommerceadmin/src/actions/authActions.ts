import axios, {AxiosResponse} from 'axios';
import {LoginDTO, LoginResponseDTO, RegisterDTO, TokenDTO} from "../models/auth.dto";

export interface JwtPayload {
    iss?: string;
    sub?: string;
    aud?: string[] | string;
    exp?: number;
    nbf?: number;
    iat?: number;
    jti?: string;
}
export interface JwtDecodeOptions {
    header?: boolean;
}


export declare function jwtDecode<T = JwtPayload>(token: string, options?: JwtDecodeOptions): T;

export const login = async (user: LoginDTO) => {

    const url = 'http://localhost:5046/api/v1/Auth/Login';
    
    try {
        const response: AxiosResponse<LoginResponseDTO> = await axios.post(url, user);

        return response.data;
    } catch (error) {
        console.error('Error during login:', error);
        throw error;
    }
}
