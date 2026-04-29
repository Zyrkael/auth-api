namespace auth_api.Dtos.Auth.Requests;

/// <summary>
/// Đại diện cho yêu cầu đăng nhập của người dùng.
/// </summary>
public class LoginRequest
{
    /// <summary>
    /// Tên đăng nhập của người dùng.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Mật khẩu của người dùng.
    /// </summary>
    public string Password { get; set; } = string.Empty;
}
