using blog_backend.Models;

using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace blog_backend.Controllers
{
    [Route("/api/[action]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly BlogContext context;

        public PostController(BlogContext _context)
        {
            context = _context;
        }

        [HttpPost]
        public IActionResult CreatePost(string html)
        {

            //var newBlog = new Post
            //{
            //    IdPost = "01",
            //    Content = convertHtml
            //};
            return Ok(new
            {
                message = "OK"
            });
        }

        // GET api/<PostController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<PostController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PostController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PostController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
