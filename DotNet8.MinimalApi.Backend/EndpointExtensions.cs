namespace DotNet8.MinimalApiProjectStructureExampleBackend;

public static class EndpointExtensions
{
    public static IServiceCollection AddEndpoints(this IServiceCollection services, Assembly assembly)
    {
        var endpointTypes = assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && typeof(IEndpoint).IsAssignableFrom(t));

        foreach (var type in endpointTypes)
        {
            services.AddScoped(typeof(IEndpoint), type);
        }

        return services;
    }

    public static WebApplication MapEndpoints(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var scopedServices = scope.ServiceProvider;
            var endpoints = scopedServices.GetServices<IEndpoint>();
            foreach (var endpoint in endpoints)
            {
                endpoint.MapEndpoint(app);
            }
        }
        return app;
    }
}