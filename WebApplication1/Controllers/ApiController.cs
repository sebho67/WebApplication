using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
	[Route("ws/[controller]")]
	public class ApiController : Controller
	{
		private MyContext _context;

		public ApiController(MyContext context)
		{
			_context = context;
		}


		// GET: api/values
	   [HttpGet]
		public IActionResult Get()
		{
			return Json(_context.Posts.ToList());
		}


		// GET api/values/5
			   [HttpGet("{id}")]
		public IActionResult Get(string id)
		{
			var post = _context.Posts
					.Where(p => p.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase))
					.SingleOrDefault();
			if (post != null)
			{
				return Json(post);
			}
			else
			{
				return NotFound();
			}
		}



		// POST api/values
		[HttpPost]
		public void Post([FromBody]Post value)
		{
			_context.Posts.Add(value);
			_context.SaveChanges();

		}

		// PUT api/values/5
		[HttpPut("{id}")]
		public IActionResult Put(string id, [FromBody]Post value)
		{
		 if (id.Equals(value.Id, StringComparison.InvariantCultureIgnoreCase))
			{
				_context.Posts.Update(value);
				if (_context.SaveChanges() > 0)
				{
					return Ok();
				}
				else
				{
					return BadRequest("Aucun changement en base");
				}
			}
			else
			{
				return BadRequest("Mauvais Id");
			}

		}

		// DELETE api/values/5
		[HttpDelete("{id}")]
		public void Delete(string id)
		{
			var post = _context.Posts.FirstOrDefault(p => p.Id.Equals(id, StringComparison.InvariantCultureIgnoreCase));
			_context.Posts.Remove(post);
			_context.SaveChanges();

		}
	}
}
