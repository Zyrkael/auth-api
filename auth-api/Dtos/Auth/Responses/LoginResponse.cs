namespace auth_api.Dtos.Auth.Responses;

/// <summary>
/// Đại diện cho phản hồi được trả về sau khi đăng nhập thành công.
/// </summary>
public class LoginResponse
{
    /// <summary>
    /// Token JWT được sử dụng để xác thực.
    /// </summary>
    public string Token { get; set; } = string.Empty;

    /// <summary>
    /// Ngày và giờ hết hạn của token.
    /// </summary>
    public DateTime Expiration { get; set; }
}
