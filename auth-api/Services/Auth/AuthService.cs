using System.Threading.Tasks;
using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;

namespace auth_api.Services.Auth;

public class AuthService : IAuthService
{
    public Task<Login_Response> LoginAsync(Login_Request request)
    {
        // TODO: validate credentials against DB, generate JWT
        var response = new Login_Response
        {
            Token = "dummy-token",
            Expiration = DateTime.UtcNow.AddHours(1)
        };
        return Task.FromResult(response);
    }
}
