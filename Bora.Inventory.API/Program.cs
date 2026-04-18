using Bora.Inventory.API.Configuration;
using Bora.Inventory.Infrastructure.Persistence.Context;
using Bora.Inventory.Infrastructure.Seeding;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddApiServices(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}


app.UseCors(policyBuilder => policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapControllers();
app.UseHttpsRedirection();
app.BuildApp();
app.Run();