using System.Net.Mail;
using System.Text.RegularExpressions;

namespace auth_api.Utils.Security;

/// <summary>
/// Cung cấp các phương thức hỗ trợ kiểm tra tính hợp lệ của dữ liệu (Email, Số điện thoại, v.v.).
/// </summary>
public static class ValidationHelper
{
    // ===================== EMAIL =====================
    /// <summary>
    /// Kiểm tra xem một chuỗi có phải là định dạng Email hợp lệ hay không.
    /// </summary>
    /// <param name="email">Chuỗi email cần kiểm tra.</param>
    /// <returns>True nếu email hợp lệ, ngược lại là false.</returns>
    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;

        try
        {
            var addr = new MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }

    // ===================== PHONE (VIETNAM) =====================
    /// <summary>
    /// Kiểm tra xem một chuỗi có phải là số điện thoại Việt Nam hợp lệ hay không.
    /// Chấp nhận các định dạng: 0x, +84x, 84x với x là các đầu số 3, 5, 7, 8, 9.
    /// </summary>
    /// <param name="phone">Chuỗi số điện thoại cần kiểm tra.</param>
    /// <returns>True nếu số điện thoại hợp lệ, ngược lại là false.</returns>
    public static bool IsValidVietnamPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        // Chuẩn hóa: bỏ khoảng trắng, dấu chấm, dấu -
        phone = phone.Replace(" ", "")
                     .Replace(".", "")
                     .Replace("-", "");

        var pattern = @"^(0|\+84|84)(3|5|7|8|9)\d{8}$";

        return Regex.IsMatch(phone, pattern);
    }

    // ===================== NORMALIZE PHONE =====================
    /// <summary>
    /// Chuẩn hóa số điện thoại Việt Nam về định dạng chuẩn (bỏ khoảng trắng và các ký tự đặc biệt).
    /// </summary>
    /// <param name="phone">Chuỗi số điện thoại cần chuẩn hóa.</param>
    /// <returns>Chuỗi số điện thoại đã được chuẩn hóa.</returns>
    public static string NormalizeVietnamPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return phone;

        phone = phone.Replace(" ", "")
                     .Replace(".", "")
                     .Replace("-", "");

        if (phone.StartsWith("+84"))
            phone = "0" + phone.Substring(3);
        else if (phone.StartsWith("84"))
            phone = "0" + phone.Substring(2);

        return phone;
    }
}
