using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Web.Controllers
{
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly BloggingContext _context;

        public BlogsController(BloggingContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Blog> Get()
        {
            return _context.Blogs;
        }

        [HttpGet]
        public async Task<IEnumerable<Blog>> GetAsync()
        {
            return await _context.Blogs.ToListAsync();
        }
    }
}