using DotNet8.EmailServiceMinimalApi.Models.User;

namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Auth;

public class AuthRepository
{
    private readonly AppDbContext _db;

    public AuthRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<bool>> Register(UserModel reqModel)
    {
        var item = await _db.TblUsers
            .FirstOrDefaultAsync(x => x.UserId == reqModel.UserId);
        if (item is not null) return Result<bool>.FailureResult("Duplicate User.");
        var user = new TblUser
        {
            UserName = reqModel.UserName,
            Email = reqModel.Email,
            HashPassword = reqModel.HashPassword,
        };
        _db.TblUsers.Add(user);
        var result = await _db.SaveChangesAsync();
        return result == 0 ? Result<bool>.FailureResult() : Result<bool>.SuccessResult();
    }

    public async Task<Result<string>> SignIn(UserModel reqModel)
    {
        var item = await _db.TblUsers.FirstOrDefaultAsync(x =>
            x.UserName == reqModel.UserName);
        if (item == null)
            return Result<string>.FailureResult("Invalid username");

        if (item.FailPasswordCount >= 3)
            return Result<string>.FailureResult("Your Account Is Lock");

        bool checkPass = item.HashPassword == reqModel.HashPassword;
        if (!checkPass)
        {
            item.FailPasswordCount += 1;
            await _db.SaveChangesAsync();
            return Result<string>.FailureResult("Invalid password.");
        };

        item.FailPasswordCount = 0;
        await _db.SaveChangesAsync();
        return checkPass == true ? Result<string>.SuccessResult() : Result<string>.FailureResult();
    }
}