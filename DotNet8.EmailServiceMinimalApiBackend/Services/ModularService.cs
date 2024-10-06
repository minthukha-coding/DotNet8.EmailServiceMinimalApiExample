using DotNet8.EmailServiceMinimalApiBackend.Modules.Features.EmailService;

namespace DotNet8.EmailServiceMinimalApiBackend.Services;

public static class ModularService
{
    public static WebApplicationBuilder AddModularService(this WebApplicationBuilder builder)
    {
        return builder
            .AddEmailService()
            .AddDataAcccessLayer()
            .AddBusinessLogicLayer();
    }

    private static WebApplicationBuilder AddBusinessLogicLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<EmailService>();
        return builder;
    }

    private static WebApplicationBuilder AddDataAcccessLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<EmailServiceRepository>();
        return builder;
    }
  
    private static WebApplicationBuilder AddEmailService(this WebApplicationBuilder builder)
    {
        var fromEmail = builder.Configuration.GetSection("EmailSender").Value;
        var smtpMail = builder.Configuration.GetSection("EmailHost").Value;
        var appPwd = builder.Configuration.GetSection("EmailSenderAppPassword").Value;
        var port = builder.Configuration.GetSection("EmailPort").Value;

        builder.Services.AddFluentEmail(fromEmail)
                        .AddSmtpSender(smtpMail, Convert.ToInt32(port), fromEmail, appPwd);
        return builder;
    }
}
