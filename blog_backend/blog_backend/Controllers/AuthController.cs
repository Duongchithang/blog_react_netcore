using Microsoft.AspNetCore.Mvc;

namespace blog_backend.Controllers
{
    [Route("/api/[action]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        public AuthController()
        {

        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            if (loginModel.username == "user")
            {
                return new JsonResult(new
                {
                    message = "OK"
                });

            }
            if (string.IsNullOrEmpty(loginModel.username) == true || string.IsNullOrEmpty(loginModel.password) == true)
            {
                return BadRequest(new
                {
                    message = "username or password is hollow"
                });
            }
            return Ok(new
            {
                message = "success",
                loginModel.username,
                loginModel.password
            });
            //Console.WriteLine(new
            //{
            //    dataLogin.username,
            //    dataLogin.password
            //});   
            //return Ok(
            //    new
            //    {
            //        message = "OK",
            //        username = dataLogin.username,
            //        password = dataLogin.password

            //    }
            //);
        }
    }
    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
