namespace DotNet8.EmailServiceMinimalApiBackend.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder routeBuilder);
}