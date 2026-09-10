using Countify.Api.DependencyInjection;
using Countify.Application.DependencyInjection;
using Countify.Infrastructure.DependencyInjection;
using Countify.Infrastructure.Extensions;
using Quick.AutoInject.DependencyAnnotation;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddApiServices();
builder.Services.AddQuickAutoInject();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CountifyPolicy", policy =>
    {
        policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference(options =>
    {
        options.Title = "Countify API";
        options.Theme = ScalarTheme.DeepSpace;
    });
}

app.Lifetime.ApplicationStarted.Register(() =>
{
    var address = app.Urls.FirstOrDefault();
    Console.WriteLine($"Scalar UI: {address}/scalar/v1");
});

app.MigrateDatabase();
app.UseHttpsRedirection();
app.UseCors("CountifyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();