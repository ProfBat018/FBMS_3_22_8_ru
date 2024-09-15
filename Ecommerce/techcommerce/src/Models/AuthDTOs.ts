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

