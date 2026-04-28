using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;
using auth_api.Services.Auth;

namespace auth_api.Features.Auth;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        var authGroup = app.MapGroup("/auth")
            .WithTags("Authentication")
            .WithOpenApi();

        authGroup.MapPost("/login", async (Login_Request request, IAuthService authService) =>
        {
            var response = await authService.LoginAsync(request);
            return Results.Ok(response);
        })
        .WithName("Login")
        .WithSummary("Đăng nhập người dùng")
        .WithDescription("Xác thực người dùng và trả về mã thông báo JWT.")
        .Accepts<Login_Request>("application/json")
        .Produces<Login_Response>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status401Unauthorized)
        .Produces(StatusCodes.Status400BadRequest);

        authGroup.MapPost("/register", async (Register_Request request, IAuthService authService) =>
        {
            // Placeholder for registration logic
            return Results.Ok(new { message = "Registration successful" });
        })
        .WithName("Register")
        .WithSummary("Đăng ký người dùng")
        .WithDescription("Đăng ký tài khoản người dùng mới vào hệ thống.")
        .Accepts<Register_Request>("application/json")
        .Produces(StatusCodes.Status201Created)
        .Produces(StatusCodes.Status400BadRequest);

        return app;
    }
}
