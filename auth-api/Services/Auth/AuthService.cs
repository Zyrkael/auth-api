using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;
using auth_api.Dtos.Common;
using auth_api.Utils.Security;

using auth_api.Contexts;
using auth_api.Entities;
using Microsoft.EntityFrameworkCore;

namespace auth_api.Services.Auth;

public class AuthService(IAppDbContext dbContext) : IAuthService
{
    public Task<BaseResponse<LoginResponse>> LoginAsync(LoginRequest request)
    {
        // TODO: validate credentials against DB, generate JWT
        var response = new LoginResponse
        {
            Token = "dummy-token",
            Expiration = DateTime.UtcNow.AddHours(1)
        };
        return Task.FromResult(BaseResponse<LoginResponse>.Success(response));
    }

    public async Task<BaseResponse<RegisterResponse>> RegisterAsync(RegisterRequest request, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var isValidEmail = ValidationHelper.IsValidEmail(request.Email);

        if (!isValidEmail)
        {
            return BaseResponse<RegisterResponse>.Failure("Email không hợp lệ.", StatusCodes.Status400BadRequest);
        }

        var isUserExist = await dbContext.Users.AnyAsync(u => u.Email == request.Email || u.UserName == request.Username, cancellationToken);
        if (isUserExist)
        {
            return BaseResponse<RegisterResponse>.Failure("Tên đăng nhập hoặc Email đã tồn tại.", StatusCodes.Status400BadRequest);
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

        var response = new RegisterResponse
        {
            Avatar = $"https://ui-avatars.com/api/?name={request.Username}"
        };

        return BaseResponse<RegisterResponse>.Success(response, "Đăng ký thành công", StatusCodes.Status201Created);
    }
}
