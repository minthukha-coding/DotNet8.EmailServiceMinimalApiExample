using System.Net.Mail;
using System.Net;
using FluentEmail.Core;
using DotNet8.EmailServiceMinimalApiExample.Models;

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

app.MapPost("/api/email/send", async (EmailRequestModel requestModel, IFluentEmail fluentEmail) =>
{
    var email = await fluentEmail
        .To(requestModel.MailTo)
        .Subject(requestModel.Subject)
        .Body(requestModel.Body)
        .SendAsync();

    if (email.Successful)
    {
        return Results.Ok(MessageResponseModel.Ok);
    }

    return Results.Json(MessageResponseModel.Fail,statusCode: 500);
});

app.Run();
