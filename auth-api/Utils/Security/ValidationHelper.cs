using System.Net.Mail;
using System.Text.RegularExpressions;

namespace auth_api.Utils.Security;

public static class ValidationHelper
{
    // ===================== EMAIL =====================
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
