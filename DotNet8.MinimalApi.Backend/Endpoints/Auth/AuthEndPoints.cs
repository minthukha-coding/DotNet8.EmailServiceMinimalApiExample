using DotNet8.EmailServiceMinimalApi.Models.User;
using DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Auth;

namespace DotNet8.MinimalApiProjectStructureExampleBackend.Endpoints.Auth;

public class AuthEndPoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/blog/register",
            async (UserModel reqModel,
                [FromServices] AuthService _service) => await Register(reqModel, _service));
    }

    public async Task<Result<bool>> Register(
        UserModel reqModel,
        AuthService _authService)
    {
        var model = await _authService.Register(reqModel);
        return model;
    }
}