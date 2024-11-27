namespace DotNet8.EmailServiceMinimalApi.Models.User;

public class UserModel
{
    public int UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public int HashPassword { get; set; }
}