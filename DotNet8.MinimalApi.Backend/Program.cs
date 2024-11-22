using DotNet8.EmailServiceMinimalApiExample.Models;
using DotNet8.MinimalApiProjectStructureExampleBackend.Services;
using MARB.Backend.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddModularService();
builder.Services.AddEndpoints(typeof(Program).Assembly);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var smtpSetting = builder.Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapEndpoints();
app.Run();
