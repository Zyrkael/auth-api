namespace auth_api.Features.Weather;

public static class WeatherEndpoints
{
    public static IEndpointRouteBuilder MapWeatherEndpoints(
        this IEndpointRouteBuilder app)
    {
        var summaries = new[]
        {
            "Freezing", "Hot", "Warm"
        };

        app.MapGet("/weatherforecast", () =>
        {
            var forecast = Enumerable.Range(1, 5)
                .Select(index => new WeatherForecast(
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ));

            return forecast;
        });

        return app;
    }
}

