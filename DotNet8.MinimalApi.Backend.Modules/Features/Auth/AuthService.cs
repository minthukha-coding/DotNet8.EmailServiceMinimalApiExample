namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Auth;

public class AuthService
{
    private readonly AuthRepository _authRepository;

    public AuthService(AuthRepository authRepository)
    {
        _authRepository = authRepository;
    }
}