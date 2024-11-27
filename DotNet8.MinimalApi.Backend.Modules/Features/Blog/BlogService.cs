using DotNet8.EmailServiceMinimalApi.Models;
using DotNet8.EmailServiceMinimalApi.Models.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Blog;

public class BlogService
{
    private readonly BlogRepository _blogRepository;

    public BlogService(BlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Result<string>> CreateBlog(BlogModel requestModel)
    {
        var model = await _blogRepository.CreateBlog(requestModel);
        return model;
    }
    
    public async Task<Result<List<BlogModel>>> BlogList()
    {
        var model = await _blogRepository.BlogList();
        return model;
    }
    
    public async Task<Result<bool>> DeleteBlog(int blogId)
    {
        var model = await _blogRepository.DeleteBlog(blogId);
        return model;
    }
    
    public async Task<Result<int>> UpdateBlog(BlogModel _reqModel)
    {
        var model = await _blogRepository.UpdateBlog(_reqModel);
        return model;
    }
}