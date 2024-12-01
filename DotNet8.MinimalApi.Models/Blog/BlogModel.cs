namespace DotNet8.EmailServiceMinimalApi.Models.Blog;

public class BlogModel
{
    public int BlogId { get; set; }
    public string BlogTitle { get; set; }
    public string BlogAuthor { get; set; }
    public string BlogContent { get; set; }
    public string CreatedUserId { get; set; }
}