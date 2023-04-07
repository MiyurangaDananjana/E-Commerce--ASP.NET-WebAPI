using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace e_com_RSEt_API.Models
{
    public class JWTService
    {
        public String SecretKey { get; set; }
        public TimeSpan TokenDuration { get; set; }

        private readonly IConfiguration config;

        public JWTService(IConfiguration _config)
        {
            config = _config;
            this.SecretKey = config.GetSection("jwtConfig").GetSection("key").Value;
            this.TokenDuration = TimeSpan.FromDays(Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value));
        }
        public String GenerateToken(String Id, String Name,String Role,String ImagePath)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));
            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var Pay_Load = new[]
            {
                  new Claim("Id",Id ),
                  new Claim("Name",Name ),
                  new Claim("ImageURL",ImagePath),
                  new Claim(ClaimTypes.Role, Role)
            };
            var jwtToken = new JwtSecurityToken(
                issuer: "localhost",
                audience: "localhost",
                claims: Pay_Load,
                expires: DateTime.UtcNow.Add(this.TokenDuration),
                signingCredentials: signature
                );
            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
