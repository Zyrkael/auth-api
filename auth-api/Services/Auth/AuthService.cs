using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;
using auth_api.Utils.Security;

using auth_api.Contexts;
using auth_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Services.Auth;

public class AuthService(IAppDbContext dbContext) : IAuthService
{
    public Task<LoginResponse> LoginAsync(LoginRequest request)
    {
        // TODO: validate credentials against DB, generate JWT
        var response = new LoginResponse
        {
            Token = "dummy-token",
            Expiration = DateTime.UtcNow.AddHours(1)
        };
        return Task.FromResult(response);
    }

    public async Task<RegisterResponse> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var isValidEmail = ValidationHelper.IsValidEmail(request.Email);

        if (!isValidEmail)
        {
            throw new ArgumentException("Email không hợp lệ.");
        }

        var isUserExist = await dbContext.Users.AnyAsync(u => u.Email == request.Email || u.UserName == request.Username, cancellationToken);
        if (isUserExist)
        {
            throw new ArgumentException("Tên đăng nhập hoặc Email đã tồn tại.");
        }

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = request.Username,
            Email = request.Email,
            Password = PasswordHelper.HashPassword(request.Password),
            CreatedAt = DateTime.UtcNow
        };

        await dbContext.Users.AddAsync(user, cancellationToken);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new RegisterResponse
        {
            Avatar = $"https://ui-avatars.com/api/?name={request.Username}"
        };
    }
}
