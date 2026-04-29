namespace auth_api.Dtos.Auth.Requests;

/// <summary>
/// Đại diện cho yêu cầu đăng ký tài khoản mới của người dùng.
/// </summary>
public class RegisterRequest
{
    /// <summary>
    /// Tên đăng nhập cho tài khoản mới.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Mật khẩu cho tài khoản mới.
    /// </summary>
    public string Password { get; set; } = string.Empty;

    /// <summary>
    /// Địa chỉ email cho tài khoản mới.
    /// </summary>
    public string Email { get; set; } = string.Empty;
}
