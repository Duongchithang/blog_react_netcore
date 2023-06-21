using blog_backend.IResository;

using Microsoft.IdentityModel.Tokens;

using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace blog_backend.Service
{
    public class JsonWebToken : IJsonWebToken
    {
        private readonly IConfiguration configuration;

        public JsonWebToken(IConfiguration _configuration)
        {
            configuration = _configuration;
        }
        public string GenerateJsonWebToken()
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(configuration["JWT:Issuer"],
              configuration["JWT:Audience"],
              null,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        public bool VerifyToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(configuration["JWT:Key"]);

            var parameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                // Validate the token
                tokenHandler.ValidateToken(token, parameters, out var validatedToken);
                return validatedToken != null;
            }
            catch (SecurityTokenException)
            {
                // Invalid token
                return false;
            }
        }


    }
}
