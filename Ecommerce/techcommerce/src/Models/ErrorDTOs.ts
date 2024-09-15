export enum ErrorTypes {
    InvalidToken = 'InvalidToken',
    InvalidRefreshToken = 'InvalidRefreshToken',
    InvalidCredentials = 'InvalidCredentials',
    UserNotFound = 'UserNotFound',
    InvalidRequest = 'InvalidRequest',
    PasswordMismatch = 'PasswordMismatch',
    EmailNotConfirmed = 'EmailNotConfirmed',
    EmailAlreadyConfirmed = 'EmailAlreadyConfirmed',
    InternalServerError = 'InternalServerError'
}

export interface ErrorDTO {
    errorType: ErrorTypes;
    errorCode: number;
    errorMessage: string;
}