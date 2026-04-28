using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;
using auth_api.Services.Auth;

namespace auth_api.Features.Auth;

public static class AuthEndpoints
{
    public static IEndpointRouteBuilder MapAuthEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapPost("/login", async (Login_Request request, IAuthService authService) =>
        {
            var response = await authService.LoginAsync(request);
            return Results.Ok(response);
        })
        .WithName("Login")
        .Accepts<Login_Request>("application/json")
        .Produces<Login_Response>(StatusCodes.Status200OK);

        return app;
    }
}
