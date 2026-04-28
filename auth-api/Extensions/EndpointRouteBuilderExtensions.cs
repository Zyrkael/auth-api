using auth_api.Features.Auth;
using auth_api.Features.Weather;

namespace auth_api.Extensions;

public static class EndpointRouteBuilderExtensions
{
    public static IEndpointRouteBuilder MapApplicationEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapWeatherEndpoints();
        app.MapAuthEndpoints();
        return app;
    }
}
