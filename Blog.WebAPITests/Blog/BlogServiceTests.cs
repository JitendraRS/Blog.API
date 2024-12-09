using Microsoft.VisualStudio.TestTools.UnitTesting;
using Blog.Core.Blog;
using Moq;

namespace Blog.Application.Blog.Tests
{
    [TestClass()]
    public class BlogServiceTests
    {
        private BlogService? _blogService;
        private Mock<IBlogRepository>? _blogRepsitoryMoq;


        [TestInitialize]
        public void Setup()
        {
            _blogRepsitoryMoq = new Mock<IBlogRepository>();
            _blogService = new BlogService(_blogRepsitoryMoq.Object);
        }

        [TestMethod()]
        public async Task CreateBlogTest()
        {
            //Arrange
            var blogMock = new Core.Blog.Blog()
            {
                Id = 1,
                Text = "test blog",
                UserName = "test user name",
                DateCreated = DateTime.Now,
            };

            _blogRepsitoryMoq!.Setup(b => b.CreateBlog(It.IsAny<Core.Blog.Blog>()).Result).Returns(blogMock);

            //Act
            var result = await _blogService!.CreateBlog(blogMock);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(blogMock.Id, result.Id);
        }

        [TestMethod()]
        public async Task DeleteBlogTest()
        {
            //Arrange
            var blogId = 1;
            var blogDeleteResponseMock = true;

            _blogRepsitoryMoq!.Setup(b => b.DeleteBlog(It.IsAny<int>()).Result).Returns(blogDeleteResponseMock);

            //Act
            var result = await _blogService!.DeleteBlog(blogId);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }

        [TestMethod()]
        public async Task GetAllTest()
        {
            //Arrange
            var blogListResponseMock = new List<Core.Blog.Blog>
            {
                new Core.Blog.Blog()
                {
                    Id = 1,
                    Text = "test blog",
                    UserName = "test user name",
                    DateCreated = DateTime.Now,
                },
                new Core.Blog.Blog()
                {
                    Id = 2,
                    Text = "test blog 2",
                    UserName = "test user name 2",
                    DateCreated = DateTime.Now,
                }
            };

            _blogRepsitoryMoq!.Setup(b => b.GetAll().Result).Returns(blogListResponseMock);

            //Act
            var result = await _blogService!.GetAll();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(blogListResponseMock.FirstOrDefault()!.Id, result.FirstOrDefault()!.Id);
        }

        [TestMethod()]
        public async Task GetBlogByIdTest()
        {
            //Arrange
            var blogId = 1;
            var getBlogByIdResponseMock = new Core.Blog.Blog()
            {
                Id = 1,
                Text = "test blog",
                UserName = "test user name",
                DateCreated = DateTime.Now,
            };

            _blogRepsitoryMoq!.Setup(b => b.GetBlogById(It.IsAny<int>()).Result).Returns(getBlogByIdResponseMock);

            //Act
            var result = await _blogService!.GetBlogById(1);

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(blogId, result.Id);
        }

        [TestMethod()]
        public async Task UpdateBlogTest()
        {
            //Arrange
            var blogId = 1;
            var updateBlogMock = new Core.Blog.Blog()
            {
                Id = 1,
                Text = "test blog",
                UserName = "test user name",
                DateCreated = DateTime.Now,
            };
            var blogUpdatedResponseMock = true;


            _blogRepsitoryMoq!.Setup(b => b.UpdateBlog(It.IsAny<int>(),It.IsAny<Core.Blog.Blog>()).Result).Returns(blogUpdatedResponseMock);

            //Act
            var result = await _blogService!.UpdateBlog(blogId, updateBlogMock);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result);
        }
    }
}