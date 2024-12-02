using Blog.WebAPI.Infrastructure;
using Blog.Application.Blog;
using Blog.Core.Blog;

var builder = WebApplication.CreateBuilder(args);

// Add Cors services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//register services
builder.Services
    .AddSingleton<IBlogRepository, BlogRepository>()
    .AddSingleton<IBlogService, BlogService>();

var app = builder.Build();

// Use CORS middleware with the defined policy
app.UseCors("AllowAll");

app.UseMiddleware<ExceptionHandler>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
