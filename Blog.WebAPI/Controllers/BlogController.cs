using Blog.Core.Blog;
using Microsoft.AspNetCore.Mvc;

namespace Blog.WebAPI.Controllers;

[Route("api/blogs")]
[ApiController]
public class BlogController : ControllerBase
{
    private readonly IBlogService _blogService; 
    public BlogController(IBlogService blogService)
    {
       _blogService = blogService;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _blogService.GetAll();
        return Ok(result);
    }

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

    [HttpPost]
    public async Task<IActionResult> CreatePost([FromBody] Core.Blog.Blog blog)
    {
        var createdBlog = await _blogService.CreateBlog(blog);
        return Ok(createdBlog);
    }

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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBlog(int id)
    {
        var isDeleted = await _blogService.DeleteBlog(id);
        if(isDeleted)
            return Ok(isDeleted);
        return NotFound();
    }
}
