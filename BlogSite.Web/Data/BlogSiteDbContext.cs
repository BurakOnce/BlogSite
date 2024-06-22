using BlogSite.Web.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace BlogSite.Web.Data
{
    public class BlogSiteDbContext : DbContext
    {
        public BlogSiteDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BlogPost> TableBlogPost { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}
