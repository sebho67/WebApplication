using Microsoft.AspNetCore.Identity;
using System;

namespace GdsSample.Dal
{

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
