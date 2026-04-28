using auth_api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Services
builder.Services.AddOpenApiDocumentation();
builder.Services.AddDatabaseContext(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure Pipeline
app.UseOpenApiDocumentation();
app.UseHttpsRedirection();
app.MapAppEndpoints();

app.Run();
