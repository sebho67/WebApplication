using GdsSample.Dal;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;

        public HomeController(MyContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index()
        {
            var posts = _context.Posts.OrderBy(post => post.PublishedTime).ToList();
            return View(posts);
        }


        [HttpGet]
        public IActionResult Detail(string id)
        {
            var post = _context.Posts
                    .Where(p => p.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))
                    .SingleOrDefault();
            if (post != null)
            {
                return View(post);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult Edit(string id)
        {
            var article = _context.Posts.Where(post => post.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase)).SingleOrDefault();
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(Post article)
        {
            if (ModelState.IsValid)
            {
                _context.Posts.Update(article);
                _context.SaveChanges();
                return RedirectToAction(nameof(HomeController.Detail), new { id = article.Id });
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpGet]
        public IActionResult AddData()
        {
            if (!_context.Blogs.Any())
            {
                var blog = new Blog()
                {
                    Title = "Mon blog 1"
                };
                _context.Blogs.Add(blog);
                _context.SaveChanges();

            }


            var lastblog = _context.Blogs.Last();
            for (int i = 0; i < 10; i++)
            {
                var post = new Post()
                {
                    Title = $"Mon post {i}",
                    PublishedTime = DateTime.Now,
                    Content = "Lorem ipsum dolor timet etc etc.",
                    ReadTimes = new Random().Next(0, 1000),
                    BlogId = lastblog.Id
                };

                _context.Posts.Add(post);

            }
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }

    }
}
