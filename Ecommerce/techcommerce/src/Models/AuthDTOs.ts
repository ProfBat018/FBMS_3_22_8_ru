export interface LoginDTO {
    username: string,
    password: string
}

export interface RegisterDTO {
    username: string,
    password: string,
    confirmPassword: string,
    email: string
}

export interface TokenDTO {
    accessToken: string,
    refreshToken: string,
    refreshTokenExpireTime: Date
}

export enum UserRoles {
    AppAdmin,
    AppUser
}

export interface DecodedToken {
    [key: string]: any; 

}

export interface UserData {
    username: string,
    role: string
}