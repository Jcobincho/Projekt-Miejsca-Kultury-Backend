using Api.Extensions;
using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Presentation;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerExtension();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddPresentation();
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
    
app.UseHttpsRedirection();
app.UseAuthorization();
app.ApplyPendingMigration();
app.MapControllers();
app.AddGlobalErrorHandler();
app.Run();
