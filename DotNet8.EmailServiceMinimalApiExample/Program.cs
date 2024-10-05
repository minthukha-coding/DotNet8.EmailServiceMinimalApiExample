using DotNet8.EmailServiceMinimalApiExample.Models;
using System.Net.Mail;
using System.Net;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var smtpSetting = builder.Configuration.GetSection("SmtpSettings").Get<SmtpSettings>();

builder.Services
           .AddFluentEmail(smtpSetting!.User)
           .AddRazorRenderer()
           .AddSmtpSender(new SmtpClient(smtpSetting.Host)
           {
               Port = smtpSetting.Port,
               Credentials = new NetworkCredential(smtpSetting.User, smtpSetting.Pass),
               EnableSsl = smtpSetting.EnableSsl
           });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
