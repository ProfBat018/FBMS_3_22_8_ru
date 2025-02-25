namespace ControllerFirst.Shared;

public static class RegexPattern
{
    public const string Username = @"^[a-zA-Z0-9_\\-]{6,}$";
    public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[_*$#@!%]).{8,}$";
    
}