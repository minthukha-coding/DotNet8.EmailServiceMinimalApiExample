namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Blog;

public class BlogRepository
{
    private readonly AppDbContext _db;

    public BlogRepository(AppDbContext db)
    {
        _db = db;
    }

    public async Task<Result<string>> CreateBlog(BlogModel model)
    {
        var item = new TblBlog
        {
            BlogTitle = model.BlogTitle,
            BlogAuthor = model.BlogAuthor,
            BlogContent = model.BlogContent
        };
        _db.TblBlogs.Add(item);
        int result = await _db.SaveChangesAsync();
        var message = result == 0 ? Result<string>.FailureResult() : Result<string>.SuccessResult();

        return message;
    }

    public async Task<Result<List<BlogModel>>> BlogList()
    {
        var lst = await _db.TblBlogs.ToListAsync();
        var model = lst.Select(blog => new BlogModel
        {
            BlogId = blog.BlogId,
            BlogTitle = blog.BlogTitle,
            BlogAuthor = blog.BlogAuthor,
            BlogContent = blog.BlogContent!,
        }).ToList();
        return Result<List<BlogModel>>.SuccessResult(model);
    }

    public async Task<Result<bool>> DeleteBlog(int blogId)
    {
        var item = await _db.TblBlogs
            .FirstOrDefaultAsync(x => x.BlogId == blogId);
        if (item is null) return Result<bool>.FailureResult();
        _db.TblBlogs.Remove(item);
        await _db.SaveChangesAsync();
        return Result<bool>.SuccessResult();
    }

    public async Task<Result<int>> UpdateBlog(BlogModel model)
    {
        var item = await _db.TblBlogs
            .FirstOrDefaultAsync(x => x.BlogId == model.BlogId);

        if (item is null) return Result<int>.FailureResult();
        
        item!.BlogTitle = model.BlogTitle;
        item.BlogAuthor = model.BlogTitle;
        item.BlogContent = model.BlogTitle;
        _db.TblBlogs.Update(item);
        int message = await _db.SaveChangesAsync();
        return Result<int>.SuccessResult(message);
    }
}