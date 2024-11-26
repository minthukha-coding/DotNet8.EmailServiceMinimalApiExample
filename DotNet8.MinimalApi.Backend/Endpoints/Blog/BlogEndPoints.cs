using DotNet8.EmailServiceMinimalApi.Models.Blog;
using DotNet8.MinimalApiProjectStructureExample.Backend.Modules.Features.Blog;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.MinimalApiProjectStructureExampleBackend.Endpoints.Blog;

public class BlogEndPoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/blog/create",
            async (BlogRequestModel reqModel,
                [FromServices] BlogService _service) =>
            {
                return await CreateBlog(reqModel, _service);
            });
    }

    public async Task<string> CreateBlog(
        BlogRequestModel _requestModel,
        BlogService _service)
    {
        var model = _service.CreateBlog(_requestModel);
        return model.Result;
    }
}