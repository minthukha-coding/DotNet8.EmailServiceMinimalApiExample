using DotNet8.EmailServiceMinimalApiBackend.Modules.Features.EmailService;

namespace DotNet8.EmailServiceMinimalApiBackend.Services;

public static class ModularService
{
    public static WebApplicationBuilder AddModularService(this WebApplicationBuilder builder)
    {
        return builder
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
}
