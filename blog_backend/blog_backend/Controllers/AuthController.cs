

using blog_backend.Models;
using blog_backend.Service;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace blog_backend.Controllers
{
    [Route("/api/[action]")]
    [ApiController]

    public class AuthController : ControllerBase
    {
        private readonly HashPassword hashPassword;
        private readonly BlogContext context;

        public AuthController(HashPassword _hashPassword, BlogContext _context)
        {
            hashPassword = _hashPassword;
            context = _context;
        }
        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            string username = loginModel.username;
            string password = loginModel.password;
            var loginUsername = context.AspNetUsers.FirstOrDefaultAsync(data => data.UserName == username);
            if (loginUsername == null)
            {
                return new JsonResult(new
                {
                    message = "Tài khoản hoặc mật khẩu không đúng !",
                    StatusCode = 404
                });

            }
            if (loginUsername != null)
            {
                string getHassedPassword = loginUsername.Result.PasswordHash;
                bool isLoginSuccess = hashPassword.VertifyPassword(password, getHassedPassword);
                if (isLoginSuccess == true)
                {
                    return new JsonResult(new
                    {
                        message = "Đăng nhập thành công !",
                        StatusCode = 200
                    });
                }
                else if (isLoginSuccess == false)
                {
                    return new JsonResult(new
                    {
                        message = "Tài khoản hoặc mật khẩu không đúng !",
                        StatusCode = 404
                    });
                }
            }
            return new JsonResult(new
            {
                loginUsername,
                message = "Ok"
            });

        }
        [HttpPost]
        public async Task<IActionResult> Register(LoginModel loginModel)
        {
            string username = loginModel.username;
            string password = loginModel.password;
            var isUsername = context.AspNetUsers.FirstOrDefault(v => v.UserName == username);
            if (isUsername == null)
            {
                string passwordHashed = hashPassword.HashedPassword(password);
                TimeZoneInfo vietnamTimeZone = TimeZoneInfo.FindSystemTimeZoneById("SE Asia Standard Time");
                DateTimeOffset currentTime = TimeZoneInfo.ConvertTime(DateTimeOffset.Now, vietnamTimeZone);
                string timestampString = currentTime.ToUnixTimeSeconds().ToString();
                Random random = new Random();
                int randomNumber = random.Next(1, 2001);
                string userId = $"user{randomNumber}";
                var create_user = new AspNetUsers
                {
                    IdUser = userId,
                    UserName = username,
                    PasswordHash = passwordHashed,
                    SecurityStamp = timestampString
                };
                await context.AspNetUsers.AddAsync(create_user);
                await context.SaveChangesAsync();
                return Ok(new
                {
                    message = "register success!",
                    StatusCode = 200,
                });
            }
            return new JsonResult(new
            {
                message = "registered users!",
                StatusCode = 400
            });

        }
    }

    public class LoginModel
    {
        public string username { get; set; }
        public string password { get; set; }
    }

}
