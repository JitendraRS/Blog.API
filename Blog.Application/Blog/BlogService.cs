using Blog.Core.Blog;

namespace Blog.Application.Blog;

/// <summary>
/// Service class for managing blog operations.
/// </summary>
public class BlogService : IBlogService
{

    private readonly IBlogRepository _blogRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogService"/> class.
    /// </summary>
    /// <param name="blogRepository">The blog repository instance.</param>
    public BlogService(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    /// <summary>
    /// Creates a new blog.
    /// </summary>
    /// <param name="blog">The blog to create.</param>
    /// <returns>The created blog.</returns>
    public async Task<Core.Blog.Blog> CreateBlog(Core.Blog.Blog blog)
    {
       return await _blogRepository.CreateBlog(blog);
    }

    /// <summary>
    /// Deletes a blog by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the blog to delete.</param>
    /// <returns>True if the blog was deleted; otherwise, false.</returns>
    public async Task<bool> DeleteBlog(int id)
    {
        return await _blogRepository.DeleteBlog(id);
    }

    /// <summary>
    /// Gets all blogs.
    /// </summary>
    /// <returns>A list of all blogs.</returns>
    public async Task<List<Core.Blog.Blog>> GetAll()
    {
        return await _blogRepository.GetAll();
    }

    /// <summary>
    /// Gets a blog by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the blog to retrieve.</param>
    /// <returns>The blog with the specified identifier, or null if not found.</returns>
    public async Task<Core.Blog.Blog?> GetBlogById(int id)
    {
       return await _blogRepository.GetBlogById(id);
    }

    /// <summary>
    /// Updates an existing blog.
    /// </summary>
    /// <param name="id">The identifier of the blog to update.</param>
    /// <param name="updatedBlog">The updated blog data.</param>
    /// <returns>True if the blog was updated; otherwise, false.</returns>
    public async Task<bool> UpdateBlog(int id, Core.Blog.Blog updatedBlog)
    {
       return await _blogRepository.UpdateBlog(id, updatedBlog);
    }
}
