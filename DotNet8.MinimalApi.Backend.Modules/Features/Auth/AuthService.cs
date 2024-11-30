using DotNet8.EmailServiceMinimalApi.Models.User;

namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Auth;

public class AuthService
{
    private readonly AuthRepository _authRepository;

    public AuthService(AuthRepository authRepository)
    {
        _authRepository = authRepository;
    }

    public async Task<Result<bool>> Register(UserModel reqModel)
    {
        var model = await _authRepository.Register(reqModel);
        return model;
    }
}