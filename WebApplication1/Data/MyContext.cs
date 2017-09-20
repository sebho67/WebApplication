using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class MyContext : Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext
    {
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }

        public MyContext(DbContextOptions<MyContext> context) : base(context)
        {

        }

    }

    public abstract class BaseObject
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
    }

    public class Blog : BaseObject
    {

        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
   
    public class Post : BaseObject
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public IdentityUser Author { get; set; }
        public DateTime PublishedTime { get; set; }
        public int ReadTimes { get; set; }
        public string ImgUrl { get; set; } = "http://placeimg.com/640/480/any";

        public Blog Blog { get; set; }
        public string BlogId { get; set; }

    }


}
