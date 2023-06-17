using Microsoft.AspNetCore.Mvc;

namespace blog_backend.Controllers
{
    [Route("/api/[action]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly object _hostingEnvironment;

        [HttpPost]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {

            Console.WriteLine(file);
            return Ok(new
            {
                imageUrl = "URL",
                status = "Ok"
            });
        }


    }
}