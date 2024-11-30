using Blog.Core.Blog;
using Newtonsoft.Json;

namespace Blog.Application.Blog;
public class BlogRepository : IBlogRepository
{
    private readonly string _blogRepoFile = Path.Combine(Directory.GetCurrentDirectory(), "BlogData.json");

    public BlogRepository()
    {
        if (!File.Exists(_blogRepoFile))
        {
            File.WriteAllText(_blogRepoFile, "[]");
        }
    }
    public async Task<List<Core.Blog.Blog>> GetAll()
    {
        var jsonData = await File.ReadAllTextAsync(_blogRepoFile);
        return JsonConvert.DeserializeObject<List<Core.Blog.Blog>>(jsonData) ?? new List<Core.Blog.Blog>();
    }

    public async Task<Core.Blog.Blog?> GetBlogById(int id)
    {
        var blogs = await GetAll();
        return blogs.Find(b => b.Id == id);
    }

    public async Task<Core.Blog.Blog> CreateBlog(Core.Blog.Blog blog)
    {
        var blogs = await GetAll();
        var nextBlogId = blogs.Any() ? blogs.Max(b => b.Id) + 1 : 1;
        blog.Id = nextBlogId;
        blog.DateCreated = DateTime.Now;
        blogs.Add(blog);
        SaveBlog(blogs);
        return blog;
    }

    public async Task<bool> UpdateBlog(int id, Core.Blog.Blog updatedBlog)
    {
        var blogs = await GetAll();
        var existingBlog = blogs.Find(b => b.Id == id);
        if (existingBlog != null)
        {
            existingBlog.Text = updatedBlog.Text;
            existingBlog.UserName = updatedBlog.UserName;
            SaveBlog(blogs);
            return true;
        }
        return false;
    }
    public async Task<bool> DeleteBlog(int id) 
    {
        var blogs = await GetAll();
        var blogtoBeDeleted = blogs.Find(b => b.Id == id);
        if(blogtoBeDeleted != null)
        {
            blogs.Remove(blogtoBeDeleted);
            SaveBlog(blogs);
            return true;
        }
        return false;
    }

    private void SaveBlog(List<Core.Blog.Blog> blogs)
    {
        var blogsJson = JsonConvert.SerializeObject(blogs, Formatting.Indented);
        File.WriteAllText(_blogRepoFile, blogsJson);
    }
}
