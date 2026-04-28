using auth_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.AddInfrastructure();

var app = builder.Build();

app.UseAppMiddleware();

app.Run();
