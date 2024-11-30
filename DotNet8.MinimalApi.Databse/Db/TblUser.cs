namespace DotNet8.EmailServiceMinimalApi.Databse.Db;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public int HashPassword { get; set; }
}