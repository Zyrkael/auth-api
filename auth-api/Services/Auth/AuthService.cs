using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;

namespace auth_api.Services.Auth;

public class AuthService : IAuthService
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

    public Task<RegisterResponse> RegisterAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }
}
