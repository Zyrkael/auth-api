namespace auth_api.Dtos.Auth.Requests;

/// <summary>
/// Represents a user's request to register a new account.
/// </summary>
public class Register_Request
{
    /// <summary>
    /// The username for the new account.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// The password for the new account.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// The email address for the new account.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
