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

        authGroup.MapPost("/login", async (Login_Request request, IAuthService authService) =>
        {
            var response = await authService.LoginAsync(request);
            return Results.Ok(BaseResponse<Login_Response>.Success(response, status: StatusCodes.Status200OK));
        })
        .WithName("Login")
        .WithSummary("Đăng nhập người dùng")
        .WithDescription("Xác thực người dùng và trả về mã thông báo JWT.")
        .Accepts<Login_Request>("application/json")
        .Produces<BaseResponse<Login_Response>>(StatusCodes.Status200OK)
        .Produces<BaseResponse<object>>(StatusCodes.Status401Unauthorized)
        .Produces<BaseResponse<object>>(StatusCodes.Status400BadRequest);

        authGroup.MapPost("/register", async (Register_Request request, IAuthService authService) =>
        {
            // Placeholder for registration logic
            var message = "Đăng ký thành công";
            return Results.Ok(BaseResponse<string>.Success(null, message, status: StatusCodes.Status200OK));
        })
        .WithName("Register")
        .WithSummary("Đăng ký người dùng")
        .WithDescription("Đăng ký tài khoản người dùng mới vào hệ thống.")
        .Accepts<Register_Request>("application/json")
        .Produces<BaseResponse<string>>(StatusCodes.Status200OK)
        .Produces<BaseResponse<object>>(StatusCodes.Status400BadRequest);
    }
}
