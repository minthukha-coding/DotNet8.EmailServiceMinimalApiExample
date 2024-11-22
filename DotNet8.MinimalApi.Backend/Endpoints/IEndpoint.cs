namespace DotNet8.MinimalApiProjectStructureExampleBackend.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder routeBuilder);
}