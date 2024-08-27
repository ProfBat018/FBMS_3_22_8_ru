namespace ApiFirst.Data.Models.Requests;

public class AccessInfoDTO
{
    public string AccessToken { get; set; }
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpireTime { get; set; }
}
