using auth_api.Features.Auth;

namespace auth_api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapAuthEndpoints();
        return app;
    }
}
