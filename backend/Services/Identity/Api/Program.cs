using System.Reflection;
using Hellang.Middleware.ProblemDetails;
using Identity.Application.Features.Auth.Commands;
using Identity.Infrastructure.Extensions;
using MediatR;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

ProblemDetailsExtensions.AddProblemDetails(builder.Services);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "Identity API", Version = "v1" });
});

builder.Services.AddMediatR(typeof(SignInCommand).Assembly);
builder.Services.AddIdentityInfrastructure(builder.Configuration);
builder.Services.AddHealthChecks();

var app = builder.Build();

app.UseProblemDetails();
app.UseSwagger();
app.UseSwaggerUI();
app.MapControllers();
app.MapHealthChecks("/health");

app.Run();
