namespace auth_api.Dtos.Auth.Responses;

/// <summary>
/// Đại diện cho phản hồi được trả về sau khi đăng ký thành công.
/// </summary>
public class RegisterResponse
{

    /// <summary>
    /// Đường dẫn (URL) ảnh đại diện của người dùng.
    /// </summary>
    public string Avatar { get; set; } = string.Empty;
}
