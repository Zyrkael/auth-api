namespace auth_api.Services.Auth;

using System.Threading.Tasks;
using auth_api.Dtos.Auth.Requests;
using auth_api.Dtos.Auth.Responses;

public interface IAuthService
{
    Task<Login_Response> LoginAsync(Login_Request request);
}
