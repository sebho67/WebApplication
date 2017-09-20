using System.Collections.Generic;

namespace GdsSample.Dal
{
    public class Blog : BaseObject
    {

        public string Title { get; set; }
        public List<Post> Posts { get; set; }
    }
}
