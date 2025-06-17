using HomeTrack.Application;
using HomeTrack.Application.Common.Mappings;
using HomeTrack.Application.Interfaces;
using HomeTrack.Persistense;
using System.Reflection;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// 🔹 Добавляем Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "HomeTrack API",
        Version = "v1",
        Description = "Документация API для HomeTrack",
        Contact = new OpenApiContact
        {
            Name = "Артем",
            Email = "your-email@example.com"
        }
    });
});

builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IHomeTrackDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

builder.Services.AddOpenApi();

using var scope = builder.Services.BuildServiceProvider().GetRequiredService<IServiceScopeFactory>().CreateScope();
var context = scope.ServiceProvider.GetRequiredService<HomeTrackDbContext>();
DbInitializer.Initialize(context);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "HomeTrack API v1");
        c.RoutePrefix = "swagger"; // URL: http://localhost:5000/swagger
    });

    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseRouting();
app.UseCors("AllowAll");

app.Run();
