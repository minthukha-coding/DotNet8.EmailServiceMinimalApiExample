namespace DotNet8.MinimalApiProjectStructureExampleBackend.Services;

public static class ModularService
{
    public static WebApplicationBuilder AddModularService(this WebApplicationBuilder builder)
    {
        return builder
            .AddDbContextService()
            .AddEmailService()
            .AddDataAcccessLayer()
            .AddBusinessLogicLayer();
    } 

    public static WebApplicationBuilder AddDbContextService(this WebApplicationBuilder builder)
    {
        builder.Services.AddDbContext<AppDbContext>(opt =>
        {
            var connectionString = builder.Configuration.GetSection("DbConnection").Value ??
                                   throw new AggregateException("connectionString is null");
            opt.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            opt.UseSqlServer(connectionString);
        },ServiceLifetime.Transient,ServiceLifetime.Transient);
        return builder;
    }
    
    private static WebApplicationBuilder AddBusinessLogicLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<BlogService>();
        return builder;
    }

    private static WebApplicationBuilder AddDataAcccessLayer(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<BlogRepository>();
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
