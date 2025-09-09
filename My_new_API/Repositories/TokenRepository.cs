using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using My_new_API.Repositories.Interfaces;

namespace My_new_API.Repositories
{
    public class TokenRepository : ITokenRepository
    {
        public readonly IConfiguration _configuration;
        public TokenRepository(IConfiguration confg) {
            _configuration = confg;
        }

        public string CreateJWTToken(IdentityUser user, List<string> roles)
        {
            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, user.UserName));
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,null,expires: DateTime.Now.AddMinutes(15), credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
