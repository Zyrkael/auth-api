namespace auth_api.Utils.Security;

/// <summary>
/// Cung cấp các phương thức hỗ trợ băm (hash) và xác minh mật khẩu sử dụng BCrypt.
/// </summary>
public static class PasswordHelper
{
    /// <summary>
    /// Băm (hash) mật khẩu đầu vào bằng thuật toán BCrypt.
    /// </summary>
    /// <param name="password">Mật khẩu dạng plain text cần băm.</param>
    /// <param name="workFactor">
    /// Độ phức tạp (cost) của thuật toán. Giá trị càng cao thì càng bảo mật nhưng tốn thời gian xử lý hơn.
    /// Mặc định: 11.
    /// </param>
    /// <returns>
    /// Chuỗi hash đã được mã hóa, bao gồm cả salt.
    /// </returns>
    /// <remarks>
    /// BCrypt tự động sinh salt, vì vậy không cần xử lý salt thủ công.
    /// </remarks>
    public static string HashPassword(string password, int workFactor = 11)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, workFactor);
    }

    /// <summary>
    /// Xác minh mật khẩu đầu vào có khớp với hash đã lưu hay không.
    /// </summary>
    /// <param name="inputPassword">Mật khẩu người dùng nhập vào.</param>
    /// <param name="hashedPassword">Chuỗi hash đã lưu trong hệ thống.</param>
    /// <returns>
    /// True nếu mật khẩu hợp lệ; ngược lại là False.
    /// </returns>
    public static bool VerifyPassword(string inputPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(inputPassword, hashedPassword);
    }
}
