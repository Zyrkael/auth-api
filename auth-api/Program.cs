using auth_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDatabase(builder.Configuration);

builder.Services.AddApplicationServices();


var app = builder.Build();

app.UseHttpsRedirection();

app.MapApplicationEndpoints();

app.Run();
