using BlogSite.Web.Data;
using BlogSite.Web.Models.Domain;
using BlogSite.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Web.Controllers
{
    public class AdminBlogPostsController : Controller
    {
        private readonly BlogSiteDbContext blogSiteDbContext;
        public AdminBlogPostsController(BlogSiteDbContext blogSiteDbContext)
        {
            this.blogSiteDbContext = blogSiteDbContext;
        }
        [HttpGet]
        public IActionResult AddBlogPost()
        {
            return View();
        }

        [HttpPost]
        [ActionName("AddBlogPost")]
        public IActionResult AddBlogPost(AddBlogPostRequest addBlogPostRequest)
        {
            var blog = new BlogPost
            {
                Heading = addBlogPostRequest.Heading,
                PageTitle = addBlogPostRequest.PageTitle,
                Content = addBlogPostRequest.Content,
                ShortDescription = addBlogPostRequest.ShortDescription,
                FeaturedImageUrl = addBlogPostRequest.FeaturedImageUrl,
                UrlHandle = addBlogPostRequest.UrlHandle,
                PublishedDate = addBlogPostRequest.PublishedDate,
                Author = addBlogPostRequest.Author,
                Visible = addBlogPostRequest.Visible
            };

            blogSiteDbContext.TableBlogPost.Add(blog);
            blogSiteDbContext.SaveChanges();

            return View("AddBlogPost");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBlogPosts()
        {
            var blogs = await blogSiteDbContext.TableBlogPost.ToListAsync();
            return View(blogs);
        }
    }
}
