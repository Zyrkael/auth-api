using auth_api.Features.Auth;

namespace auth_api.Extensions;

public static class EndpointExtensions
{
    public static void MapAppEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAuthEndpoints();
    }
}
