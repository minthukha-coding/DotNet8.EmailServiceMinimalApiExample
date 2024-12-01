namespace DotNet8.MinimalApiProjectStructureExampleBackend.Endpoints.Blog;

public class BlogEndPoints : IEndpoint
{
    public void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("/api/blog/list",
            async ([FromServices] BlogService _service) => await BlogList(_service));
        
        app.MapPost("/api/blog/create",
            async (BlogModel reqModel,
                [FromServices] BlogService _service) => await CreateBlog(reqModel, _service));
        
        app.MapPost("/api/blog/update",
            async (BlogModel reqModel,
                [FromServices] BlogService _service) => await UpdateBlog(reqModel,_service)); 
        
        app.MapPost("/api/blog/delete/{blogId}",
            async (int blogId,
                [FromServices] BlogService _service) => await DeleteBlog(blogId,_service));
    }

    public async Task<Result<string>> CreateBlog(
        BlogModel _requestModel,
        BlogService _service)
    {
        var model = await _service.CreateBlog(_requestModel);
        return model;
    }
    
    public async Task<Result<List<BlogModel>>> BlogList(
        BlogService _service)
    {
        var model = await _service.BlogList();
        return model;
    }
    
    public async Task<Result<int>> UpdateBlog(
        BlogModel _reqModel,
        BlogService _service)
    {
        var model = await _service.UpdateBlog(_reqModel);
        return model;
    } 
    
    public async Task<Result<bool>> DeleteBlog(
        int blogId,
        BlogService _service)
    {
        var model = await _service.DeleteBlog(blogId);
        return model;
    }
}