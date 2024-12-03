using Blog.Core.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers;

/// <summary>
/// Controller for managing blog-related operations.
/// </summary>
[Route("api/blogs")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService; 

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogController"/> class.
    /// </summary>
    /// <param name="blogService">The blog service.</param>
    public BlogController(IBlogService blogService)
    {
       _blogService = blogService;
    }

    /// <summary>
    /// Gets all blogs.
    /// </summary>
    /// <returns>A list of all blogs.</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _blogService.GetAll();
        return Ok(result);
    }

    /// <summary>
    /// Gets a blog by the specified identifier.
    /// </summary>
    /// <param name="id">The blog identifier.</param>
    /// <returns>The blog with the specified identifier.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id) 
    {
        var result = await _blogService.GetBlogById(id);
        if (result == null)
        {
            return NotFound();
        }
        return Ok(result);
    }

    /// <summary>
    /// Creates a new blog post.
    /// </summary>
    /// <param name="blog">The blog to create.</param>
    /// <returns>The created blog.</returns>
    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] Core.Blog.Blog blog)
    {
        var createdBlog = await _blogService.CreateBlog(blog);
        return Ok(createdBlog);
    }

    /// <summary>
    /// Updates an existing blog.
    /// </summary>
    /// <param name="id">The blog identifier.</param>
    /// <param name="blog">The updated blog data.</param>
    /// <returns>A status indicating whether the update was successful.</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBlog(int id, [FromBody] Core.Blog.Blog blog)
    {
        var isUpdated = await _blogService.UpdateBlog(id, blog);
        if(isUpdated)
        {
            return Ok(isUpdated);
        }
        return NotFound();
    }

    /// <summary>
    /// Deletes a blog by the specified identifier.
    /// </summary>
    /// <param name="id">The blog identifier.</param>
    /// <returns>A status indicating whether the deletion was successful.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        var isDeleted = await _blogService.DeleteBlog(id);
        if(isDeleted)
            return Ok(isDeleted);
        return NotFound();
    }
}
