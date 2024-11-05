export interface LoginDTO {
    username: string,
    password: string
}

export interface LoginResponseDTO {
    username: string
}

export interface RegisterDTO {
    username: string,
    password: string,
    confirmPassword: string,
    email: string
}
