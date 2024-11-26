using System;
using System.Collections.Generic;

namespace DotNet8.EmailServiceMinimalApi.Databse.Db;

public partial class TblUser
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string PhoneNo { get; set; } = null!;

    public string Password { get; set; } = null!;
}
