namespace auth_api.Dtos.Auth.Requests;

/// <summary>
/// Represents a user's request to log in.
/// </summary>
public class Login_Request
{
    /// <summary>
    /// The username of the user.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The password of the user.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
