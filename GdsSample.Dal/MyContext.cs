using Microsoft.EntityFrameworkCore;

namespace GdsSample.Dal
{
    public class MyContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public MyContext(DbContextOptions<MyContext> context) : base(context)
        {

        }

    }
}
