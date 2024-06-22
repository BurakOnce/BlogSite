using BlogSite.Web.Data;
using BlogSite.Web.Models.Domain;
using BlogSite.Web.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BlogSite.Web.Controllers
{
    public class AdminTagsController : Controller
    {
        private readonly BlogSiteDbContext blogSiteDbContext;
        public AdminTagsController(BlogSiteDbContext blogSiteDbContext)
        {
            this.blogSiteDbContext = blogSiteDbContext;
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ActionName("Add")]
        public IActionResult Add(AddTagRequest addTagRequest) 
        {
            var tag = new Tag
            {
                Name = addTagRequest.Name,
                DisplayName = addTagRequest.DisplayName,
            };
            blogSiteDbContext.Tags.Add(tag);
            blogSiteDbContext.SaveChanges();
             
            return View("Add");
        }
    }
}
