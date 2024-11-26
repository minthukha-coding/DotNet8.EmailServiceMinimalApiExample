using DotNet8.EmailServiceMinimalApi.Databse.Db;
using DotNet8.EmailServiceMinimalApi.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Blog;

public class BlogRepository
{
    private readonly AppDbContext _db;

    public BlogRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<string> CreateBlog(BlogRequestModel requestModel)
    {
        var item = new TblBlog
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContext
        };
        _db.TblBlogs.Add(item);
        int result = await _db.SaveChangesAsync();
        var message = result == 0 ? "Fail" : "Success";

        return message;
    }
    
}