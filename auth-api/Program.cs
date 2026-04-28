using auth_api.Extensions;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddApplicationServices();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference("/docs", options =>
    {
        options.Title = "Auth Docs 🚀";

        options.Layout = ScalarLayout.Modern;

        options.Theme = ScalarTheme.DeepSpace;
    });
}


app.UseHttpsRedirection();

app.MapApplicationEndpoints();

app.Run();
