namespace UserService.Exceptions;

public enum AuthErrorTypes
{
    InvalidToken,
    InvalidRefreshToken,
    InvalidCredentials,
    UserNotFound,
    InvalidRequest,
    PasswordMismatch,
    EmailNotConfirmed,
    EmailAlreadyConfirmed
}
