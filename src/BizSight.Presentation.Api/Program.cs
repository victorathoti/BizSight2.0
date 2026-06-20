using BizSight.Application.Behaviors;
using BizSight.Application.DTOs.Authentication;
using BizSight.Application.Features.Auth.Commands.Login;
using BizSight.Infrastructure;
using BizSight.Persistence;
using FluentValidation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddInfrastructure();
builder.Services.Configure<JwtSettingsDTO>(
builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(
        typeof(LoginCommand).Assembly);
});

builder.Services.AddValidatorsFromAssembly(
    typeof(LoginCommandValidator).Assembly);

builder.Services.AddTransient(
    typeof(IPipelineBehavior<,>),
    typeof(ValidationBehavior<,>));

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v2", new Microsoft.OpenApi.OpenApiInfo
    {
        Title = "BizSight365 API",
        Version = "v2",
        Description = "BizSight365 REST API",
        Contact = new Microsoft.OpenApi.OpenApiContact
        {
            Name = "BizTech",
            Email = "support@biztechnologiesonline.com.com"
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint(
            "/swagger/v2/swagger.json",
            "BizSight365 API V2");
    });
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();