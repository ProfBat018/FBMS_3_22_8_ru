namespace UserService.Exceptions;

public class MyAuthException : Exception
{
    public AuthErrorTypes AuthErrorType { get; set; }

    public MyAuthException( AuthErrorTypes authErrorType, string message) : base(message)
    {
        AuthErrorType = authErrorType;
    }



}
