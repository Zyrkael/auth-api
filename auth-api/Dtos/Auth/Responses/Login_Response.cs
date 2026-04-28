namespace auth_api.Dtos.Auth.Responses;

public class Login_Response
{
    public string Token { get; set; } = string.Empty;
    public DateTime Expiration { get; set; }
}
