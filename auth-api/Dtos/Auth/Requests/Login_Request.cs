namespace auth_api.Dtos.Auth.Requests;

public class Login_Request
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}
