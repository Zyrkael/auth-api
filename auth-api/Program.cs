using auth_api.Extensions;

using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi(options =>
{
    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Title = "API Xác thực (Authentication API)";
        document.Info.Version = "v1";
        document.Info.Description = "API cho việc xác thực và phân quyền người dùng sử dụng JWT tokens. Bao gồm các điểm cuối cho đăng nhập và đăng ký.";
        return Task.CompletedTask;
    });
});

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
