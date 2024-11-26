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

    public async Task<string> CreateBlog(BlogRequestModel requestModel)
    {
        var model = _blogRepository.CreateBlog(requestModel);
        return model.Result;
    }
}