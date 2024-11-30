﻿namespace Blog.Core.Blog;
public interface IBlogService
{
    Task<List<Blog>> GetAll();
    Task<Blog?> GetBlogById(int id);
    Task<Blog> CreateBlog(Blog blog);
    Task<bool> UpdateBlog(int id, Blog updatedBlog);
    Task<bool> DeleteBlog(int id);
}
