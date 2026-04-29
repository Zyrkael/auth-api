using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;
using auth_api.Dtos.Common;
using auth_api.Services.Auth;

namespace auth_api.Features.Auth;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var authGroup = app.MapGroup("/auth")
            .WithTags("Authentication");

        authGroup.MapPost("/login", async (LoginRequest request, IAuthService authService) =>
        {
            var response = await authService.LoginAsync(request);
            return Results.Ok(response);
        })
        .WithName("Login")
        .WithSummary("Đăng nhập người dùng")
        .WithDescription("Xác thực người dùng và trả về mã thông báo JWT.")
        .Accepts<LoginRequest>("application/json")
        .Produces<BaseResponse<LoginResponse>>(StatusCodes.Status200OK)
        .Produces<BaseResponse<object>>(StatusCodes.Status401Unauthorized)
        .Produces<BaseResponse<object>>(StatusCodes.Status400BadRequest);

        authGroup.MapPost("/register", async (RegisterRequest request, IAuthService authService, CancellationToken cancellationToken) =>
        {
            var response = await authService.RegisterAsync(request, cancellationToken);
            return Results.Created($"/auth/register", response);
        })
        .WithName("Register")
        .WithSummary("Đăng ký người dùng")
        .WithDescription("Đăng ký tài khoản người dùng mới vào hệ thống.")
        .Accepts<RegisterRequest>("application/json")
        .Produces<BaseResponse<RegisterResponse>>(StatusCodes.Status201Created)
        .Produces<BaseResponse<object>>(StatusCodes.Status400BadRequest);
    }
}
