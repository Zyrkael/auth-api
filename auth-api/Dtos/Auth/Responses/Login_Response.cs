namespace auth_api.Dtos.Auth.Responses;

/// <summary>
/// Represents the response returned after a successful login.
/// </summary>
public class Login_Response
{
    /// <summary>
    /// The JWT token used for authentication.
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// The expiration date and time of the token.
    /// </summary>
    public DateTime Expiration { get; set; }
}
