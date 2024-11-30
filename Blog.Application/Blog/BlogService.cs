using Blog.Core.Blog;

namespace Blog.Application.Blog;

public class BlogService : IBlogService
{
    private readonly IBlogRepository _blogRepository;
    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<Core.Blog.Blog> CreateBlog(Core.Blog.Blog blog)
    {
       return await _blogRepository.CreateBlog(blog);
    }

    public async Task<bool> DeleteBlog(int id)
    {
        return await _blogRepository.DeleteBlog(id);
    }

    public async Task<List<Core.Blog.Blog>> GetAll()
    {
        return await _blogRepository.GetAll();
    }

    public async Task<Core.Blog.Blog?> GetBlogById(int id)
    {
       return await _blogRepository.GetBlogById(id);
    }

    public async Task<bool> UpdateBlog(int id, Core.Blog.Blog updatedBlog)
    {
       return await _blogRepository.UpdateBlog(id, updatedBlog);
    }
}
